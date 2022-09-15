import Vue from 'vue'
import VueRouter from 'vue-router'
import AutorizePage from '../views/Autorize.vue'
import IssuesList from '../views/IssuesList.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    redirect: '/login'
  },
  {
    path: '/login',
    component: AutorizePage
  },
  {
    path: '/issues',
    name: 'IssuesList',
    component: IssuesList
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
