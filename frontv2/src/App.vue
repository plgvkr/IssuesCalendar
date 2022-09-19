<template>
  <v-app class="app">
    <NavigationModule></NavigationModule>
    <v-main class="d-flex justify-center align-center">
      <div class="d-flex justify-center">
        <router-view />
      </div>
    </v-main>
    <IssueCreate></IssueCreate>
  </v-app>
</template>

<script>
import NavigationModule from './components/NavigationModule.vue'
import IssueCreate from './components/IssueCreate.vue'

export default {
  name: 'App',
  components: {
    NavigationModule,
    IssueCreate
  },
  data: () => ({
    //
  })
}
</script>

<style scoped>
.app{
  background: linear-gradient(45deg, #fead96, #c00def);
}
</style>
