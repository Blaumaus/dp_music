import React from 'react'
import { NavigationContainer } from '@react-navigation/native'
import { createStackNavigator } from '@react-navigation/stack'

import Home from '../screens/Home'
import Signin from '../screens/auth/Signin'
import Signup from '../screens/auth/Signup'
import ForgotPassword from '../screens/auth/ForgotPassword'
import Loading from '../screens/common/Loading'

const AuthStack = createStackNavigator()
const MainStack = createStackNavigator()

const Auth = () => (
  <AuthStack.Navigator
    screenOptions={{
      headerShown: false,
    }}
  >
    <AuthStack.Screen name="Auth.Signin" component={Signin} />
    <AuthStack.Screen name="Auth.Signup" component={Signup} />
    <AuthStack.Screen name="Auth.ForgotPassword" component={ForgotPassword} />
  </AuthStack.Navigator>
)

const Main = () => (
  <MainStack.Navigator
    screenOptions={{
      headerShown: false,
    }}
  >
    <MainStack.Screen name="Home" component={Home} />
  </MainStack.Navigator>
)

export default () => {
  // TODO: Check if user is authorised
  return (
    <NavigationContainer>
      {/* <Loading /> */}
      <Auth />
      {/* <Main /> */}
    </NavigationContainer>
  )
}
