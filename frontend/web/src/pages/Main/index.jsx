import { ToastProvider } from "react-toast-notifications"
import Aside from "../../components/Aside"
import Header from "../../components/Header"
import Footer from "../../components/Footer"

import './styles.css'

const Main = ({ content }) => {
  return (
    <ToastProvider>
      <div className="main">
        <Header />
        <Aside />
        {content}
        <Footer />
      </div>
    </ToastProvider>
  )
}

export default Main