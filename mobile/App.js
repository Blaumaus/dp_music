import { StatusBar } from 'expo-status-bar'
import React from 'react'
import { Provider } from 'react-redux'
import { SafeAreaView } from 'react-native'

import Toast from './src/components/common/Toast'
import { store } from './src/redux/store'
import AppNavigator from './src/navigation/AppNavigator'

export default () => (
  <Provider store={store}>
    <SafeAreaView style={{ flex: 1 }}>
      <StatusBar style="auto" translucent />
      <AppNavigator />
      <Toast />
    </SafeAreaView>
  </Provider>
)
