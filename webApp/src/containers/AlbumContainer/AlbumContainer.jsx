import React from "react";
import { withRouter } from 'react-router';
import Album from 'components/Album'
import { connect } from "react-redux";
import { Create, Update, Delete, getAlbums } from 'redux/reducers/album-reducer'
import { getBands } from 'redux/reducers/band-reducer'
import { getUser } from 'redux/reducers/user-reducer'
import { compose } from 'redux'
import CssBaseline from '@material-ui/core/CssBaseline';

class AlbumContainer extends React.Component {

    state = {
        isLoading: true,
        selectedAlbum: null,
        action: null,
        disableField: false,
        ImagefileToView: null,
        ImagefileToSend: null,
        isAdmin: true,
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
    newAlbum = {
        name: '',
        image: '',
        file: null,
        Year: '',
        description: '',
        bandId: this.props.match.params.bandId
    };
    async componentDidMount() {

        const { bandId } = this.props.match.params
        this.props.getAlbums(bandId);
        await this.props.getUser();
        await this.props.getBands(null);
        this.setState({
            ImagefileToView: null,
        })
        this.hideLoader();
    };

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
            selectedAlbum: { ...this.state.selectedAlbum, [field]: value }
        })
    };

    handleButtonBackClick = () => {
        this.setState({
            selectedAlbum: null,
            disableField: false,
            ImagefileToView: null
        })
    }

    handleAlbumItemClick = (album) => {
        const { history } = this.props
        const { bandId } = this.props.match.params
        history.push(`/Compositions/${bandId}/${album.id}`)

    }

    handleClickCreate = () => {
        this.setState({
            selectedAlbum: this.newAlbum,
            action: 'create'
        })
    }

    handleClickEdit = (album) => {
        this.setState({
            selectedAlbum: album,
            action: 'update',
            ImagefileToView: album.image
        })
    }

    handleClickDelete = (album) => {
        this.setState({
            selectedAlbum: album,
            action: 'delete',
            disableField: true,
            ImagefileToView: album.image
        })
    }

    handleSubmit = async () => {
        this.showLoader();
        const { selectedAlbum } = this.state;

        const formData = new FormData();
        const { ImagefileToSend } = this.state;
        formData.append('file', ImagefileToSend);
        formData.set('id', selectedAlbum.id);
        formData.set('name', selectedAlbum.name);
        formData.set('year', selectedAlbum.description);
        formData.set('bandId', selectedAlbum.bandId);
        formData.set('description', selectedAlbum.description);
        

        switch (this.state.action) {

            case 'create': await this.props.Create(formData); break;
            case 'update': await this.props.Update(formData); break;
            case 'delete': await this.props.Delete(selectedAlbum); break;
        }
        this.setState({
            selectedAlbum: null,
            action: null,
            disableField: false,
            ImagefileToView: null,
        })
        const { bandId } = this.props.match.params
        this.props.getBands(bandId).then(this.hideLoader());
    }

    render() {
        const { isLoading } = this.state;

        return (
            <CssBaseline>
                {
                    !isLoading && <Album
                        handleUpload={this.handleUpload}
                        onChange={this.onChange}
                        handleClickCreate={this.handleClickCreate}
                        handleClickEdit={this.handleClickEdit}
                        handleClickDelete={this.handleClickDelete}
                        handleSubmit={this.handleSubmit}
                        handleButtonBackClick={this.handleButtonBackClick}
                        handleAlbumItemClick={this.handleAlbumItemClick}
                        disableField={this.state.disableField}
                        ImagefileToView={this.state.ImagefileToView}
                        selectedAlbum={this.state.selectedAlbum}
                        albums={this.props.albums}
                        bands={this.props.bands}
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
        bands: state.bandPage.bands,
        albums: state.albumPage.albums,
        user: state.user.user
    };
};

export default compose(
    connect(mapStateToProps, { Create, Update, Delete, getAlbums, getBands, getUser }),
    withRouter,
)(AlbumContainer);
