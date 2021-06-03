import { ToastProvider } from "react-toast-notifications"
import Header from "../../components/Header"

const Main = props => {
  return (
    <ToastProvider>
      <Header />
    </ToastProvider>
  )
}

export default Main