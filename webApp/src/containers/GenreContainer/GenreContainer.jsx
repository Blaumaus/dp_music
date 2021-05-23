import React from "react";
import { withRouter } from 'react-router';
import Genre from 'components/Genre'
import { connect } from "react-redux";
import { Create, Update, Delete, getGenres } from 'redux/reducers/genre-reducer'
import { compose } from 'redux'
import CssBaseline from '@material-ui/core/CssBaseline';
class GenreContainer extends React.Component {

    state = {
        isLoading: true,
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
        this.hideLoader();
    };
    componentDidUpdate(prevProps) {
        if (this.props.genres.length !== prevProps.genres.length) {
            this.showLoader();
            this.props.getGenres();
            this.hideLoader();
        }
      }
    showLoader = () => this.setState({ isLoading: true });

    hideLoader = () => this.setState({ isLoading: false });

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
        formData.append('file', ImagefileToSend)
        formData.set('name', selectedGenre.name)
        formData.set('description', selectedGenre.description)
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
        const { isLoading } = this.state;
        return (
            <CssBaseline>
                {
                    !isLoading && <Genre
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
            </CssBaseline>
        )
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
