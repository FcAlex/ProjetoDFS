import './styles.css' 

const Button = ({icon, bg, ...props}) => {
  const classes = `${icon.version} fa-${icon.name} ${props.children ? 'spacing' : ''}`

  return (
    <button {...props} className={`bg-${bg} btn`}>
      { icon ? <i className={classes}></i> : false }
      {props.children}
    </button>
  )
}

export default Button