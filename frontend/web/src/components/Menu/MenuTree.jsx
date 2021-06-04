import { useState } from "react"

const MenuTree = ({ children, label, icon }) => {
  const [toggleMenu, setToggleMenu] = useState(false)
  const [direction, setDirection] = useState('left')

  function toggleSubMenu() {
    setToggleMenu(!toggleMenu)
    setDirection(direction === 'left' ? 'right' : 'left')
  }

  return (
    <li className="item tree">
      <span className="item-title" onClick={toggleSubMenu}>

        <i className={`input-group-text fas fa-${icon}`}></i>
        { label }
        <i className={`fa fa-angle-${direction} iconToggle`}></i>

      </span>

      {toggleMenu ? <ul>{children}</ul> : ''}
    </li>
  )
}

export default MenuTree