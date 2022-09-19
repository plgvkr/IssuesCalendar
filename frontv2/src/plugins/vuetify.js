import '@mdi/font/css/materialdesignicons.css'
import Vue from 'vue'
import Vuetify from 'vuetify/lib/framework'

Vue.use(Vuetify)

export default new Vuetify({
  theme: {
    themes: {
      light: {
        primary: '#2196F3',
        errorColor: '#ff6868',
        acceptColor: '#6ac165'
      }
    }
  },
  icons: {
    iconfont: 'mdi'
  }
})
