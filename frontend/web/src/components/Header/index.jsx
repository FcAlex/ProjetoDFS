import Button from '../Button'

import './styles.css'
import useAuth from '../../hooks/useAuth'

const Header = () => {

  const { logout, getData } = useAuth()

  function handleLogout() {
    logout()
    window.location.reload()
  }

  return (
    <header className="header">
      <div className="logo">
        <a href="/">
          <div></div>
        </a>
      </div>
      <div className="welcome">
        <i className="far fa-user-circle"></i>
        <span>Bem vindo, <strong>{getData()?.name}</strong></span>
      </div>
      <Button
        icon="sign-out-alt"
        bg="transparent"
        onClick={handleLogout} />
    </header>
  )
}

export default Header