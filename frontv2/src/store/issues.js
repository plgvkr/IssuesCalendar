export default {
  namespaced: true,
  state: {
    issues: []
  },
  getters: {
    getIssues: state => state.issues
  },
  mutations: {
    loadIssuesMutation (state, data) {
      state.issue = data
    }
  },
  actions: {
    loadIssuesActions ({ commit }, data) {
      commit('loadIssuesMutation', data)
    }
  }
}
