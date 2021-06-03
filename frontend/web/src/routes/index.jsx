import { Switch, Route } from 'react-router-dom'

import PrivateRoute from './private'

import Login from '../pages/Login'
import Main from '../pages/Main'
import Home from '../pages/Home'
import { isAuthenticated } from '../services/auth'
import User from '../pages/User'

function contentMain(Page) {
  return () => <Main content={<Page />}/>
}

function defineHome() {
  return isAuthenticated()
    ? <PrivateRoute exact path="/" component={contentMain(Home)} />
    : <Route exact path="/" component={Login} />
}

const Routes = () => {
  return (
    <Switch>
      {defineHome()}
      <PrivateRoute path="/user" component={contentMain(User)} />
    </Switch>
  )
}

export default Routes