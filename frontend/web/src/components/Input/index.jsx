import './styles.css' 

const InputIcon = ({icon, label, helper, ...props}) => {
  return (
    <div className="form-group">
      { label ? <label>{label}</label> : false}
      
      <div className="input-group">
        { icon ? <i className={`input-group-text ${icon.version} fa-${icon.name}`}></i> : false }
        <input {...props} />
      </div>

      { helper ? <small className="help">{helper}</small> : false }
    </div>
  )
}

export default InputIcon