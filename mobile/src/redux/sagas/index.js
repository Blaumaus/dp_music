import { all, call } from 'redux-saga/effects'
import watchAuth from './auth/watchers'

export default function* rootSaga() {
	yield all([call(watchAuth)])
}