import { call, put } from 'redux-saga/effects'
import { authActions } from '../../../actions/auth'
import { deleteUser } from '../../../../api'

export default function* ({ payload: { errorCallback } }) {
	try {
		yield call(deleteUser)
		yield put(authActions.deleteAccountSuccess())
	} catch (e) {
		errorCallback(JSON.parse(e.message))
	} finally {
		yield put(authActions.finishLoading())
	}
}
