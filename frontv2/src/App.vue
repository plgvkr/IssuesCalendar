<template>
  <v-app class="app">
    <NavigationModule></NavigationModule>
    <v-main class="d-flex justify-center align-center">
      <div class="d-flex justify-center">
        <router-view />
      </div>
    </v-main>
  </v-app>
</template>

<script>
import NavigationModule from './components/NavigationModule.vue'

export default {
  name: 'App',
  components: {
    NavigationModule
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
