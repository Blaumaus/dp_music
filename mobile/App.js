import { StatusBar } from 'expo-status-bar'
import React from 'react'
import { SafeAreaView } from 'react-native'

import AppNavigator from './src/navigation/AppNavigator'

export default () => (
  <SafeAreaView style={{ flex: 1 }}>
    <StatusBar style="auto" translucent />
    <AppNavigator />
  </SafeAreaView>
)
