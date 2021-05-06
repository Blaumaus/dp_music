
import React from 'react'
import { View, Text, StyleSheet } from 'react-native'

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
  },
})

export default () => {
  return (
    <View style={styles.container}>
      <Text>The Home screen</Text>
    </View>
  )
}
