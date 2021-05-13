import { call, put } from 'redux-saga/effects'
import { authActions } from 'actions/auth'
import { verifyEmail } from "api"

export default function* ({ payload: { data, successfulCallback, errorCallback } }) {
	try {
		yield call(verifyEmail, data)
		yield put(authActions.emailVerifySuccess())
		successfulCallback()
	} catch (error) {
		errorCallback(error)
	} finally {
		yield put(authActions.finishLoading())
	}
}
