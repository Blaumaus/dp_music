import React from "react";
import { withRouter } from 'react-router';
import Genre from 'components/Genre'
import { connect } from "react-redux";
import { Create, Update, Delete, getGenres } from 'redux/reducers/genre-reducer'
import { compose } from 'redux'
import { v4 as uuidv4 } from 'uuid';

class GenreContainer extends React.Component {

    state = {
        //isLoading: true,
        selectedGenre: null,
        action: null,
        disableField: false,
        file: null,
        isAdmin: false
    };
    newGenre = {
        //TODO: without id
        id: uuidv4(),
        name: '',
        image: '',
        description: '',
    };
    componentDidMount() {
        this.props.getGenres();
    };

    handleUpload = event => {
        this.setState({
            file: URL.createObjectURL(event.target.files[0])
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
            file: null
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
            file: genre.image
        })
    }
    handleClickDelete = (genre) => {
        this.setState({
            selectedGenre: genre,
            action: 'delete',
            disableField: true,
            file: genre.image
        })
    }
    handleSubmit = () => {
        const GenreToSubmit = {
            ...this.state.selectedGenre, image: this.state.file
        }
        switch (this.state.action) {

            case 'create': this.props.Create(GenreToSubmit); break;
            case 'update': this.props.Update(GenreToSubmit); break;
            case 'delete': this.props.Delete(this.state.selectedGenre); break;
        }
        this.setState({
            selectedGenre: null,
            action: null,
            disableField: false,
            file: null
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
            file={this.state.file}
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
