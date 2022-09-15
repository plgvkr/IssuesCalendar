<template>
  <v-card elevation="8" class="rounded-xl" min-width="600px">
    <v-card-title class="pt-7 pl-7">
      <span class="title-border pl-3">List</span>
    </v-card-title>
    <v-card-text class="pl-7">
      <div v-if="issues.length < 1" class="pr-2 d-flex justify-center">
        <strong>All issues cmpleted!</strong>
      </div>
      <div v-else>
        <div v-for="(issue, index) of issues" :key="index">
          <v-row>
            <v-col col="1">
              {{ issue.id }}
            </v-col>
            <v-col col="2">
              {{ issue.name }}
            </v-col>
            <v-col col="7">
              {{ issue.description }}
            </v-col>
            <v-col col="2">
              {{ issue.scheduledDay }}
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

export default {
  name: 'IssueList-component',
  computed: {
    ...mapGetters('issues', { issues: 'getIssues' })
  }
}
</script>

<style scoped>
.title-border{
  border-left: 5px solid #e91363;
}
.title-border__small{
  border-right: 2px solid #e91363;
}
</style>
