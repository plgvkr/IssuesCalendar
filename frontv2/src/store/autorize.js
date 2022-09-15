export default {
  namespaced: true,
  state: {
    token: ''
  },
  getters: {
    getToken: state => state.token
  },
  actions: {
    setTokenAction ({ commit }, data) {
      commit('setTokenMutation', data)
    }
  },
  mutations: {
    setTokenMutation (state, data) {
      state.token = data
    }
  }
}
