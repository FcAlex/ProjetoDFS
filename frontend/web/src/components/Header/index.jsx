import { logout } from "../../services/auth"
import Button from '../Button'
import logo_sx from '../../assets/logo-sx.svg'

const Header = () => {

  function handleLogout() {
    logout()
    window.location.reload()
  }

  return (
    <div>
      <img src={logo_sx} alt="Logo SisVendas" />
      <Button 
        icon={{name: "sign-out-alt", version: "fas"}} 
        bg="transparent" 
        onClick={handleLogout} />
    </div>
  )
}

export default Header