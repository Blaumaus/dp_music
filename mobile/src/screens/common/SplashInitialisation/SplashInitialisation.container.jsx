import { connect } from 'react-redux'
import { authActions } from '../../../redux/actions/auth'
import SplashInitialisation from './SplashInitialisation'

const mapStateToProps = (state = {}) => ({
  initialised: state.authReducer?.isInitialised,
})

const mapDispatchToProps = dispatch => ({
  initialise: (payload) => {
    dispatch(authActions.initialise(payload))
  },
})

export default connect(mapStateToProps, mapDispatchToProps)(SplashInitialisation)
