import { ToastProvider } from "react-toast-notifications"
import Aside from "../../components/Aside"
import Header from "../../components/Header"

import './styles.css'

const Main = ({ content }) => {
  return (
    <ToastProvider>
      <div className="main">
        <Header />
        <Aside />
        {content}
      </div>
    </ToastProvider>
  )
}

export default Main