import { all, call } from 'redux-saga/effects'
import watchAuth from './auth/watchers'
import watchTheme from './theme/watchers'

export default function* rootSaga() {
	yield all([call(watchAuth), call(watchTheme)])
}
