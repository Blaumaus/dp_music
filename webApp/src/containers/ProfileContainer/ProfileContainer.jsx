import React, { Component } from "react";
import { withRouter } from 'react-router';
import Profile from 'components/Profile'
class ProfileContainer extends Component {
    render() {
        return (
            <Profile />
        )
    }
}
export default withRouter(ProfileContainer)
