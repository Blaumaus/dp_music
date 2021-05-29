import React from 'react'
import _filter from 'lodash/filter'
import _includes from 'lodash/includes'
import _map from 'lodash/map'
import { NavigationContainer, useRoute } from '@react-navigation/native'
import { createStackNavigator } from '@react-navigation/stack'
import { createDrawerNavigator, DrawerContentScrollView, DrawerItem } from '@react-navigation/drawer'
import { useTranslation } from 'react-i18next'

import { drawerWhitelist } from '../redux/constants'
import Signout from '../components/common/Signout'
import DetailedInfo from '../screens/common/DetailedInfo'
import Home from '../screens/Home'
import Bands from '../screens/Bands'
import Settings from '../screens/Settings'
import Signin from '../screens/auth/Signin'
import Signup from '../screens/auth/Signup'
import ForgotPassword from '../screens/auth/ForgotPassword'

const AuthStack = createStackNavigator()
const MainStack = createDrawerNavigator()
const RootStack = createStackNavigator()

const CustomDrawerContent = ({ navigation, t, ...props }) => (
  <DrawerContentScrollView navigation={navigation} {...props}>
    {_map(drawerWhitelist, el => (
      <DrawerItem
        key={el}
        label={t(`drawer.${el}`)}
        onPress={() => navigation.navigate(el)}
        // focused={??? === el}
      />
    ))}
  </DrawerContentScrollView>
)

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

const Main = () => {
  const { t } = useTranslation('common')

  return (
    <MainStack.Navigator
      screenOptions={{
        headerShown: false,
      }}
      initialRouteName="Home"
      drawerContent={props => <CustomDrawerContent t={t} {...props} />}
    >
      <MainStack.Screen name="home" component={Home} />
      <MainStack.Screen name="settings" component={Settings} />
      <MainStack.Screen name="logout" component={Signout} />
      <MainStack.Screen name="Bands" component={Bands} />
      <MainStack.Screen name="DetailedInfo" component={DetailedInfo} />
    </MainStack.Navigator>
  )
}

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

export default () => (
  <NavigationContainer>
    <Root />
  </NavigationContainer>
)
