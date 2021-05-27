import _isString from 'lodash/isString'
import _get from 'lodash/get'
import { call, put  } from 'redux-saga/effects'

import constants from '../../../constants'
import { authActions } from '../../../actions/auth'
import { errorsActions } from '../../../actions/errors'
import { set } from '../../../../utils/storage'
import { parseCookie } from '../../../../utils/generic'
import { signup } from '../../../../api'

export default function* ({ payload: { data: credentials, callback = () => {} } }) {
	try {
		const { data, headers } = yield call(signup, credentials)
		const { errorMessage } = data
		if (errorMessage) {
			throw new Error(errorMessage)
		}
		const token = parseCookie(constants.JWT_TOKEN, _get(headers, 'set-cookie', ''))

		yield put(authActions.signupSuccess({ token, userInfo: null }))
		yield call(set, constants.TOKEN, token)
		callback()
	} catch (error) {
		const message = _isString(error) ? error : 'Invalid username or password!'

		yield put(errorsActions.loginFailed(message))
	} finally {
		yield put(authActions.finishLoading())
	}
}
