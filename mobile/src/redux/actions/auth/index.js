import { types } from './types'

export const authActions = {
	//Sync
	loginSuccess(userInfo) {
		return {
			type: types.LOGIN_SUCCESSFUL,
			payload: { userInfo }
		}
	},
	emailVerifySuccess() {
		return {
			type: types.EMAIL_VERIFY_SUCCESSFUL
		}
	},
	signupSuccess(userInfo) {
		return {
			type: types.SIGNUP_UP_SUCCESSFUL,
			payload: { userInfo }
		}
	},
	updateProfileSuccess(userInfo) {
		return {
			type: types.UPDATE_USER_PROFILE_SUCCESS,
			payload: { userInfo }
		}
	},
	logout() {
		localStorage.removeItem('access_token')
		localStorage.removeItem('user_info')

		return {
			type: types.LOGOUT
		}
	},
	clearErrors() {
		return {
			type: types.CLEAR_ERRORS
		}
	},
	savePath(path) {
		return {
			type: types.SAVE_PATH,
			payload: { path }
		}
	},
	deleteAccountSuccess() {
		localStorage.removeItem('access_token')
		localStorage.removeItem('user_info')

		return {
			type: types.DELETE_ACCOUNT_SUCCESS
		}
	},
	finishLoading() {
		return {
			type: types.FINISH_LOADING
		}
	},

	//Async
	loginAsync(credentials) {
		return {
			type: types.LOGIN_ASYNC,
			payload: { credentials }
		}
	},
	signupAsync(data, resetRecaptcha) {
		return {
			type: types.SIGNUP_ASYNC,
			payload: { data, resetRecaptcha }
		}
	},
	emailVerifyAsync(data, successfulCallback, errorCallback) {
		return {
			type: types.EMAIL_VERIFY_ASYNC,
			payload: { data, successfulCallback, errorCallback }
		}
	},
	updateUserProfileAsync(data, successfulCallback = () => {}) {
		return {
			type: types.UPDATE_USER_PROFILE_ASYNC,
			payload: { data, successfulCallback }
		}
	},
	deleteAccountAsync(errorCallback) {
		return {
			type: types.DELETE_ACCOUNT_ASYNC,
			payload: { errorCallback }
		}
	}
}
