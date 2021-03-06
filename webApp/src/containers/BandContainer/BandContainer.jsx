import React from "react";
import { withRouter } from 'react-router';
import Band from 'components/Band';
import { connect } from "react-redux";
import { Create, Update, Delete, getBands } from 'redux/reducers/band-reducer';
import { getGenres } from 'redux/reducers/genre-reducer';
import { getUser } from 'redux/reducers/user-reducer';
import { compose } from 'redux';
import moment from 'moment';
import CssBaseline from '@material-ui/core/CssBaseline';
import { message } from 'antd';
import { getAlbums } from 'redux/reducers/album-reducer'

class BandContainer extends React.Component {

    state = {
        isLoading: true,
        selectedBand: null,
        action: null,
        disableField: false,
        ImagefileToView: null,
        ImagefileToSend: null,
        errorMessageTime: 3,
        buttonsback: [
            {
                name: 'Жанри',
                link: '/Genres'
            },
            {
                name: 'Групи',
                link: `/Bands/${this.props.match.params.genreId}`
            },
        ]
    };

    newBand = {
        name: '',
        image: '',
        file: null,
        description: '',
        foundationDate: '',
        countryCode: '',
        genreId: this.props.match.params.genreId
    };

    async componentDidMount() {
        let { genreId } = this.props.match.params
        if (!genreId)
            genreId = null
        await this.props.getUser();
        await this.props.getBands(genreId);
        await this.props.getGenres();
        this.setState({
            ImagefileToView: null,
        })
        this.hideLoader();
    };

    showLoader = () => this.setState({ isLoading: true });

    hideLoader = () => this.setState({ isLoading: false });


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
            selectedBand: { ...this.state.selectedBand, [field]: value }
        })
    };

    handleButtonBackClick = () => {
        this.setState({
            selectedBand: null,
            disableField: false,
            ImagefileToView: null
        })

    };

    handleBandItemClick = (band) => {
        let { genreId } = this.props.match.params
        const { history } = this.props
        history.push(`/Select/${band.id}/${genreId}`)

    };

    handleClickCreate = () => {
        this.setState({
            selectedBand: this.newBand,
            action: 'create'
        })
    };

    handleClickEdit = (band) => {
        this.setState({
            selectedBand: band,
            action: 'update',
            ImagefileToView: band.image
        })
    };

    handleClickDelete = (band) => {
        this.setState({
            selectedBand: band,
            action: 'delete',
            disableField: true,
            ImagefileToView: band.image
        })
    };

    error = (content) => {
        const { errorMessageTime } = this.state;
        message.error(content, errorMessageTime);
    };

    handleSubmit = async () => {
        this.showLoader();
        const { selectedBand } = this.state;
        if (!selectedBand.foundationDate) {
            selectedBand.foundationDate = new Date();
        }
        const dateToSubmit = moment(selectedBand.foundationDate).format('YYYY-MM-DD');
        selectedBand.foundationDate = dateToSubmit;

        const formData = new FormData();
        const { ImagefileToSend } = this.state;
        formData.append('file', ImagefileToSend);
        formData.set('id', selectedBand.id);
        formData.set('name', selectedBand.name);
        formData.set('description', selectedBand.description);
        formData.set('foundationDate', selectedBand.foundationDate);
        formData.set('countryCode', selectedBand.countryCode);
        formData.set('genreId', selectedBand.genreId);

        switch (this.state.action) {

            case 'create': await this.props.Create(formData); break;
            case 'update': await this.props.Update(formData); break;
            case 'delete':
                await this.props.getAlbums(selectedBand.id);
                let isHasChild = this.props.albums.find(album => album.bandId === selectedBand.id)
                if (isHasChild) {
                    this.error('Неможливо видалити, існують альбоми, які належать до цієї групи');
                }
                else {
                    await this.props.Delete(selectedBand);
                }
                break;
                default: alert('Сталась помилка'); break;
        };

        this.setState({
            selectedBand: null,
            action: null,
            disableField: false,
            ImagefileToView: null,
        })
        const { genreId } = this.props.match.params
        this.props.getBands(genreId).then(this.hideLoader());
    }

    render() {
        const { isLoading } = this.state;

        return (
            <CssBaseline>
                {
                    !isLoading && <Band

                        handleUpload={this.handleUpload}
                        onChange={this.onChange}
                        handleClickCreate={this.handleClickCreate}
                        handleClickEdit={this.handleClickEdit}
                        handleClickDelete={this.handleClickDelete}
                        handleSubmit={this.handleSubmit}
                        handleButtonBackClick={this.handleButtonBackClick}
                        handleBandItemClick={this.handleBandItemClick}
                        disableField={this.state.disableField}
                        ImagefileToView={this.state.ImagefileToView}
                        selectedBand={this.state.selectedBand}
                        bands={this.props.bands}
                        genres={this.props.genres}
                        buttonsback={this.state.buttonsback}
                        user={this.props.user}
                    />
                }
            </CssBaseline>
        )
    }
}

const mapStateToProps = state => {
    return {
        bands: state.bandPage.bands,
        genres: state.genrePage.genres,
        albums: state.albumPage.albums,
        user: state.user.user,
    };
};
export default compose(
    connect(mapStateToProps, { Create, Update, Delete, getBands, getGenres, getUser, getAlbums }),
    withRouter,
)(BandContainer);
