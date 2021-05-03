import 'typeface-roboto';
import React, { Component, Fragment } from 'react';
import { connect } from 'react-redux';
import { withStyles } from '@material-ui/core/styles';
import { push } from 'connected-react-router';
import { Switch, withRouter } from 'react-router';
import Timeline from '@material-ui/icons/Timeline';
import { isNil } from 'lodash';
import { Route } from 'react-router-dom';
import SignIn from 'components/SignIn';
import SignUp from 'components/SignUp';
import ProtectedRoute from 'components/ProtectedRoute';
import ProfileContainer from 'containers/ProfileContainer';
import GenreContainer from 'containers/GenreContainer';
import BandContainer from 'containers/BandContainer';
import SelectContainer from 'containers/SelectContainer';
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
                {/* <Route exact path='/SignIn' component={SignIn} />
                <Route exact path='/SignUp' component={SignUp} />      
                <ProtectedRoute exact path='/Profile' component={ProfileContainer} />      */}
                <Route exact path='/Genres' component={GenreContainer} />     
                <Route exact path='/Bands/:genreId' component={BandContainer} />
                <Route exact path='/Select/:bandId' component={SelectContainer} />                     
            </Switch>
        </div>
    );
}

export default App;
