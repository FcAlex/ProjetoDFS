import Button from '../Button'
import Popup from 'reactjs-popup';
import 'reactjs-popup/dist/index.css';
import './styles.css'
import { forwardRef } from 'react';

const Modal = forwardRef(({ trigger, children, title, footer }, ref) => (
  <Popup trigger={trigger} modal nested forwardRef={ref}> 
    {close => (
      <div className="modal">
        <div className="modal-header">
          <h1>{title}</h1>
          <Button icon="times-circle" className="modal-close" onClick={close}></Button>
        </div>

        <div className="modal-content">
          {children}
        </div>

        <div className="modal-footer">
          {footer}
        </div>
      </div>
    )}
  </Popup>
))

export default Modal