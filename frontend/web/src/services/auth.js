export const TOKEN_KEY = "@Token"
export const DATA_KEY = "@User"

export const isAuthenticated = () => localStorage.getItem(TOKEN_KEY) !== null

export const getToken = () => localStorage.getItem(TOKEN_KEY)

export const login = (token, data) => {
  localStorage.setItem(TOKEN_KEY, token)
  localStorage.setItem(DATA_KEY, JSON.stringify(data))
}

export const getData = () => JSON.parse(localStorage.getItem(DATA_KEY))

export const logout = () => {
  localStorage.removeItem(TOKEN_KEY)
  localStorage.removeItem(DATA_KEY)
}