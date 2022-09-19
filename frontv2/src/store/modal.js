export default {
  namespaced: true,
  state: {
    isOpen: false,
    isEdit: false
  },
  getters: {
    getIsOpen: state => state.isOpen,
    getEdit: state => state.isEdit
  },
  actions: {
    toogleAction ({ commit }, data) {
      if (data) {
        return commit('toogleWhithEdit', data)
      }
      commit('toogleMutation')
    }
  },
  mutations: {
    toogleMutation (state) {
      state.isOpen = !state.isOpen
      if (state.isEdit) state.isEdit = false
    },
    toogleWhithEdit (state, data) {
      state.EditId = data
      state.isOpen = !state.isOpen
      state.isEdit = !state.isEdit
    }
  }
}
