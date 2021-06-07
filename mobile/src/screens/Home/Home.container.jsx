import { connect } from 'react-redux'
import Home from './Home'

const mapStateToProps = (state = {}) => ({
  theme: state.themeReducer?.theme,
})

export default connect(mapStateToProps)(Home)
