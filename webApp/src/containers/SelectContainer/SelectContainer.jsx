import React from "react";
import { withRouter } from 'react-router';
import Select from 'components/Select'
import { compose } from 'redux'
class SelectContainer extends React.Component {

    state = {
        buttonsback: [
            {
                name: 'Усі Жанри',
                link: '/Genres'
            },
            {
                name: 'Групи',
                link: `/Bands/${this.props.match.params.genreId}`
            },
            {
                name: 'Вибір',
                link: `#`
            },
        ]
    };

    componentDidMount() {

    };

    handleAllCompositionClick = () => {
        const { history } = this.props
        const { bandId, albumId, genreId } = this.props.match.params
        history.push(`/Compositions/${bandId}/${albumId}/${genreId}`)
    }
    handleAlbumClick = () => {
        const { history } = this.props
        const { bandId, genreId } = this.props.match.params
        history.push(`/Albums/${bandId}/${genreId}`)
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
            buttonsback={this.state.buttonsback}
        />
    }
}


export default compose(
    withRouter,
)(SelectContainer);
