import { StyleSheet, Dimensions } from 'react-native'
import constants from '../../redux/constants'

const styles = theme => StyleSheet.create({
  keyboardView: {
    flex: 1,
  },
  container: {
    minHeight: Dimensions.get('window').height,
    flexGrow: 1,
  },
  imageContainer: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    backgroundColor: theme === 'dark' ? constants.BACKGROUND_DARK_2 : constants.BACKGROUND_LIGHT_2,
  },
  image: {
    height: 220,
    width: 220,
  },
  form: {
    flex: 3,
    paddingHorizontal: 20,
    paddingBottom: 20,
    backgroundColor: theme === 'dark' ? constants.BACKGROUND_DARK : constants.BACKGROUND_LIGHT,
  },
  formHeader: {
    fontSize: 20,
    alignSelf: 'center',
    paddingTop: 20,
    paddingBottom: 10,
  },
  actionButton: {
    marginTop: 10,
  },
  bottomText: {
    marginLeft: 5,
  },
  text: {
    color: theme === 'dark' ? constants.TEXT_LIGHT : constants.TEXT_DARK,
  },
  secondaryContainer: {
    flexDirection: 'row',
    alignItems: 'center',
    marginTop: 15,
    justifyContent: 'center',
  },
  tertiaryContainer: {
    flexDirection: 'row',
    alignItems: 'center',
    marginTop: 10,
    justifyContent: 'center',
  },
  mt10: {
    marginTop: 10,
  },
  link: {
    color: '#3366ff',
  }
})

export default styles
