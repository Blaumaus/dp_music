import { StyleSheet, Dimensions } from 'react-native'
import constants from '../redux/constants'
import { DefaultTheme } from '@react-navigation/native';

const getStyles = theme => StyleSheet.create({
  container: {
    minHeight: Dimensions.get('window').height,
    backgroundColor: theme === 'dark' ? constants.BACKGROUND_DARK_2 : constants.BACKGROUND_LIGHT,
    flexGrow: 1,
  },
  text: {
    color: theme === 'dark' ? constants.TEXT_LIGHT : constants.TEXT_DARK,
  },
})

export const getTheme = theme => ({
  ...DefaultTheme,
  dark: theme === 'dark',
  colors: {
    ...DefaultTheme.colors,
    primary: theme === 'dark' ? constants.BACKGROUND_DARK : constants.BACKGROUND_LIGHT,
    card: theme === 'dark' ? constants.BACKGROUND_DARK_2 : constants.BACKGROUND_LIGHT,
    border: theme === 'dark' ? constants.BACKGROUND_DARK : constants.BACKGROUND_LIGHT,
    background: theme === 'dark' ? constants.BACKGROUND_DARK : constants.BACKGROUND_LIGHT,
    text: theme === 'dark' ? constants.TEXT_LIGHT : constants.TEXT_DARK,
  }
})

export default getStyles
