import React, { memo } from 'react'
import { useSelector } from 'react-redux'
import { View, StyleSheet } from 'react-native'

import constants from '../../redux/constants'
import Spinner from '../../components/common/Spinner'

const getStyles = theme => StyleSheet.create({
  container: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center',
    backgroundColor: theme === 'dark' ? constants.BACKGROUND_DARK : constants.BACKGROUND_LIGHT,
  }
})

const Loading = () => {
  const theme = useSelector(state => state.themeReducer?.theme)
  const styles = getStyles(theme)
  
  return (
    <View style={styles.container}>
      <Spinner />
    </View>
  )
}

export default memo(Loading)
