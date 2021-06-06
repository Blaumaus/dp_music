import React from 'react'
import { useSelector } from 'react-redux'
import _filter from 'lodash/filter'
import _includes from 'lodash/includes'
import _map from 'lodash/map'
import { NavigationContainer } from '@react-navigation/native'
import { createStackNavigator, HeaderBackButton } from '@react-navigation/stack'
import { createDrawerNavigator, DrawerContentScrollView, DrawerItem } from '@react-navigation/drawer'
import { useTranslation } from 'react-i18next'

import { drawerWhitelist } from '../redux/constants'
import getStyles, { getTheme } from './styles'
import Signout from '../components/common/Signout'
import DetailedInfo from '../screens/common/DetailedInfo'
import Home from '../screens/Home'
import Bands from '../screens/Bands'
import Albums from '../screens/Albums'
import Songs from '../screens/Songs'
import Settings from '../screens/Settings'
import Signin from '../screens/auth/Signin'
import Signup from '../screens/auth/Signup'
// import ForgotPassword from '../screens/auth/ForgotPassword'

const AuthStack = createStackNavigator()
const MainStack = createDrawerNavigator()
const RootStack = createStackNavigator()

const CustomDrawerContent = ({ navigation, t, theme, ...props }) => {
  const styles = getStyles(theme)

  return (
    <DrawerContentScrollView navigation={navigation} style={styles.container} {...props}>
      {_map(drawerWhitelist, el => (
        <DrawerItem
          key={el}
          label={t(`drawer.${el}`)}
          onPress={() => navigation.navigate(el)}
          labelStyle={styles.text}
        // focused={??? === el}
        />
      ))}
    </DrawerContentScrollView>
  )
}

const Auth = () => (
  <AuthStack.Navigator
    screenOptions={{
      headerShown: false,
    }}
  >
    <AuthStack.Screen name="Auth.Signin" component={Signin} />
    <AuthStack.Screen name="Auth.Signup" component={Signup} />
    {/* <AuthStack.Screen name="Auth.ForgotPassword" component={ForgotPassword} /> */}
  </AuthStack.Navigator>
)

const Main = () => {
  const { t } = useTranslation('common')
  const theme = useSelector(state => state.themeReducer?.theme)

  return (
    <MainStack.Navigator
      screenOptions={{
        headerShown: true,
      }}
      initialRouteName="Home"
      drawerContent={props => <CustomDrawerContent t={t} theme={theme} {...props} />}
      drawerType="front"
    >
      <MainStack.Screen name="home" options={{ title: t(`drawer.home`) }} component={Home} />
      <MainStack.Screen name="settings" options={{ title: t(`drawer.settings`) }} component={Settings} />
      <MainStack.Screen name="logout" component={Signout} />
      <MainStack.Screen
        name="bands"
        options={({ navigation }) => ({
          title: t('drawer.bands'),
          headerLeft: () => <HeaderBackButton onPress={() => navigation.goBack()} />,
        })}
        component={Bands}
      />
      <MainStack.Screen
        name="albums"
        options={({ navigation }) => ({
          title: t('drawer.albums'),
          headerLeft: () => <HeaderBackButton onPress={() => navigation.goBack()} />,
        })}
        component={Albums}
      />
      <MainStack.Screen
        name="songs"
        options={({ navigation }) => ({
          title: t('drawer.songs'),
          headerLeft: () => <HeaderBackButton onPress={() => navigation.goBack()} />,
        })}
        component={Songs}
      />
      <MainStack.Screen
        name="detailedInfo"
        options={({ navigation }) => ({
          title: t(`drawer.detailedInfo`),
          headerLeft: () => <HeaderBackButton onPress={() => navigation.goBack()} />,
        })}
        component={DetailedInfo}
      />
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

export default () => {
  const theme = getTheme(useSelector(state => state.themeReducer?.theme))

  return (
    <NavigationContainer theme={theme}>
      <Root />
    </NavigationContainer>
  )
}
