<template>
  <v-card elevation="8" width="400px" height="400px" class="rounded-xl">
    <v-card-title class="mt-3 ml-3">
      <span class="title-border pl-3">{{text}} for Issue calendar</span>
    </v-card-title>
    <v-card-text class="mr-3">
      <v-row class="mt-3">
        <v-col cols="12" class="pb-0">
          <v-text-field outlined
            label="Enter your login"
            v-model="login"></v-text-field>
        </v-col>
        <v-col cols="12" class="pt-0">
          <v-text-field outlined
            label="Enter your password"
            v-model="pswd"></v-text-field>
        </v-col>
      </v-row>
      <v-row class="mt-0 primary--text">
        <v-col col="12" v-if="switcher === 'login'" class="pt-0 d-flex justify-end">
          <span @click="switcher = 'registr'; text='Register'" style="cursor: pointer">Sign up</span>
        </v-col>
        <v-col col="12" v-if="switcher === 'registr'" class="pt-0 d-flex justify-end">
          <span @click="switcher = 'login'; text='Log'" style="cursor: pointer">Log in</span>
        </v-col>
      </v-row>
      <v-row>
        <v-col class="d-flex justify-center pb-0">
          <v-btn color="blue" class="white--text" @click="sendData">Enter</v-btn>
        </v-col>
      </v-row>
    </v-card-text>
  </v-card>
</template>

<script>
import axios from 'axios'

export default {
  name: 'Autorize-page',
  data () {
    return {
      text: 'Log',
      switcher: 'login',
      login: '',
      pswd: ''
    }
  },
  methods: {
    sendData () {
      const data = {
        email: this.login,
        password: this.pswd
      }
      if (this.switcher === 'registr') {
        axios.post('http://localhost:2000/api/Authenticate/register', data)
          .then(response => {
            console.log(response)
          })
      }
      if (this.switcher === 'login') {
        axios.post('http://localhost:2000/api/Authenticate/login', data)
          .then(response => {
            window.sessionStorage.setItem('token', response.data)
            this.$store.dispatch('autorize/setTokenAction', response.data)
            this.$router.push({ path: '/issues' })
          })
      }
    }
  }
}
</script>

<style scoped>
.title-border{
  border-left: 5px solid #e91363;
}
</style>
