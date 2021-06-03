import { BrowserRouter } from 'react-router-dom';
import { ToastProvider } from 'react-toast-notifications';
import { AuthProvider } from './contexts/auth';
import Routes from './routes';

const App = () => (
  <BrowserRouter>
    <AuthProvider>
      <ToastProvider> 
        <Routes />
      </ToastProvider>
    </AuthProvider>
  </BrowserRouter>
)

export default App;
