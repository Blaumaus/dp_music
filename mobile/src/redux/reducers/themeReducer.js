import constants from '../constants'
import { types } from '../actions/theme/types'

const initialState = {
	theme: constants.DEFAULT_FALLBACK_THEME,
}

export default (state = initialState, { type, payload }) => {
	switch (type) {
		case types.THEME_CHANGE:
			return {
				...state,
				theme: payload.theme,
			}

		default:
			return state
	}
}
