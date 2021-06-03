import { ToastProvider } from "react-toast-notifications"
import Header from "../../components/Header"
import Routes from "../../routes"
import Aside from "../Aside"
import Footer from "../Footer"

const Main = props => {
  return (
    <ToastProvider>
      <Header />
      <Aside />
      <Routes />
      <Footer />
    </ToastProvider>
  )
}

export default Main