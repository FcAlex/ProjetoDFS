import Content from './Header'
import Header from './Header'
import Footer from './Footer'

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