import { types } from './types'

export const errorsActions = {
	// auth
	loginFailed(error) {
		return {
			type: types.LOGIN_FAILED,
			payload: { error }
		}
	},
	signupFailed(error) {
		return {
			type: types.SIGN_UP_FAILED,
			payload: { error }
		}
	},
	createNewPasswordFailed(error) {
		return {
			type: types.CREATE_NEW_PASSWORD_FAILED,
			payload: { error }
		}
	},
	updateProfileFailed(error) {
		return {
			type: types.UPDATE_USER_PROFILE_FAILED,
			payload: { error }
		}
	},
	deleteAccountFailed(error) {
		return {
			type: types.DELETE_ACCOUNT_FAILED,
			payload: { error }
		}
	},

	clearErrors() {
		return {
			type: types.CLEAR_ERRORS
		}
	},
}
