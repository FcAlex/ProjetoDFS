import './styles.css' 

const InputIcon = ({icon, label, helper, className, ...props}) => {
  return (
    <div className={`form-group ${className}`}>
      { label ? <label>{label}</label> : false}
      
      <div className="input-group">
        { icon ? <i className={`input-group-text fas fa-${icon}`}></i> : false }
        <input {...props} />
      </div>

      { helper ? <small className="help">{helper}</small> : false }
    </div>
  )
}

export default InputIcon