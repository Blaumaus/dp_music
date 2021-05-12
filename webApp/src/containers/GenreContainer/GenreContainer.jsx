import React from "react";
import { withRouter } from 'react-router';
import Genre from 'components/Genre'
import { connect } from "react-redux";
import { Create, Update, Delete, getGenres } from 'redux/reducers/genre-reducer'
import { compose } from 'redux'
class GenreContainer extends React.Component {

    state = {
        //isLoading: true,
        selectedGenre: null,
        action: null,
        disableField: false,
        ImagefileToView: null,
        ImagefileToSend: null,
        isAdmin: true
    };
    newGenre = {
        id: null,
        name: '',
        file: null,
        image: null,
        description: '',
    };
    componentDidMount() {
        this.props.getGenres();
        this.setState({
            ImagefileToView: null
        })
    };

    handleUpload = event => {
        this.setState({
            ImagefileToView: URL.createObjectURL(event.target.files[0]),
            ImagefileToSend: event.target.files[0]
        })
    };
    onChange = (field, value) => {
        this.setState({
            selectedGenre: { ...this.state.selectedGenre, [field]: value }
        })
    };
    handleButtonBackClick = () => {
        this.setState({
            selectedGenre: null,
            disableField: false,
            ImagefileToView: null
        })
    }
    handleGenreItemClick = (genre) => {
        const { history } = this.props
        history.push(`/Bands/${genre.id}`)

    }
    handleClickCreate = () => {
        this.setState({
            selectedGenre: this.newGenre,
            action: 'create'
        })
    }
    handleClickEdit = (genre) => {
        this.setState({
            selectedGenre: genre,
            action: 'update',
            ImagefileToView: genre.image
        })
    }
    handleClickDelete = (genre) => {
        this.setState({
            selectedGenre: genre,
            action: 'delete',
            disableField: true,
            ImagefileToView: genre.image
        })
    }
    handleSubmit = () => {
        const formData = new FormData();
        const { selectedGenre, ImagefileToSend } = this.state;
        formData.append('genre', selectedGenre);
        formData.append('file', ImagefileToSend)
     
        switch (this.state.action) {

            case 'create': this.props.Create(formData); break;
            case 'update': this.props.Update(formData); break;
            case 'delete': this.props.Delete(this.state.selectedGenre); break;
        }
        this.setState({
            selectedGenre: null,
            action: null,
            disableField: false,
        })

    }

    render() {
        return <Genre
            handleUpload={this.handleUpload}
            onChange={this.onChange}
            handleClickCreate={this.handleClickCreate}
            handleClickEdit={this.handleClickEdit}
            handleClickDelete={this.handleClickDelete}
            handleSubmit={this.handleSubmit}
            handleButtonBackClick={this.handleButtonBackClick}
            handleGenreItemClick={this.handleGenreItemClick}
            disableField={this.state.disableField}
            ImagefileToView={this.state.ImagefileToView}
            isAdmin={this.state.isAdmin}
            selectedGenre={this.state.selectedGenre}
            genres={this.props.genres}
        />
    }
}

const mapStateToProps = state => {
    return {
        genres: state.genrePage.genres

    };
};

export default compose(
    connect(mapStateToProps, { Create, Update, Delete, getGenres }),
    withRouter,
)(GenreContainer);
