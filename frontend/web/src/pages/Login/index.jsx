import { useState } from "react"
import Button from "../../components/Button"
import Input from "../../components/Input"
import api from "../../services/api"
import { signIn } from "../../services/api_test"
import logo from '../../assets/logo.svg'
import { useToasts } from 'react-toast-notifications'

import './styles.css'
import useAuth from "../../hooks/useAuth"

const INITIAL_VALUE = {
  email: "",
  password: "",
}

const Login = () => {

  const [userData, setUserData] = useState(INITIAL_VALUE)
  const { addToast } = useToasts()

  const { login } = useAuth()

  function toastError(msg) {
    addToast(msg, {
      appearance: 'error',
      autoDismiss: true,
    })
  }

  function setEmail(event) {
    setUserData({ ...userData, email: event.target.value })
  }

  function setPassword(event) {
    setUserData({ ...userData, password: event.target.value })
  }

  async function handleLogin(event) {
    event.preventDefault();
    const { email, password } = userData

    if (!email || !password) {
      toastError("Preencha e-mail e senha para continuar")
    } else {
      try {
        const response = await api.post("/authentication", { email, password })
        // const response = await signIn() // teste sem backend
        const { token, user } = response?.data?.result
        // const { token, user } = response.result
        login(token, user)
        window.location.reload()
      } catch (err) {
        toastError("Houve um problema com o login, verifique suas credenciais.")
      }
    }
  }

  function handleIconPassword(e) {
    const input = document.getElementById("iPassword")
    if(e.target.classList.contains("fa-eye-slash")){
      input.type = "text"
      e.target.classList.replace("fa-eye-slash", "fa-eye")
    } else {
      input.type = "password"
      e.target.classList.replace("fa-eye", "fa-eye-slash")
    }
  }

  return (
    <div className="login">
      <img src={logo} alt="Logo SisVendas"/>
      <form className="form" onSubmit={handleLogin}>
        <h1>Faça Login para continuar</h1>
        <Input icon="user" value={login.email} onChange={setEmail}
          placeholder="e.g. alex@example.com" type="email" label="Seu Email" />
        <div className="handleVisiblePassword">
          <Input id="iPassword"
            icon="lock"
            value={login.password} 
            onChange={setPassword} 
            placeholder="Digite sua senha" 
            type="password" label="Sua Senha" />

          <i className="fas fa-eye-slash" onClick={handleIconPassword}></i>
        </div>

        <Button icon="sign-in-alt" bg="blue" type="submit">
          Entrar
        </Button>
      </form>
    </div>
  )
}

export default Login