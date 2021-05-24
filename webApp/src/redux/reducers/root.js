import { combineReducers } from 'redux';
import { createBrowserHistory } from 'history';
import { connectRouter } from 'connected-react-router';
import GenreReducer from 'redux/reducers/genre-reducer'
import BandReducer from 'redux/reducers/band-reducer'
import AlbumReducer from 'redux/reducers/album-reducer'
import CompositionReducer from 'redux/reducers/composition-reducer'
import UserReducer from 'redux/reducers/user-reducer'
export const history = createBrowserHistory();

export const rootReducer = combineReducers({
    router: connectRouter(history),
    genrePage: GenreReducer,
    bandPage: BandReducer,
    albumPage: AlbumReducer,
    compositionPage:CompositionReducer,
    user:UserReducer
});