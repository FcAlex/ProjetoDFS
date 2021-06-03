import { logout } from "../../services/auth"
import Button from '../Button'
import logo_sx from '../../assets/logo-sx.svg'

import './styles.css'

const Header = () => {

  function handleLogout() {
    logout()
    window.location.reload()
  }

  return (
    <header className="header">
      <img src={logo_sx} alt="Logo SisVendas" />
      <Button
        icon={{name: "sign-out-alt", version: "fas"}} 
        bg="transparent" 
        onClick={handleLogout} />
    </header>
  )
}

export default Header