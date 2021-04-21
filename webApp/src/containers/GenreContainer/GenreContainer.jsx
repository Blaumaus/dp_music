import React, { Component } from "react";
import { withRouter } from 'react-router';
import Genre from 'components/Genre'
import { connect } from "react-redux";
import { Create, Update, getGenres } from 'redux/reducers/genre-reducer'

class GenreContainer extends React.Component {
    componentDidMount() {
        //TODO: Upload from API
    }
    render() {
        return <>            
            <Genre {...this.props} />
        </>

    }
}

const mapStateToProps = state => {
    return {
        genres: state.genrePage.genres

    };
};

// const mapDispatchToProps = dispatch => {
//     return {
//         create: (genre) => {
//             dispatch(CreateAC(genre))
//         },
//         update: (genreId) => {
//             dispatch(UpdateAC(genreId))
//         },
//         getGenres: getGenres
//     };
// };
export default connect(mapStateToProps, { Create, Update, getGenres })(GenreContainer)