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

api.interceptors.response.use(response => response, error => {

  if (error.response.status === 401) {
    logout()
    window.location.reload();
  }
})

export default api