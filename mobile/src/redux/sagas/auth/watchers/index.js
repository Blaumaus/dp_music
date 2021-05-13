import { takeLatest, all, call } from 'redux-saga/effects'
import { types } from 'redux/actions/auth/types'
import signIn from '../workers/signin'
import signUp from '../workers/signup'
import verifyEmail from '../workers/verifyEmail'
import updateUserProfile from '../workers/updateUserProfile'
import deleteUserAccount from "../workers/deleteUserAccount"

function* watchLogin() {
	yield takeLatest(types.LOGIN_ASYNC, signIn)
}

function* watchVerifyEmail() {
	yield takeLatest(types.EMAIL_VERIFY_ASYNC, verifyEmail)
}

function* watchSignup() {
	yield takeLatest(types.SIGNUP_ASYNC, signUp)
}

function* watchUpdateUserProfile() {
	yield takeLatest(types.UPDATE_USER_PROFILE_ASYNC, updateUserProfile)
}

function* watchDeleteUserProfile() {
	yield takeLatest(types.DELETE_ACCOUNT_ASYNC, deleteUserAccount)
}

export default function* watchAuth() {
	yield all([call(watchLogin), call(watchSignup), call(watchVerifyEmail), call(watchUpdateUserProfile), call(watchDeleteUserProfile)])
}
