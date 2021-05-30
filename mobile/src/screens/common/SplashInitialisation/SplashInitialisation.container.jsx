import { connect } from 'react-redux'
import { authActions } from '../../../redux/actions/auth'
import { themeActions } from '../../../redux/actions/theme'
import SplashInitialisation from './SplashInitialisation'

const mapStateToProps = (state = {}) => ({
  initialised: state.authReducer?.isInitialised,
})

const mapDispatchToProps = dispatch => ({
  initialise: ({ token, theme }) => {
    dispatch(authActions.initialise({ token }))
    dispatch(themeActions.changeTheme(theme))
  },
  onThemeChange: (theme) => {
    dispatch(themeActions.changeTheme(theme))
  }
})

export default connect(mapStateToProps, mapDispatchToProps)(SplashInitialisation)
