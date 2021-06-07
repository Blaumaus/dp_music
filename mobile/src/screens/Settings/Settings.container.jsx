import { connect } from 'react-redux'
import { themeActions } from '../../redux/actions/theme'
import Settings from './Settings'

const mapStateToProps = (state = {}) => ({
  theme: state.themeReducer?.theme,
})

const mapDispatchToProps = dispatch => ({
  onThemeChange: (theme) => {
    dispatch(themeActions.changeTheme(theme))
  }
})

export default connect(mapStateToProps, mapDispatchToProps)(Settings)
