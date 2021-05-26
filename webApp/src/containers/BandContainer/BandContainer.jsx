import React from "react";
import { withRouter } from 'react-router';
import Band from 'components/Band'
import { connect } from "react-redux";
import { Create, Update, Delete, getBands } from 'redux/reducers/band-reducer'
import { getGenres } from 'redux/reducers/genre-reducer'
import { compose } from 'redux'
import { v4 as uuidv4 } from 'uuid';

class BandContainer extends React.Component {

    state = {
        isLoading: true,
        selectedBand: null,
        action: null,
        disableField: false,
        file: null,
        isAdmin: true,
        buttonsback: [
            {
                name: 'Жанри',
                link: '/Genres'
            }
        ]
    };
    newBand = {
        //TODO: without id
        id: uuidv4(),
        name: '',
        image: '',
        description: '',
        foundationDate: '',
        genreId: null
    };
    componentDidMount() {
        this.props.getBands();
        this.props.getGenres();
        this.hideLoader();
    };

    showLoader = () => this.setState({ isLoading: true });

    hideLoader = () => this.setState({ isLoading: false });


    handleUpload = event => {
        this.setState({
            file: URL.createObjectURL(event.target.files[0])
        })
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
            file: null
        })
    }
    handleBandItemClick = (band) => {
        const { history } = this.props
        debugger;
        //Push to all songs or albums choice page
        history.push(`/Select/${band.id}`)

    }
    handleClickCreate = () => {
        this.setState({
            selectedBand: this.newBand,
            action: 'create'
        })
    }
    handleClickEdit = (band) => {
        this.setState({
            selectedBand: band,
            action: 'update',
            file: band.image
        })
    }
    handleClickDelete = (band) => {
        this.setState({
            selectedBand: band,
            action: 'delete',
            disableField: true,
            file: band.image
        })
    }
    handleSubmit = () => {
        const BandToSubmit = {
            ...this.state.selectedBand, image: this.state.file
        }
        switch (this.state.action) {

            case 'create': this.props.Create(BandToSubmit); break;
            case 'update': this.props.Update(BandToSubmit); break;
            case 'delete': this.props.Delete(this.state.selectedBand); break;
        }
        this.setState({
            selectedBand: null,
            action: null,
            disableField: false,
            file: null
        })

    }

    render() {
        return <Band
            handleUpload={this.handleUpload}
            onChange={this.onChange}
            handleClickCreate={this.handleClickCreate}
            handleClickEdit={this.handleClickEdit}
            handleClickDelete={this.handleClickDelete}
            handleSubmit={this.handleSubmit}
            handleButtonBackClick={this.handleButtonBackClick}
            handleBandItemClick={this.handleBandItemClick}
            disableField={this.state.disableField}
            file={this.state.file}
            isAdmin={this.state.isAdmin}
            selectedBand={this.state.selectedBand}
            bands={this.props.bands}
            genres={this.props.genres}
            buttonsback={this.state.buttonsback}
        />
    }
}
const mapStateToProps = state => {
    return {
        bands: state.bandPage.bands,
        genres: state.genrePage.genres

    };
};
export default compose(
    connect(mapStateToProps, { Create, Update, Delete, getBands, getGenres }),
    withRouter,
)(BandContainer);
