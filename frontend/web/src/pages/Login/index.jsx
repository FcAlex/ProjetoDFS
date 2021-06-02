import { useState } from "react"
import Button from "../../components/Button"
import Input from "../../components/Input"
import api from "../../services/api"
import { login } from "../../services/auth"

import './styles.css'

const INITIAL_VALUE = {
  email: "",
  password: "",
  error: ""
}

const Login = (props) => {

  const [userData, setUserData] = useState(INITIAL_VALUE)

  function setError(error) {
    setUserData({ ...userData, error })
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

    console.log(userData)

    if (!email || !password) {
      setError("Preencha e-mail e senha para continuar")
    } else {
      try {
        const response = await api.post("/authentication", { email, password })
        login(response.data.token)
        props.history.push("/app")
      } catch (error) {
        console.log("aqui", error)
        setError("Houve um problema com o login, verifique suas credenciais.")
      }
    }
  }

  return (
    <div className="login">
      {/* <img src="./../../assets/logo.svg" alt="Logo SisVendas"/> */}
      <h1>Faça Login para continuar</h1>
      <form className="form" onSubmit={handleLogin}>
        <Input icon={{ name: "user", version: "fa" }} value={login.email} onChange={setEmail}
          placeholder="e.g. alex@example.com" type="email" label="Seu Email" />
        <Input icon={{ name: "lock", version: "fa" }} value={login.password} onChange={setPassword}
          placeholder="Digite sua senha" type="password" label="Sua Senha" />

        <Button icon={{ name: "sign-in-alt", version: "fas" }} bg="blue" type="submit">
          Entrar
        </Button>

      </form>
    </div>
  )
}

export default Login