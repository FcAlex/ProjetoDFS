import { Switch, Route, BrowserRouter, Redirect } from 'react-router-dom'
import Login from '../pages/Login'
import { isAuthenticated } from '../services/auth'

const PrivateRoute = (props) => {
  const { component: Component, ...rest } = props

  return <Route {...rest} render={ props => 
    isAuthenticated() 
      ? <Component { ...props } />
      : <Redirect to={{pathname: "/", state: {from: props.location} }} />
  } />
}

const Routes = () => {
  return (
    <BrowserRouter>
      <Switch>
        <Route exact path="/" component={Login} />
        <PrivateRoute path="/app" component={() => <h1>App</h1>}></PrivateRoute>
        <Route path="*" component={() => <h1>Page not found</h1>} />
      </Switch>
    </BrowserRouter>
  )
}

export default Routes