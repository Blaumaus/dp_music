import React from 'react'
import { View, StyleSheet } from 'react-native'
import Spinner from '../../components/common/Spinner'

const styles = StyleSheet.create({
  container: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center',
  }
})

export default () => (
  <View style={styles.container}>
    <Spinner />
  </View>
)
