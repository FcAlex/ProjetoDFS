import { BrowserRouter, Route, Switch } from "react-router-dom"
import PrivateRoute from "./private"


const Routes = props => {
  return (
    <BrowserRouter>
      <Switch>
        <PrivateRoute exact path="/company" component={() => <h1>Company</h1>} />
        <PrivateRoute exact path="/user" component={() => <h1>User</h1>} />
        <Route path="*" component={() => <h1>Page not found</h1>} />
      </Switch>
    </BrowserRouter>
  )
}

export default Routes