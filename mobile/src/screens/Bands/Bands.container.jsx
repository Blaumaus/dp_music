import { connect } from 'react-redux'
import Bands from './Bands'

const mapStateToProps = (state = {}) => ({
  theme: state.themeReducer?.theme,
})

export default connect(mapStateToProps)(Bands)
