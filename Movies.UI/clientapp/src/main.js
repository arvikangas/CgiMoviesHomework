import Vue from 'vue'
import App from './App.vue'
import store from './store';
import router from "./router";

import FoundationCss from 'foundation-sites/dist/css/foundation.min.css'
import FoundationJs from 'foundation-sites/dist/js/foundation.js'    

Vue.config.productionTip = false


new Vue({
    FoundationCss,
    FoundationJs,
    store,
    router,
    render: h => h(App),
}).$mount('#app')
