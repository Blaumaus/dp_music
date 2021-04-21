
import { applyMiddleware, combineReducers, createStore } from 'redux';
import thunk from 'redux-thunk'
import genreReducer from 'redux/reducers/genre-reducer'
let reducers = combineReducers({
    genrePage: genreReducer,
});
let store = createStore(reducers, applyMiddleware(thunk));
export default store;
