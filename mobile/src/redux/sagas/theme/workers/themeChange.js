import { call } from 'redux-saga/effects'

import constants from '../../../constants'
import { set } from '../../../../utils/storage'

export default function* ({ payload: { theme } }) {
	yield call(set, constants.THEME, theme)
}
