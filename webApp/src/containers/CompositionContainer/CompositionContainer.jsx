import React from "react";
import { withRouter } from 'react-router';
import Composition from 'components/Composition'
import { connect } from "react-redux";
import { Create, Update, Delete, getCompositions, SortCompositions } from 'redux/reducers/composition-reducer'
import { compose } from 'redux'
import { v4 as uuidv4 } from 'uuid';

const arrayEmpty = {
    marginLeft: '8%',
    marginTop: '4%',
    display: 'flex',
    fontSize: '2em'
}

class CompositionContainer extends React.Component {

    state = {
        //isLoading: true,
        selectedComposition: null,
        action: null,
        disableField: false,
        compositionFile: null,
        isAdmin:  false,
        isLoading: true,
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
        //TODO: without id
        id: uuidv4(),
        name: '',
        compositionFile: '',
        description: '',
    };
    showLoader = () => this.setState({ isLoading: true });
    hideLoader = () => this.setState({ isLoading: false });
    componentDidMount() {
        this.props.getCompositions();
        this.hideLoader();
    };
    handleUpload = event => {
        this.setState({
            compositionFile: URL.createObjectURL(event.target.files[0])
        })
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
    }
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
            compositionFile: composition.compositionFile
        })
    }
    handleClickDelete = (composition) => {
        this.setState({
            selectedComposition: composition,
            action: 'delete',
            disableField: true,
            compositionFile: composition.compositionFile
        })
    }
    handleSortAlphabetically = () => {
        this.showLoader();
        this.props.SortCompositions(this.props.compositions);
        this.hideLoader();
    }
    handleSubmit = () => {
        const CompositionToSubmit = {
            ...this.state.selectedComposition, compositionFile: this.state.compositionFile
        }
        switch (this.state.action) {

            case 'create': this.props.Create(CompositionToSubmit); break;
            case 'update': this.props.Update(CompositionToSubmit); break;
            case 'delete': this.props.Delete(this.state.selectedComposition); break;
        }
        this.setState({
            selectedComposition: null,
            action: null,
            disableField: false,
            compositionFile: null
        })

    }

    render() {
        const { isLoading } = this.state;
        return (
            <div>
                {
                    !isLoading && this.props.compositions.length > 0 ? (<Composition
                        handleUpload={this.handleUpload}
                        onChange={this.onChange}
                        handleClickCreate={this.handleClickCreate}
                        handleClickEdit={this.handleClickEdit}
                        handleClickDelete={this.handleClickDelete}
                        handleSubmit={this.handleSubmit}
                        handleButtonBackClick={this.handleButtonBackClick}
                        handleBandItemClick={this.handleBandItemClick}
                        disableField={this.state.disableField}
                        compositionFile={this.state.compositionFile}
                        isAdmin={this.state.isAdmin}
                        selectedComposition={this.state.selectedComposition}
                        compositions={this.props.compositions}
                        handleSortAlphabetically={this.handleSortAlphabetically}
                        buttonsback={this.state.buttonsback}
                    />
                    ) : (<div style={arrayEmpty}>Композицій ще не додано</div>)
                }
            </div>
        )
    }
}

const mapStateToProps = state => {
    return {
        compositions: state.compositionPage.compositions
    };
};

export default compose(
    connect(mapStateToProps, { Create, Update, Delete, getCompositions, SortCompositions }),
    withRouter,
)(CompositionContainer);
