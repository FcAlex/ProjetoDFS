import './styles.css' 

const Button = ({icon, bg, ...props}) => {
  return (
    <button {...props} className={`bg-${bg ? bg : 'transparent'} btn`}>
      { icon ? <i className={`fas fa-${icon} ${props.children ? 'spacing' : ''}`}></i> : false }
      {props.children}
    </button>
  )
}

export default Button