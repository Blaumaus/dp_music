import _isString from 'lodash/isString'
import _get from 'lodash/get'
import { call, put } from 'redux-saga/effects'

import constants from '../../../constants'
import { authActions } from '../../../actions/auth'
import { errorsActions } from '../../../actions/errors'
import { set } from '../../../../utils/storage'
import { parseCookie } from '../../../../utils/generic'
import { login } from '../../../../api'

export default function* ({ payload: { credentials, callback = () => {} } }) {
	try {
		const { data, headers } = yield call(login, credentials)
		const { errorMessage } = data
		if (errorMessage) {
			throw new Error(errorMessage)
		}
		const token = parseCookie(constants.JWT_TOKEN, _get(headers, 'set-cookie', ''))

		yield put(authActions.loginSuccess({ token, userInfo: null }))
		yield call(set, constants.TOKEN, token)
		callback(false)
	} catch (error) {
		const message = _isString(error) ? error : 'Invalid username or password!'

		yield put(errorsActions.loginFailed(message))
		callback(true, message)
	} finally {
		yield put(authActions.finishLoading())
	}
}
