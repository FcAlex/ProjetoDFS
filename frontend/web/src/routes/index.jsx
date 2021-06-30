import { Switch, Route } from 'react-router-dom'

import PrivateRoute from './private'

import Login from '../pages/Login'
import Main from '../pages/Main'
import Home from '../pages/Home'
import { isAuthenticated } from '../services/auth'
import Order from '../pages/Orders'
import Purchase from '../pages/Purchase'

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
      <PrivateRoute path="/purchase" component={contentMain(Purchase)} />
      <PrivateRoute path="/orders" component={contentMain(Order)} />
    </Switch>
  )
}

export default Routes