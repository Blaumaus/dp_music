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

const arrayEmpty = {
    marginLeft: '8%',
    marginTop: '4%',
    display: 'flex',
    fontSize: '2em'
}

class CompositionContainer extends React.Component {

    state = {
        isLoading: true,
        selectedComposition: null,
        action: null,
        disableField: false,
        ImagefileToView: null,
        ImagefileToSend: null,
        buttonsback: [
            {
                name: 'Жанри',
                link: '/Genres'
            },
            {
                name: 'Групи',
                link: `/Bands/${this.props.match.params.bandId}`
            },
            {
                name: 'Вибір',
                link: `/Select/${this.props.match.params.bandId}`
            }
        ]
    };
    newComposition = {
        name: '',
        compositionFile: '',
        description: '',
        genreId: null,
        bandId: null,
        albumId: null,
        lyrics: null
    };

    showLoader = () => this.setState({ isLoading: true });

    hideLoader = () => this.setState({ isLoading: false });

    async componentDidMount() {
        const { bandId, albumId } = this.props.match.params
        await this.props.getUser();
        await this.props.getGenres();
        await this.props.getBands(null);
        await this.props.getAlbums(null);
        await this.props.getCompositions(bandId, albumId);

        this.setState({
            ImagefileToView: null,
        })

        this.hideLoader();
    };
    handleUpload = event => {
        if (event.target.files[0]) {
            this.setState({
                ImagefileToView: URL.createObjectURL(event.target.files[0]),
                ImagefileToSend: event.target.files[0]
            })
        }

    };

    onChange = (field, value) => {
        this.setState({
            selectedComposition: { ...this.state.selectedComposition, [field]: value }
        })
    };

    handleButtonBackClick = () => {
        this.setState({
            selectedComposition: null,
            disableField: false,
            compositionFile: null
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
            ImagefileToView: composition.image
        })
    }

    handleClickDelete = (composition) => {
        this.setState({
            selectedComposition: composition,
            action: 'delete',
            disableField: true,
            ImagefileToView: composition.image
        })
    }

    handleSortAlphabetically = () => {
        this.showLoader();
        this.props.SortCompositions(this.props.compositions);
        this.hideLoader();
    }

    handleSubmit = () => {
        const { selectedComposition } = this.state;

        const formData = new FormData();
        const { ImagefileToSend } = this.state;
        formData.append('file', ImagefileToSend)
        formData.set('id', selectedComposition.id)
        formData.set('name', selectedComposition.name)
        formData.set('year', selectedComposition.description)
        formData.set('genreId', selectedComposition.genreId)
        formData.set('bandId', selectedComposition.bandId)
        formData.set('albumd', selectedComposition.albumId)
        formData.set('description', selectedComposition.description);
        formData.set('lyrics', selectedComposition.lyrics);

        switch (this.state.action) {

            case 'create': this.props.Create(formData); break;
            case 'update': this.props.Update(formData); break;
            case 'delete': this.props.Delete(selectedComposition); break;
        }

        this.setState({
            selectedComposition: null,
            action: null,
            disableField: false,
            ImagefileToView: null,
        })
        const { bandId, albumId } = this.props.match.params;
        this.props.getCompositions(bandId, albumId).then(this.hideLoader());
    }

    handleCompositionItemClick = () => { }

    render() {
        const { isLoading } = this.state;
        return (
            <CssBaseline>
                {
                    !isLoading && this.props.compositions.length > 0 ? (<Composition
                        handleUpload={this.handleUpload}
                        onChange={this.onChange}
                        handleClickCreate={this.handleClickCreate}
                        handleClickEdit={this.handleClickEdit}
                        handleClickDelete={this.handleClickDelete}
                        handleSubmit={this.handleSubmit}
                        handleButtonBackClick={this.handleButtonBackClick}
                        handleCompositionItemClick={this.handleCompositionItemClick}
                        disableField={this.state.disableField}
                        ImagefileToView={this.state.ImagefileToView}
                        user={this.props.user}
                        selectedComposition={this.state.selectedComposition}
                        compositions={this.props.compositions}
                        bands={this.props.bands}
                        genres={this.props.genres}
                        albums={this.props.albums}
                        handleSortAlphabetically={this.handleSortAlphabetically}
                        buttonsback={this.state.buttonsback}
                    />
                    ) : (<div style={arrayEmpty}>Композицій ще не додано</div>)
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
