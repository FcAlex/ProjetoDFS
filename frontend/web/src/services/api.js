import axios from "axios"
import { getToken } from "./auth"

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

export const signInService = () => { // testes
    
    return new Promise( resolve => {
        
        setTimeout( () => {
            resolve({
                token: 'jk12h3j21h3jk212h3jk12h3jkh12j3kh12k123hh21g3f12fdfasfas3',
                user: {
                    name: 'Alex Sousa',
                    email: 'alex@example.com',
                }
            });
        }, 1000);
    });
}

export default api