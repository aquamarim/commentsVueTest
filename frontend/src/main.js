import Vue from "vue";
import App from "./App.vue";
import vuetify from "./plugins/vuetify";
import axios from 'axios'

const api = axios.create({
    baseURL: 'https://localhost:5442/api/'
})

const axiosPlugin = {
    install(Vue){
        Vue.prototype.$api = api
    }
}

Vue.use(axiosPlugin);
Vue.config.productionTip = false;

new Vue({
  vuetify,
  render: (h) => h(App),
}).$mount("#app");
