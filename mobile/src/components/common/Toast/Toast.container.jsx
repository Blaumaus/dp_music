import { connect } from 'react-redux'
import { errorsActions } from '../../../redux/actions/errors'
import Toast from './Toast'

const mapStateToProps = (state = {}) => ({
  error: state.errorsReducer?.error,
})

const mapDispatchToProps = dispatch => ({
  clearErrors: () => {
    dispatch(errorsActions.clearErrors())
  },
})

export default connect(mapStateToProps, mapDispatchToProps)(Toast)
