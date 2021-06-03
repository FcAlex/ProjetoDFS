import { Redirect, Route } from "react-router"
import useAuth from "../hooks/useAuth"

const PrivateRoute = ({ component: Component, ...props }) => {

  const { signed } = useAuth()

  return (
    <Route
      {...props}
      render={() => signed
        ? <Component {...props} />
        : <Redirect to='/' />
      }
    />
  )
}

export default PrivateRoute