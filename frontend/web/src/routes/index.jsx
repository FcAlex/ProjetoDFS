import { Switch, Route } from 'react-router-dom'

import PrivateRoute from './private'

import Login from '../pages/Login'
import Main from '../pages/Main'
import Home from '../pages/Home'
import { isAuthenticated } from '../services/auth'

function defineHome() {
  return isAuthenticated()
    ? <PrivateRoute exact path="/" component={Main} />
    : <Route exact path="/" component={Login} />
}

const Routes = props => {
  return (
    <Switch>
      {defineHome()}
      <PrivateRoute path="/home" component={Home} />
    </Switch>
  )
}

export default Routes