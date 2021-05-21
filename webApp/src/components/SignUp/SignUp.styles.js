import { makeStyles } from '@material-ui/core/styles';

const useStyles = makeStyles((theme) => ({
  paperDesktopStepFirst: {
    margin: 'auto',
    width: '60%',
    marginTop: '12vh',
    backgroundColor: '#fff',
    borderRadius: '14px',
    'box-shadow': '0 5px 5px -5px #333',
    'justify-content': 'center',
    'padding': '5% 15% 5% 15%'
  },
  paperMobileStepFirst: {
    margin: 'auto',
    width: '90%',
    backgroundColor: '#fff',
    borderRadius: '14px',
    'box-shadow': '0 5px 5px -5px #333',
    'justify-content': 'center',
    'padding': '2% 2% 5% 2%',
    marginTop: '12vh'
  },
  paperMobileLanugageSelecting: {
    margin: 'auto',
    width: '90%',
    backgroundColor: '#fff',
    borderRadius: '14px',
    'box-shadow': '0 5px 5px -5px #333',
    'justify-content': 'center',
    'padding': '2% 2% 5% 2%',
    marginTop: '2vh'
  },
  paperDesktopLanugageSelecting: {
    margin: 'auto',
    width: '60%',
    marginTop: '12vh',
    backgroundColor: '#fff',
    borderRadius: '14px',
    'box-shadow': '0 5px 5px -5px #333',
    'justify-content': 'center',
    'padding': '5% 10% 2% 10%',
  },
  form: {
    width: '100%',
  },
  textLabel: {
    marginBottom: theme.spacing(3),
    fontFamily: 'Roboto',
    'font-weight': 'bold',
    'color': '#363739',
  },
  signUpFieldsContainer: {
    'justify-content': 'center',
  },
  mediaCardContainer: {
    maxWidth: '100%',
  },
  media: {
    width: 'auto',
    height: 'auto',
    borderRadius: '8px',
    'box-shadow': '6px 7px 6px -1px #d8d4d4',
    alignItems: 'center'
  },
  selected: {
    width: 'auto',
    height: 'auto',
    borderRadius: '8px',
    'box-shadow': '0px 0px 14px 7px #35b4f3',
    alignItems: 'center'
  },
  disabled:{
    width: 'auto',
    height: 'auto',
    borderRadius: '8px',
    alignItems: 'center',
    'pointer-events': 'none',
    'filter': 'grayscale(100%)'
  },
  cardMeta: {
    'text-align': 'center',
    'font': 'normal normal medium 20px/20px Roboto;',
    'color': '#363739',
    'letter-spacing': '0px',
    opacity: 1,
    alignItems: 'center'
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
  mediaContainerDesktop: {
    'display': 'grid',
    'grid-template-columns': 'repeat(4,minmax(auto,200px))',
    'grid-gap': '1em',
    'grid-auto-rows': '1fr',
    'justify-content': 'center',
    'margin-top': '3em',
    'margin-bottom': '2em',
  },
  mediaContainerMobile: {
    'display': 'grid',
    'grid-template-columns': 'repeat(2,minmax(140px, max-content))',
    'grid-gap': '1em',
    'justify-content': 'center',
    'align-items': 'center',
    'margin-top': '2em',
    'margin-bottom': '2em',
  },
  lastStepButtonContainer: {
    'display': 'flex',
    'gap': theme.spacing(2),
  },
  buttonBackLastStepContainer: {
    width: '75%'
  },
  buttonNextContainer: {
    width: '25%'
  }
}));

export default useStyles;