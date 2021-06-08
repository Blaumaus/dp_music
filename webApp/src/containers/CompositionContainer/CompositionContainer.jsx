import React from "react";
import { withRouter } from 'react-router';
import Composition from 'components/Composition';
import { connect } from "react-redux";
import { Create, Update, Delete, getCompositions, SortCompositions } from 'redux/reducers/composition-reducer';
import { compose } from 'redux';
import { getBands } from 'redux/reducers/band-reducer';
import { getAlbums } from 'redux/reducers/album-reducer';
import { getGenres } from 'redux/reducers/genre-reducer';
import { getUser } from 'redux/reducers/user-reducer';
import CssBaseline from '@material-ui/core/CssBaseline';

class CompositionContainer extends React.Component {

    state = {
        isLoading: true,
        selectedComposition: null,
        action: null,
        disableField: false,
        compositionfileToView: null,
        compositionfileToSend: null,
        buttonsback: [
            {
                name: 'Жанри',
                link: '/Genres'
            },
            {
                name: 'Групи',
                link: `/Bands/${this.props.match.params.genreId}`
            },
            {
                name: 'Вибір',
                link: `/Select/${this.props.match.params.bandId}/${this.props.match.params.genreId}`
            },
            {
                name: 'Композиції',
                link: `#`
            }
        ]
    };

    newComposition = {
        name: '',
        compositionFile: '',
        description: '',
        genreId: this.props.match.params.genreId,
        bandId: this.props.match.params.bandId,
        albumId: this.props.match.params.albumId,
        lyrics: '',
        year: '',
        filePath: ''
    };

    showLoader = () => this.setState({ isLoading: true });

    hideLoader = () => this.setState({ isLoading: false });

    async componentDidMount() {
        const { bandId, albumId, genreId } = this.props.match.params
        await this.props.getUser();
        await this.props.getGenres();
        await this.props.getBands(genreId);
        await this.props.getAlbums(bandId);
        await this.props.getCompositions(albumId, bandId);

        this.setState({
            compositionfileToView: null,
        })

        this.hideLoader();
    };

    handleUpload = event => {
        if (event.target.files[0]) {
            this.setState({
                compositionfileToView: URL.createObjectURL(event.target.files[0]),
                compositionfileToSend: event.target.files[0]
            })
        }

    };

    onChange = (field, value) => {
        this.setState({
            selectedComposition: { ...this.state.selectedComposition, [field]: value }
        })
    };

    onChangeGenreSelector = async (field, value) => {
        await this.props.getBands(value);
        this.setState({
            selectedComposition: { ...this.state.selectedComposition, [field]: value },
        })
        if (this.props.bands.length != 0) {
            await this.props.getAlbums(this.props.bands[0].id);
        }

    };

    onChangeBandSelector = async (field, value) => {
        await this.props.getAlbums(value);
        this.setState({
            selectedComposition: { ...this.state.selectedComposition, [field]: value }
        })
    };

    handleButtonBackClick = () => {
        this.setState({
            selectedComposition: null,
            disableField: false,
            compositionfileToView: null
        })
    };

    handleClickCreate = () => {
        this.setState({
            selectedComposition: this.newComposition,
            action: 'create'
        })
    }

    handleClickEdit = (composition) => {
        this.setState({
            selectedComposition: composition,
            action: 'update',
            compositionfileToView: composition.filePath
        })
        console.log(composition);
    }

    handleClickDelete = (composition) => {
        this.setState({
            selectedComposition: composition,
            action: 'delete',
            disableField: true,
            compositionfileToView: composition.filePath
        })
    }

    handleSortAlphabetically = () => {
        this.showLoader();
        this.props.SortCompositions(this.props.compositions);
        this.hideLoader();
    }

    handleSubmit = async () => {
        this.showLoader();
        const { selectedComposition } = this.state;

        if (selectedComposition.albumId === 'undefined') {
            selectedComposition.albumId = this.props.albums[0].id;
        }
        const formData = new FormData();
        const { compositionfileToSend } = this.state;
        formData.append('compositionFile', compositionfileToSend)
        formData.set('id', selectedComposition.id)
        formData.set('name', selectedComposition.name)
        formData.set('year', selectedComposition.year)
        formData.set('genreId', selectedComposition.genreId)
        formData.set('bandId', selectedComposition.bandId)
        formData.set('albumId', selectedComposition.albumId)
        formData.set('description', selectedComposition.description);
        formData.set('lyrics', selectedComposition.lyrics);

        switch (this.state.action) {

            case 'create': await this.props.Create(formData); break;
            case 'update': await this.props.Update(formData); break;
            case 'delete': await this.props.Delete(selectedComposition); break;
            default: alert('Сталась помилка'); break;
        }

        this.setState({
            selectedComposition: null,
            action: null,
            disableField: false,
            compositionfileToView: null,
        })
        const { bandId, albumId } = this.props.match.params;
        this.props.getCompositions(albumId, bandId).then(this.hideLoader());
    }

    handleCompositionItemClick = () => { }

    render() {
        const { isLoading } = this.state;
        return (
            <CssBaseline>
                {
                    !isLoading && <Composition
                        handleUpload={this.handleUpload}
                        onChange={this.onChange}
                        handleClickCreate={this.handleClickCreate}
                        handleClickEdit={this.handleClickEdit}
                        handleClickDelete={this.handleClickDelete}
                        handleSubmit={this.handleSubmit}
                        handleButtonBackClick={this.handleButtonBackClick}
                        handleCompositionItemClick={this.handleCompositionItemClick}
                        disableField={this.state.disableField}
                        compositionfileToView={this.state.compositionfileToView}
                        user={this.props.user}
                        selectedComposition={this.state.selectedComposition}
                        compositions={this.props.compositions}
                        bands={this.props.bands}
                        genres={this.props.genres}
                        albums={this.props.albums}
                        handleSortAlphabetically={this.handleSortAlphabetically}
                        buttonsback={this.state.buttonsback}
                        onChangeGenreSelector={this.onChangeGenreSelector}
                        onChangeBandSelector={this.onChangeBandSelector}
                        disableAlbumSelector={this.state.disableAlbumSelector}
                    />
                }
            </CssBaseline>
        )
    }
}

const mapStateToProps = state => {
    return {
        compositions: state.compositionPage.compositions,
        bands: state.bandPage.bands,
        albums: state.albumPage.albums,
        user: state.user.user,
        genres: state.genrePage.genres
    };
};

export default compose(
    connect(mapStateToProps, { Create, Update, Delete, getCompositions, SortCompositions, getAlbums, getBands, getUser, getGenres }),
    withRouter,
)(CompositionContainer);
