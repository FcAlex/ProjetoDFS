import './styles.css' 

const Button = ({icon, bg, ...props}) => {
  
  return (
    <button {...props} className={`bg-${bg} btn`}>
      { icon ? <i className={`${icon.version} fa-${icon.name}`}></i> : false }
      {props.children}
    </button>
  )
}

export default Button