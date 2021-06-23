import axios from "axios"
import { getToken, logout } from "./auth"

const api = axios.create({
  baseURL: "https://localhost:5001/api",
  headers: {
    "Content-type": "application/json"
  },

})

api.interceptors.request.use(async config => {
  const token = getToken()

  if (token) config.headers.Authorization = `Bearer ${token}`
  
  return config;
});

export default api