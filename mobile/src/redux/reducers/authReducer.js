import { types } from 'actions/auth/types'

const initialState = {
	redirectPath: null,
	isAuthenticated: false,
	isLoading: true,
	userInfo: null
}

export default (state = initialState, { type, payload }) => {
	switch (type) {
		case types.SIGNUP_UP_SUCCESSFUL:
		case types.LOGIN_SUCCESSFUL:
			return {...state, userInfo: payload.userInfo, isAuthenticated: true}

		case types.UPDATE_USER_PROFILE_SUCCESS:
			return {...state, userInfo: payload.userInfo}

		case types.EMAIL_VERIFY_SUCCESSFUL:
			return {...state, userInfo: {...state.userInfo, isActive: true}}

		case types.SAVE_PATH:
			return {...state, redirectPath: payload.path}

		case types.LOGOUT:
		case types.DELETE_ACCOUNT_SUCCESS:
			return {...state, isAuthenticated: false, userInfo: null}

		case types.FINISH_LOADING:
			return {...state, isLoading: false}

		default:
			return state
	}
};
