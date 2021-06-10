import 'reactjs-popup/dist/index.css';
import './styles.css'
import Popup from 'reactjs-popup';

const Button = ({ icon, bg, title, ...props }) => {

  function btnRender() {
    return (
      <button {...props} className={`bg-${bg ? bg : 'transparent'} btn`}>
        {icon ? <i className={`fas fa-${icon} ${props.children ? 'spacing' : ''}`}></i> : false}
        {props.children}
      </button>
    )
  }

  if (title) return (
    <Popup trigger={btnRender()} position="bottom center" on="hover">
      <span className="tooltip"> {title} </span>
    </Popup>
  )
  else return btnRender()
}

export default Button