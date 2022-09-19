import Vue from 'vue'
import Vuex from 'vuex'
import autorize from './autorize'
import issues from './issues'
import modal from './modal'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
  },
  getters: {
  },
  mutations: {
  },
  actions: {
  },
  modules: {
    autorize,
    issues,
    modal
  }
})
