import { Switch, Route, BrowserRouter } from 'react-router-dom'
import Login from '../pages/Login'
import Main from '../pages/Main'
import { isAuthenticated } from '../services/auth'
import PrivateRoute from './private'

function defineHome() {
  return isAuthenticated()
    ? <PrivateRoute exact path="/" component={Main} />
    : <Route exact path="/" component={Login} />
}

const Routes = () => {
  return (
    <BrowserRouter>
      <Switch>
        {defineHome()}
        <Route path="*" component={() => <h1>Page not found</h1>} />
      </Switch>
    </BrowserRouter>
  )
}

export default Routes