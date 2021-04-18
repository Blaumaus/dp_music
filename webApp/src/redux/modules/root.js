import { combineReducers } from 'redux';
import { createBrowserHistory } from 'history';
import { connectRouter } from 'connected-react-router';
export const history = createBrowserHistory();

export const rootReducer = combineReducers({
    router: connectRouter(history),
});