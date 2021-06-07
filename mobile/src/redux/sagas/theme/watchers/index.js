import { takeLatest, all, call } from 'redux-saga/effects'
import { types } from '../../../actions/theme/types'
import themeChange from '../workers/themeChange'

function* watchThemeChange() {
	yield takeLatest(types.THEME_CHANGE, themeChange)
}

export default function* watchAuth() {
	yield all([call(watchThemeChange)])
}
