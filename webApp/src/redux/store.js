import { applyMiddleware, createStore } from 'redux';
import { createEpicMiddleware } from 'redux-observable';
import { createLogger } from 'redux-logger';
import ReduxThunk from 'redux-thunk';
import { composeWithDevTools } from 'redux-devtools-extension/developmentOnly';
import { rootReducer} from './modules/root';

import { createBrowserHistory } from 'history';
import { routerMiddleware } from 'connected-react-router';

export const history = createBrowserHistory();

const myRouterMiddleware = routerMiddleware(history);
const epicMiddleware = createEpicMiddleware();

const getMiddleware = () => {
    if (process.env.NODE_ENV === 'production') {
        return applyMiddleware(myRouterMiddleware, epicMiddleware, ReduxThunk);
    } else {
        // Enable additional logging in non-production environments.
        return applyMiddleware(myRouterMiddleware, epicMiddleware, ReduxThunk, createLogger());
    }
};

export const store = createStore(rootReducer,composeWithDevTools(getMiddleware()));

