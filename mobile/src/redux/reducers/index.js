import { combineReducers } from 'redux'
import authReducer from './authReducer'
import errorsReducer from './errorsReducer'

export default combineReducers({ authReducer, errorsReducer })
