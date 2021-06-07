import { types } from './types'

export const themeActions = {
	changeTheme(theme) {
		return {
			type: types.THEME_CHANGE,
			payload: { theme }
		}
	},
}
