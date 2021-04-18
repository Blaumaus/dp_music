import React from 'react';
import { Route } from 'react-router';

const ProtectedRoute = ({ component: Component, ...rest }) => {
  return (
    <Route {...rest} render={
      props => /*Here is the checking is the user has rules*/<Component {...rest} {...props} />
    } />
  )
}

export default ProtectedRoute;