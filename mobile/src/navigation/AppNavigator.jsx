import React from 'react'
import { NavigationContainer } from '@react-navigation/native'
import { createStackNavigator } from '@react-navigation/stack'
import { createDrawerNavigator } from '@react-navigation/drawer'

import Signout from '../components/common/Signout'
import Home from '../screens/Home'
import Settings from '../screens/Settings'
import Signin from '../screens/auth/Signin'
import Signup from '../screens/auth/Signup'
import ForgotPassword from '../screens/auth/ForgotPassword'

const AuthStack = createStackNavigator()
const MainStack = createDrawerNavigator()
const RootStack = createStackNavigator()

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
    initialRouteName="Home"
  >
    <MainStack.Screen name="Home" component={Home} />
    <MainStack.Screen name="Settings" component={Settings} />
    <MainStack.Screen name="Sign out" component={Signout} />
  </MainStack.Navigator>
)

const Root = () => (
  <RootStack.Navigator
    screenOptions={{
      headerShown: false,
    }}
    initialRouteName="Auth"
  >
    <MainStack.Screen name="Main" component={Main} />
    <MainStack.Screen name="Auth" component={Auth} />
  </RootStack.Navigator>
)

export default () => {
  // TODO: Check if user is authorised
  return (
    <NavigationContainer>
      <Root />
    </NavigationContainer>
  )
}
