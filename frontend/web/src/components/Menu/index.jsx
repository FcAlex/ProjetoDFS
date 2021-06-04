import MenuItem from './MenuItem'
import MenuTree from './MenuTree'
import './styles.css'

const Menu = props => {
  return (
    <ul className="menu">
      <MenuItem icon="user" label="Cadastro" />
      <MenuTree icon="shopping-cart" label="Compras">
        <MenuItem path="/menu" label="Comprar" icon="thumbtack" />
        <MenuItem path="/menu" label="Pedidos" icon="thumbtack" />
      </MenuTree>
    </ul>
  )
}

export default Menu