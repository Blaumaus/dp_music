import React, { Component } from "react";
import { withRouter } from 'react-router';
import Genre from 'components/Genre'
class GenreContainer extends Component {
    render() {
        return (
            <Genre />
        )
    }
}
export default withRouter(GenreContainer)