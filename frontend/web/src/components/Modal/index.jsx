import Button from '../Button'
import 'reactjs-popup/dist/index.css';
import './styles.css'
import If from '../../helpers/If'

const Modal = ({ show = false, children, title, footer, close }) => {

  document.addEventListener('keydown', e => {
    if (e.key === 'Escape')
      close(true)
  })

  return (
    <If test={show}>
      <div>
        <div className="modal">
          <div className="modal-header">
            <h1>{title}</h1>
            <Button icon="times-circle" onClick={e => close(true)}></Button>
          </div>

          <div className="modal-content">
            {children}
          </div>

          <div className="modal-footer">
            {footer}
          </div>
        </div>
      </div>
    </If>
  )
}

export default Modal