<template>
  <v-card elevation="8" class="rounded-xl" min-width="1050px">
    <v-card-title class="pt-7 pl-7">
      <span class="title-border pl-3">List</span>
    </v-card-title>
    <v-card-text class="pl-7 pb-10 pt-3">
      <div v-if="issues.length < 1" class="pr-2 d-flex justify-center">
        <strong>All issues cmpleted!</strong>
      </div>
      <div v-else>
        <v-row class="helper mb-2">
          <v-col cols="1">
            <strong>#Key</strong>
          </v-col>
          <v-col cols="3">
            <strong>#Title</strong>
          </v-col>
          <v-col cols="6">
            <strong>#Description</strong>
          </v-col>
          <v-col cols="2">
            <strong>#Date</strong>
          </v-col>
        </v-row>
        <div v-for="(issue, index) of issues" :key="index">
          <v-row>
            <v-col cols="1" class="myBorder d-flex align-end justify-start py-5">
              {{ issue.id }}
            </v-col>
            <v-col cols="3" class="myBorder d-flex align-end justify-start py-5">
              {{ issue.name }}
            </v-col>
            <v-col cols="6" class="myBorder d-flex align-end justify-start py-5">
              {{ issue.description }}
            </v-col>
            <v-col cols="1" class="myBorder d-flex align-end justify-start py-5">
              {{ issue.scheduledDay }}
            </v-col>
            <v-col cols="1" class="d-flex align-center justify-space-around">
              <svg @click="editIssue(issue.id)" class="pic edit-pic" viewBox="0 0 48 48" xmlns="http://www.w3.org/2000/svg"><path d="M6 34.5v7.5h7.5l22.13-22.13-7.5-7.5-22.13 22.13zm35.41-20.41c.78-.78.78-2.05 0-2.83l-4.67-4.67c-.78-.78-2.05-.78-2.83 0l-3.66 3.66 7.5 7.5 3.66-3.66z"/><path d="M0 0h48v48h-48z" fill="none"/></svg>
              <svg @click="deleteIssue(issue)" class="pic bin-pic" viewBox="0 0 48 48" xmlns="http://www.w3.org/2000/svg"><path d="M12 38c0 2.21 1.79 4 4 4h16c2.21 0 4-1.79 4-4V14H12v24zM38 8h-7l-2-2H19l-2 2h-7v4h28V8z"/><path d="M0 0h48v48H0z" fill="none"/></svg>
            </v-col>
          </v-row>
          <hr>
        </div>
      </div>
    </v-card-text>
  </v-card>
</template>

<script>
import { mapGetters } from 'vuex'
import axios from 'axios'

export default {
  name: 'IssueList-component',
  computed: {
    ...mapGetters('issues', { issues: 'getIssues' })
  },
  methods: {
    deleteIssue (issue) {
      const config = {
        headers: { Authorization: `Bearer ${window.sessionStorage.getItem('token')}` },
        data: {
          issue
        }
      }
      axios.delete('http://localhost:2000/api/ScheduledTask', config)
        .then(response => {
          axios.get('http://localhost:2000/api/ScheduledTask', config)
            .then(response => {
              this.$store.dispatch('issues/loadIssuesActions', response.data)
            })
        })
    },
    editIssue (id) {
      this.$store.dispatch('modal/toogleAction', id)
      this.$store.dispatch('issues/setEditIssueAction', id)
    }
  }
}
</script>

<style scoped>
.title-border{
  border-left: 5px solid #e91363;
}
.myBorder{
  border-right: 1px solid rgba(0, 0, 0, 0.6);
}
.helper{
  font-size: 19px;
}
.pic{
  width: 25px;
  height: 25px;
}
.pic:hover{
  cursor: pointer;
}
.edit-pic:hover{
  fill: #2196F3;
}
.bin-pic:hover{
  fill: #ff6868;
}
</style>
