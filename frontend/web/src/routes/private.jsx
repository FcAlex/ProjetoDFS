import { Route, Redirect } from 'react-router-dom'
import { isAuthenticated } from '../services/auth'

const PrivateRoute = (props) => {
  const { component: Component, ...rest } = props

  return <Route {...rest} render={ props => 
    isAuthenticated() 
      ? <Component { ...props } />
      : <Redirect to={{pathname: "/", state: {from: props.location} }} />
  } />
}

export default PrivateRoute