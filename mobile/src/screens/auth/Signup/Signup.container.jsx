import { connect } from 'react-redux'
import _isEmpty from 'lodash/isEmpty'
import { authActions } from '../../../redux/actions/auth'
import Signup from './Signup'

const mapStateToProps = (state = {}) => ({
  authorised: !_isEmpty(state.authReducer?.token),
  theme: state.themeReducer?.theme,
})

const mapDispatchToProps = dispatch => ({
  register: (payload, callback) => {
    dispatch(authActions.signupAsync(payload, callback))
  },
})

export default connect(mapStateToProps, mapDispatchToProps)(Signup)
