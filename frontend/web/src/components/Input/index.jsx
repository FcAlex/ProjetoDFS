import './styles.css' 
import InputMask from 'react-input-mask'

const InputIcon = ({icon, label, helper, className, ...props}) => {

  if(icon) props.className = props.className ? props.className + ' withIcon' : 'withIcon'

  return (
    <div className={`form-group ${className}`}>
      { label ? <label>{label}</label> : false}
      
      <div className="input-group">
        { icon ? <i className={`input-group-text fas fa-${icon}`}></i> : false }
        { props.mask ? <InputMask {...props} /> : <input {...props} />}
      </div>

      { helper ? <small className="help">{helper}</small> : false }
    </div>
  )
}

export default InputIcon