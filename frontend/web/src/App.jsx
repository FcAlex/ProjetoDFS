import { ToastProvider } from 'react-toast-notifications';
import Routes from './routes'

const App = () => (
  <ToastProvider>
    <Routes />
  </ToastProvider>
)

export default App;
