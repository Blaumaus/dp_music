import { combineReducers, createStore } from 'redux';
let reducers = combineReducers({
    genrePage: genreReducer,
});
let store = createStore(reducers);
export default store;
