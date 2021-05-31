import { ButtonHTMLAttributes } from 'react'
import './styles.css' 

type IconType = {
  name: string,
  version: string
}

interface Props extends ButtonHTMLAttributes<HTMLButtonElement> {
  icon?: IconType,
  bg?: string
}

const Button = ({icon, bg, ...props}: Props) => {
  console.log(icon)
  return (
    <button {...props} className={`bg-${bg} btn`}>
      { icon ? <i className={`${icon.version} fa-${icon.name}`}></i> : false }
      {props.children}
    </button>
  )
}

export default Button