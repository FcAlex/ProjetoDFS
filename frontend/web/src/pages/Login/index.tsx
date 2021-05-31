import Button from "../../components/Button"
import Input from "../../components/Input"
import './styles.css'

const Login = () => {
  return (
    <div className="login">
      <h1>Faça Login para continuar</h1>
      <form className="form">
        <Input icon={{name: "user", version: "fa"}} 
          placeholder="e.g. alex@example.com" type="email" label="Seu Email" />
        <Input icon={{name: "lock", version: "fa"}} 
          placeholder="Digite sua senha" type="password" label="Sua Senha"/>

        <Button icon={{name: "sign-in-alt", version: "fas"}} bg="blue">
          Entrar
        </Button>

      </form>
    </div>
  )
}

export default Login