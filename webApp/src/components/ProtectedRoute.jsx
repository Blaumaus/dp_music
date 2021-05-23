import React, { Fragment } from "react";
import AuthenticationService from './AuthenticationService';
import { withRouter, Redirect } from 'react-router';
import { Route } from 'react-router-dom';

class ProtectedRoute extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      isAuthenticated: false,
      isLoading: false
    }
  }
  async componentDidMount() {
    this.setState({ isLoading: true });

    const isAuthenticated = await AuthenticationService.checkAuthenticated();

    if (!isAuthenticated) {
      this.props.history.push('/SignIn');
      return;
    }
    this.setState({
      isAuthenticated: isAuthenticated,
      isLoading: false
    })
  }

  render() {
    if (this.state.isLoading)
      return <Fragment />

    if (this.state.isAuthenticated) {
      const { component: Component, ...rest } = this.props;

      if (rest.path !== "/*")
        return <Route {...rest} render={
          props => <Component {...rest} {...props} />
        } />
      else
        return <Redirect to="/Genres" />

    }

    return <Fragment />
  }
}
export default withRouter(ProtectedRoute);