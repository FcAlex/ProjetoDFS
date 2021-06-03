import { useState } from "react"
import Button from "../../components/Button"
import Input from "../../components/Input"
import api from "../../services/api"
import { login } from "../../services/auth"
import logo from '../../assets/logo.svg'
import { useToasts } from 'react-toast-notifications'

import './styles.css'

const INITIAL_VALUE = {
  email: "",
  password: "",
  error: {msg: "", status: false}
}

const Login = () => {

  const [userData, setUserData] = useState(INITIAL_VALUE)
  const { addToast} = useToasts()

  function handleError(status, msg) {
    setUserData({ ...userData, error: { msg, status } })
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
      handleError(true, "Preencha e-mail e senha para continuar")
    } else {
      try {
        const response = await api.post("/authentication", { email, password })
        login(response.data.token)
        handleError(false)
        window.location.reload()
        return
      } catch {
        handleError(true, "Houve um problema com o login, verifique suas credenciais.")
      }
    }

    addToast(userData.error.msg, {
      appearance: 'error',
      autoDismiss: true,
    })
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
        <Input icon={{ name: "user", version: "fa" }} value={login.email} onChange={setEmail}
          placeholder="e.g. alex@example.com" type="email" label="Seu Email" />
        <div className="handleVisiblePassword">
          <Input id="iPassword"
            icon={{ name: "lock", version: "fa" }} 
            value={login.password} 
            onChange={setPassword} 
            placeholder="Digite sua senha" 
            type="password" label="Sua Senha" />

          <i className="fas fa-eye-slash" onClick={handleIconPassword}></i>
        </div>

        <Button icon={{ name: "sign-in-alt", version: "fas" }} bg="blue" type="submit">
          Entrar
        </Button>
      </form>
    </div>
  )
}

export default Login