import { combineReducers } from 'redux'
import authReducer from './authReducer'
import errorsReducer from './errorsReducer'
import themeReducer from './themeReducer'

export default combineReducers({ authReducer, errorsReducer, themeReducer })
