import { types } from '../actions/auth/types'

const initialState = {
	isAuthenticated: false,
	isLoading: true,
	userInfo: null,
	token: null,
}

export default (state = initialState, { type, payload }) => {
	switch (type) {
		case types.SIGNUP_UP_SUCCESSFUL:
		case types.LOGIN_SUCCESSFUL:
			return {
				...state,
				userInfo: payload.userInfo,
				isAuthenticated: true,
				token: payload.token,
			}

		case types.UPDATE_USER_PROFILE_SUCCESS:
			return {
				...state,
				userInfo: payload.userInfo,
				token: payload.token,
			}

		case types.EMAIL_VERIFY_SUCCESSFUL:
			return {
				...state,
				userInfo: {
					...state.userInfo,
					isActive: true,
				},
			}

		case types.LOGOUT:
		case types.DELETE_ACCOUNT_SUCCESS:
			return {
				...state,
				isAuthenticated: false,
				userInfo: null,
				token: null,
			}

		case types.FINISH_LOADING:
			return {
				...state,
				isLoading: false,
			}

		default:
			return state
	}
}
