import Vue from 'vue'
import App from './App.vue'
import router from './router'
import './assets/css/index.css'
import DataService from './services/DataService.js';
import './shared/GlobalFilters'
import 'element-ui/lib/theme-chalk/index.css';

import Pagination from 'vue-pagination-2';
Vue.component('pagination', Pagination);


import scanner from 'scanner.js'
Vue.use(scanner)

Vue.config.productionTip = false

Vue.prototype.$http = DataService;
Vue.prototype.$authenticatedUser = {
    userId: '',
    fullName: '',
    email: '',
    role: ''
};

new Vue({
    router,
    render: h => h(App)
}).$mount('#app')