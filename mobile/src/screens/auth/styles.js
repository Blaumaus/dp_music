import { StyleSheet } from 'react-native'

const styles = StyleSheet.create({
  keyboardView: {
    flex: 1,
  },
  container: {
    flexGrow: 1,
  },
  imageContainer: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    backgroundColor: '#f7f7f7',
  },
  image: {
    height: 220,
    width: 220,
  },
  form: {
    flex: 3,
    paddingHorizontal: 20,
    paddingBottom: 20,
    backgroundColor: '#fff',
  },
  formHeader: {
    alignSelf: 'center',
    padding: 30,
  },
  actionButton: {
    marginTop: 20,
  },
  bottomText: {
    marginLeft: 5,
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
  mt15: {
    marginTop: 15,
  }
})

export default styles
