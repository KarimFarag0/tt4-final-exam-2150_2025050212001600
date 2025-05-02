// src/axios.js

import axios from 'axios';

const isDevelopment = import.meta.env.MODE === 'development';

const axiosInstance = axios.create({
    baseURL: 'http://localhost:5180', // <-- Use HTTP, not HTTPS
  });

export default axiosInstance;