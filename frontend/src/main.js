import './assets/main.css'

import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import axios from './axios' // Import the axios instance

const app = createApp(App)

app.config.globalProperties.$axios = axios // Make Axios globally available

app.use(router)

app.mount('#app')