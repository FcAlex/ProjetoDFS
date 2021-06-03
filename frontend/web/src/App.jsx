import { ToastProvider } from 'react-toast-notifications';
import RouteSign from './routes/login'

const App = () => (
  <ToastProvider>
    <RouteSign />
  </ToastProvider>
)

export default App;
