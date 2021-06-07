import { connect } from 'react-redux'
import Albums from './Albums'

const mapStateToProps = (state = {}) => ({
  theme: state.themeReducer?.theme,
})

export default connect(mapStateToProps)(Albums)
