import { ToastProvider } from "react-toast-notifications"
import Aside from "../../components/Aside"
import Header from "../../components/Header"
import Footer from "../../components/Footer"

const Main = ({ content }) => {
  return (
    <ToastProvider>
      <Header />
      <Aside />
      { content }
      <Footer />
    </ToastProvider>
  )
}

export default Main