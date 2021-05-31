import { InputHTMLAttributes } from 'react'
import './styles.css' 

type IconType = {
  name: string,
  version: string
}

interface Props extends InputHTMLAttributes<HTMLInputElement> {
  icon?: IconType
  label?: string
  helper?: string
}

const InputIcon = ({icon, label, helper, ...props}: Props) => {
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