import { logout } from "../../services/auth"
import Button from '../Button'
import logo_sx from '../../assets/logo.svg'

import './styles.css'

const Header = () => {

  function handleLogout() {
    logout()
    window.location.reload()
  }

  return (
    <header className="header">
      <div>
        <img src={logo_sx} alt="Logo SisVendas" />
      </div>
      <Button
        icon={{ name: "sign-out-alt", version: "fas" }} 
        bg="transparent" 
        onClick={handleLogout} />
    </header>
  )
}

export default Header