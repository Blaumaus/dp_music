import { makeStyles } from '@material-ui/core/styles';

const useStyles = makeStyles((theme) => ({
  paperDesktop: {
    margin: 'auto',
    width: '60%',
    marginTop: '12vh',
    backgroundColor: '#fff',
    borderRadius: '14px',
    'box-shadow': '0 5px 5px -5px #333',
    'justify-content': 'center',
    'padding': '5% 15% 5% 15%'
  },
  paperMobile: {
    margin: 'auto',
    width: '90%',
    backgroundColor: '#fff',
    borderRadius: '14px',
    'box-shadow': '0 5px 5px -5px #333',
    'justify-content': 'center',
    'padding': '30% 2% 5% 2%',
    marginTop: '12vh'
  },
  form: {
    width: '100%',
  },
  signUpFieldsContainer: {
    'justify-content': 'center',
  },
  textField: {
    height: '50px'
  },
  stepButton: {
    width: '100%',
    height: '50px'
  },
  alreadyHaveAccountGridItem: {
    marginTop: theme.spacing(3),
  },
  
}));

export default useStyles;