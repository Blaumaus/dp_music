import { connect } from 'react-redux'
import Songs from './Songs'

const mapStateToProps = (state = {}) => ({
  theme: state.themeReducer?.theme,
})

export default connect(mapStateToProps)(Songs)
