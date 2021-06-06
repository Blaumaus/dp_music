import { connect } from 'react-redux'
import Player from './Player'

const mapStateToProps = (state = {}) => ({
  theme: state.themeReducer?.theme,
})

export default connect(mapStateToProps)(Player)
