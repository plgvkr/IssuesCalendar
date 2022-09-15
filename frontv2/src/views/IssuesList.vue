<template>
  <div>
    <List></List>
    <v-btn @click="giveData" class="mt-4">Give data</v-btn>
  </div>
</template>

<script>
import axios from 'axios'
import { mapGetters } from 'vuex'
import List from '../components/List.vue'

export default {
  name: 'IssueList',
  components: {
    List
  },
  methods: {
    giveData () {
      console.log(window.sessionStorage)
      const config = {
        headers: { Authorization: `Bearer ${window.sessionStorage.getItem('token')}` }
      }
      // eslint-disable-next-line
      axios.get('http://localhost:2000/api/ScheduledTask', config)
        .then(response => {
          console.log(response)
        })
    }
  },
  computed: {
    ...mapGetters('autorize', { token: 'getToken' })
  }
}
</script>

<style scoped>

</style>
