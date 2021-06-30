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

  const styleContent = {
    width: 'auto',
    padding: '5px 10px',
    display: 'flex',
    alignItems: 'center',
    userSelect: 'none'
  }

  if (title) return (
    <Popup
      trigger={btnRender()}
      position="top center"
      on="hover"
      offsetX={15}
      offsetY={-3}
      contentStyle={styleContent}
      keepTooltipInside
      mouseEnterDelay={300}>
      <span className="tooltip"> {title} </span>
    </Popup>
  )

  /* 
  width: auto !important;
   padding: 5px 10px;
   display: flex !important;
   align-items: center;
   user-select: none;
  */
  else return btnRender()
}

export default Button