export default {
  namespaced: true,
  state: {
    issues: [],
    editIssue: {}
  },
  getters: {
    getIssues: state => state.issues,
    getEditIssue: state => state.editIssue
  },
  mutations: {
    loadIssuesMutation (state, data) {
      state.issues = data
    },
    setEditIssueMutation (state, data) {
      /* eslint-disable */
      console.log(data)
      state.editIssue = state.issues.find(item => item.id === data)
      console.log(state.editIssue)
    },
    clearEditIssueMutation (state) {
      state.editIssue = {}
    }
  },
  actions: {
    loadIssuesActions ({ commit }, data) {
      commit('loadIssuesMutation', data)
    },
    setEditIssueAction ({ commit }, data) {
      commit('setEditIssueMutation', data)
    },
    clearEditIssueAction ({ commit }) {
      commit('clearEditIssueMutation')
    }
  }
}
