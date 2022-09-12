<template>
  <v-app class="app">
    <v-main class="d-flex justify-center align-center">
      <div class="d-flex justify-center">
        <router-view />
      </div>
    </v-main>
  </v-app>
</template>

<script>

export default {
  name: 'App',

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
