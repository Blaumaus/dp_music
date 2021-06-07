import _isString from 'lodash/isString'
import { call, put  } from 'redux-saga/effects'

import { authActions } from '../../../actions/auth'
import { errorsActions } from '../../../actions/errors'
import { signup } from '../../../../api'

export default function* ({ payload: { data: credentials, callback = () => {} } }) {
	try {
		const { data } = yield call(signup, credentials)
		const { errorMessage } = data
		if (errorMessage) {
			throw new Error(errorMessage)
		}

		// yield put(authActions.signupSuccess())
		callback()
	} catch (error) {
		const message = _isString(error) ? error : 'Username or email are already taken!'

		yield put(errorsActions.signupFailed(message))
	} finally {
		yield put(authActions.finishLoading())
	}
}
