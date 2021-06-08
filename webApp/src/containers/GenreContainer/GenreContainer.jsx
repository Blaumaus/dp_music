import React from "react";
import { withRouter } from 'react-router';
import Genre from 'components/Genre';
import { connect } from "react-redux";
import { Create, Update, Delete, getGenres } from 'redux/reducers/genre-reducer';
import { getBands } from 'redux/reducers/band-reducer';
import { getUser } from 'redux/reducers/user-reducer';
import { compose } from 'redux';
import CssBaseline from '@material-ui/core/CssBaseline';
import { message } from 'antd';

class GenreContainer extends React.Component {

    state = {
        isLoading: true,
        selectedGenre: null,
        action: null,
        disableField: false,
        ImagefileToView: null,
        ImagefileToSend: null,
        errorMessageTime: 3,
        buttonsback: [
            {
                name: 'Жанри',
                link: '/Genres'
            }
        ]
    };

    newGenre = {
        id: null,
        name: '',
        file: null,
        image: null,
        description: '',
    };

    async componentDidMount() {
        await this.props.getGenres();
        await this.props.getUser();
        this.setState({
            ImagefileToView: null,
        })
        this.hideLoader();
    };

    showLoader = () => this.setState({ isLoading: true });

    hideLoader = () => this.setState({ isLoading: false });

    handleUpload = event => {
        debugger;
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
        });
    };

    handleGenreItemClick = (genre) => {
        const { history } = this.props
        history.push(`/Bands/${genre.id}`);

    };

    handleClickCreate = () => {
        this.setState({
            selectedGenre: this.newGenre,
            action: 'create'
        });
    };

    handleClickEdit = (genre) => {
        debugger;
        this.setState({
            selectedGenre: genre,
            action: 'update',
            ImagefileToView: genre.image
        });
    };

    handleClickDelete = (genre) => {
        this.setState({
            selectedGenre: genre,
            action: 'delete',
            disableField: true,
            ImagefileToView: genre.image
        });
    };

    error = (content) => {
        const { errorMessageTime } = this.state;
        message.error(content, errorMessageTime);
    };

    handleSubmit = async () => {
        this.showLoader();
        const formData = new FormData();
        const { selectedGenre, ImagefileToSend } = this.state;
        formData.append('file', ImagefileToSend)
        formData.set('name', selectedGenre.name)
        formData.set('id', selectedGenre.id)
        formData.set('description', selectedGenre.description)
        switch (this.state.action) {

            case 'create': await this.props.Create(formData); break;
            case 'update': await this.props.Update(formData); break;
            case 'delete':
                await this.props.getBands(selectedGenre.id);
                let isHasChild = this.props.bands.find(band => band.genreId === selectedGenre.id)
                if (isHasChild) {
                    this.error('Неможливо видалити, існують групи, які належать до цього жанру');
                }
                else {
                    await this.props.Delete(selectedGenre);
                }
                break;
            default: alert('Сталась помилка'); break;
        }

        this.setState({
            selectedGenre: null,
            action: null,
            disableField: false,
            ImagefileToView: null,
        });

        await this.props.getGenres();
        this.hideLoader();
    };

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
                        selectedGenre={this.state.selectedGenre}
                        genres={this.props.genres}
                        user={this.props.user}
                        buttonsback={this.state.buttonsback}
                    />
                }
            </CssBaseline>
        )
    }
}

const mapStateToProps = state => {
    return {
        genres: state.genrePage.genres,
        user: state.user.user,
        bands: state.bandPage.bands,
    };
};

export default compose(
    connect(mapStateToProps, { Create, Update, Delete, getGenres, getUser, getBands }),
    withRouter,
)(GenreContainer);
