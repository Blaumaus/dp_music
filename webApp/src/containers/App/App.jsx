import 'typeface-roboto';
import React, { Component, Fragment } from 'react';
import { connect } from 'react-redux';
import { withStyles } from '@material-ui/core/styles';
import { push } from 'connected-react-router';
import { Switch, withRouter } from 'react-router';
import Timeline from '@material-ui/icons/Timeline';
import { isNil } from 'lodash';
import { Route } from 'react-router-dom';
import GenreContainer from 'containers/GenreContainer';
import BandContainer from 'containers/BandContainer';
import SelectContainer from 'containers/SelectContainer';
import AlbumContainer from 'containers/AlbumContainer';
import CompositionContainer from 'containers/CompositionContainer';
import SignInContainer from 'containers/SignInContainer';
import SignUpContainer from 'containers/SignUpContainer';
import ProtectedRoute from 'components/ProtectedRoute';
import NavBar from 'components/NavBar';

const styles = () => ({

});

const mapStateToProps = state => {
    return {

    };
};

const mapDispatchToProps = dispatch => {
    return {

    };
};



function App() {
    return (
        <div className="App">
            <NavBar />
            <Switch>
                <Route exact path='/SignIn' component={SignInContainer} />
                <Route exact path='/SignUp' component={SignUpContainer} />
                <ProtectedRoute exact path='/Genres' component={GenreContainer} />
                <ProtectedRoute exact path='/Bands/:genreId?' component={BandContainer} />
                <ProtectedRoute exact path='/Select/:bandId/:genreId' component={SelectContainer} />
                <ProtectedRoute exact path='/Albums/:bandId/:genreId' component={AlbumContainer} />
                <ProtectedRoute exact path='/Compositions/:bandId/:albumId?' component={CompositionContainer} />
                <ProtectedRoute exact path='/*' />
            </Switch>
        </div>
    );
}

export default App;
