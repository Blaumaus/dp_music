import { call, put } from 'redux-saga/effects'
import { authActions } from '../../../actions/auth'
import { errorsActions } from '../../../actions/errors'
import { changeCustomerDetails } from '../../../../api'

export default function* ({ payload: { data, successfulCallback } }) {
	try {
		const user = yield call(changeCustomerDetails, data)
		yield put(authActions.updateProfileSuccess(user))
		successfulCallback()
	} catch (error) {
		yield put(errorsActions.updateProfileFailed(error.message || (typeof error === 'string' ? error : error[0])))
	} finally {
		yield put(authActions.finishLoading())
	}
}
