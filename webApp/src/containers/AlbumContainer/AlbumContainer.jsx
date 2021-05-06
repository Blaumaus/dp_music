import React from "react";
import { withRouter } from 'react-router';
import Album from 'components/Album'
import { connect } from "react-redux";
import { Create, Update, Delete, getAlbums } from 'redux/reducers/album-reducer'
import { compose } from 'redux'
import { v4 as uuidv4 } from 'uuid';

class AlbumContainer extends React.Component {

    state = {
        //isLoading: true,
        selectedAlbum: null,
        action: null,
        disableField: false,
        file: null,
        isAdmin: false
    };
    newAlbum = {
        //TODO: without id
        id: uuidv4(),
        name: '',
        Year: '',
        description: '',
    };
    componentDidMount() {
        this.props.getAlbums();
    };

    handleUpload = event => {
        this.setState({
            file: URL.createObjectURL(event.target.files[0])
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
            file: null
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
            file: album.image
        })
    }
    handleClickDelete = (album) => {
        this.setState({
            selectedAlbum: album,
            action: 'delete',
            disableField: true,
            file: album.image
        })
    }
    handleSubmit = () => {
        const AlbumToSubmit = {
            ...this.state.selectedAlbum, image: this.state.file
        }
        switch (this.state.action) {

            case 'create': this.props.Create(AlbumToSubmit); break;
            case 'update': this.props.Update(AlbumToSubmit); break;
            case 'delete': this.props.Delete(this.state.selectedAlbum); break;
        }
        this.setState({
            selectedAlbum: null,
            action: null,
            disableField: false,
            file: null
        })

    }

    render() {
        return <Album
            handleUpload={this.handleUpload}
            onChange={this.onChange}
            handleClickCreate={this.handleClickCreate}
            handleClickEdit={this.handleClickEdit}
            handleClickDelete={this.handleClickDelete}
            handleSubmit={this.handleSubmit}
            handleButtonBackClick={this.handleButtonBackClick}
            handleAlbumItemClick={this.handleAlbumItemClick}
            disableField={this.state.disableField}
            file={this.state.file}
            isAdmin={this.state.isAdmin}
            selectedAlbum={this.state.selectedAlbum}
            albums={this.props.albums}
        />
    }
}

const mapStateToProps = state => {
    return {
      
        albums: state.albumPage.albums

    };
};

export default compose(
    connect(mapStateToProps, { Create, Update, Delete, getAlbums }),
    withRouter,
)(AlbumContainer);
