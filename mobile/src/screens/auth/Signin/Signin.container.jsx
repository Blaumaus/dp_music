import { connect } from 'react-redux'
import _isEmpty from 'lodash/isEmpty'
import { authActions } from '../../../redux/actions/auth'
import Signin from './Signin'

const mapStateToProps = (state = {}) => ({
  authorised: !_isEmpty(state.authReducer?.token),
  theme: state.themeReducer?.theme,
})

const mapDispatchToProps = dispatch => ({
  login: (payload, callback) => {
    dispatch(authActions.loginAsync(payload, callback))
  },
})

export default connect(mapStateToProps, mapDispatchToProps)(Signin)
