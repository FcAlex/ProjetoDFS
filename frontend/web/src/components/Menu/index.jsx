import { useState } from 'react'
import MenuItem from './MenuItem'
import MenuTree from './MenuTree'
import './styles.css'

const Menu = props => {
  const [menuVisible, setMenuVisible] = useState(false)

  function handleMenu(e) {
    const menu = document.getElementById("iMenu")
    const classes = Array.from(menu.classList)
    if(!menuVisible) {
      classes.push('menuNone')
      setMenuVisible(true)
    } else {
      classes.pop()
      setMenuVisible(false)
    }

    menu.classList = classes
  }

  return (
    <>
      <span className="tituloMenu" onClick={handleMenu}>Menu <i className="fas fa-bars"></i> </span>
      <ul className="menu" id="iMenu">
        <MenuItem icon="user" label="Cadastro" />
        <MenuTree icon="shopping-cart" label="Compras">
          <MenuItem path="/purchase" label="Comprar" icon="thumbtack" />
          <MenuItem path="/orders" label="Pedidos" icon="thumbtack" />
        </MenuTree>
      </ul>
    </>
  )
}

export default Menu