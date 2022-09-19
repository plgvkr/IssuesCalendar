<template>
  <div class="text-center">
    <v-dialog
      v-model="open"
      persistent
      width="1000"
      overlay-opacity="0.9"
    >
      <v-card>
        <v-card-title class="pt-6">
          <span class="title-border pl-3" v-if="!edit">Create Issue</span>
          <span class="title-border pl-3" v-else>Edit Issue</span>
        </v-card-title>
        <v-card-text class="px-9 py-6">
          <v-row>
            <v-col cols="8">
              <v-text-field
                label="Issue title"
                outlined
                v-model="title"
              ></v-text-field>
            </v-col>
            <v-col cols="4">
              <v-menu
                v-model="menu"
                :close-on-content-click="false"
                :nudge-right="40"
                transition="scale-transition"
                offset-y
                min-width="auto"
              >
                <template v-slot:activator="{ on, attrs }">
                  <v-text-field
                    v-model="date"
                    label="Choose date"
                    prepend-icon="mdi-calendar"
                    readonly
                    v-bind="attrs"
                    v-on="on"
                  ></v-text-field>
                </template>
                <v-date-picker
                  v-model="date"
                  @input="menu = false"
                ></v-date-picker>
              </v-menu>
            </v-col>
          </v-row>
          <v-row>
            <v-col cols="12">
              <v-textarea
                outlined
                rows="3"
                row-height="15"
                label="Issue description"
                v-model="description"
              ></v-textarea>
            </v-col>
          </v-row>
          <v-row>
            <v-col cols="12">
              <v-btn @click="cancel" class="errorColor white--text mr-5">cancel</v-btn>
              <v-btn @click="submitIssue" class="acceptColor white--text">submit</v-btn>
            </v-col>
          </v-row>
        </v-card-text>
      </v-card>
    </v-dialog>
  </div>
</template>

<script>
import { mapGetters, mapState } from 'vuex'
import axios from 'axios'

export default {
  name: 'Issue-create',
  data () {
    return {
      title: '',
      menu: false,
      date: '',
      description: ''
    }
  },
  methods: {
    cancel () {
      this.$store.dispatch('modal/toogleAction')
      this.$store.dispatch('issues/clearEditIssueAction')
      this.title = ''
      this.date = ''
      this.description = ''
    },
    submitIssue () {
      const data = {
        id: 0,
        name: this.title,
        description: this.description,
        scheduledDay: this.date.split('-').reverse().join('.')
      }
      const config = {
        headers: { Authorization: `Bearer ${window.sessionStorage.getItem('token')}` }
      }
      if (this.edit) {
        return axios.put('http://localhost:2000/api/ScheduledTask', data, config)
          .then(response => {
            axios.get('http://localhost:2000/api/ScheduledTask', config)
              .then(response => {
                this.$store.dispatch('issues/loadIssuesActions', response.data)
                this.cancel()
              })
          })
      }
      // eslint-disable-next-line
      axios.post('http://localhost:2000/api/ScheduledTask', data, config)
        .then(response => {
          axios.get('http://localhost:2000/api/ScheduledTask', config)
            .then(response => {
              this.$store.dispatch('issues/loadIssuesActions', response.data)
              this.cancel()
            })
        })
    }
  },
  computed: {
    ...mapGetters('modal', { open: 'getIsOpen' }),
    ...mapState('issues', { editIssue: state => state.editIssue }),
    ...mapGetters('modal', { edit: 'getEdit' })
  },
  watch: {
    editIssue: function () {
      /* eslint-disable-next-line */
      this.title = this.editIssue.name
      this.description = this.editIssue.description
      this.date = this.editIssue.scheduledDay
      console.log(this.title)
    }
  }
}
</script>

<style scoped>
.title-border{
  border-left: 5px solid #e91363;
}
</style>
