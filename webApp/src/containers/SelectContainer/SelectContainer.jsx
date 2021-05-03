import React from "react";
import { withRouter } from 'react-router';
import Select from 'components/Select'
import { compose } from 'redux'
class SelectContainer extends React.Component {
    componentDidMount() {

    };

    handleAllCompositionClick = () => {
        const { history } = this.props
        const { bandId } = this.props.match.params
        history.push(`/Compositions/${bandId}`)
    }
    handleAlbumClick = () => {
        const { history } = this.props
        const { bandId } = this.props.match.params
        history.push(`/Albums/${bandId}`)
    }

    handleButtonBackClick = () => {
        this.setState({
            selectedSelect: null,
            file: null
        })
    }

    render() {
        return <Select
            handleAllCompositionClick={this.handleAllCompositionClick}
            handleAlbumClick={this.handleAlbumClick}
        />
    }
}


export default compose(
    withRouter,
)(SelectContainer);
