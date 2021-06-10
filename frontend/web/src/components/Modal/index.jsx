import Content from './Header'
import Header from './Header'
import Footer from './Footer'
import Button from '../Button'
import Popup from 'reactjs-popup';
import 'reactjs-popup/dist/index.css';

const Modal = ({ trigger }) => (
  <Popup trigger={ trigger } modal>
    {close => (
      <div className="modal">
        <Button icon="times-circle" onClick={close}></Button>
        <Header />
        <Content />
        <Footer />
      </div>
    )}
  </Popup>
)

export default Modal