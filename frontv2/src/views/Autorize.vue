<template>
  <v-card elevation="8" width="400px" height="400px" class="rounded-xl">
    <v-card-title class="mt-3 ml-3">
      <span class="title-border pl-3">Login for Issue calendar</span>
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
      <v-row>
        <v-col class="d-flex justify-center pb-0">
          <v-btn color="blue" class="white--text" @click="sendData">Enter</v-btn>
        </v-col>
      </v-row>
    </v-card-text>
  </v-card>
</template>

<script>
export default {
  name: 'Autorize-page',
  data () {
    return {
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
      fetch('http://localhost:2000/Authenticate/register', {
        method: 'POST',
        headers: {
          'Access-Control-Allow-Origin': '*',
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
      }).then(response => response.json())
    }
  }
}
</script>

<style scoped>
.title-border{
  border-left: 5px solid #e91363;
}
</style>
