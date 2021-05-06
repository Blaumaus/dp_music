import { makeStyles } from '@material-ui/core/styles';
const useStyles = makeStyles((theme) => ({
  paper: {
    marginTop: theme.spacing(8),
    display: 'flex',
    flexDirection: 'column',
    alignItems: 'center',
  },
  avatar: {
    position: 'relative',
    left: '50%',
    transform: 'translate(-50%, 0)',
    width: '4em',
    height: '4em',
  },
  photoCamera: {
    position: 'relative',
    left: '50%',
    transform: 'translate(-50%, 0)',
    margin: theme.spacing(0.5),

    width: '4em',
  },
  form: {
    width: '100%',
    marginTop: theme.spacing(3),
  },
  submit: {
    margin: theme.spacing(3, 0, 2),
    width: '40%',
    position: 'relative',
    left: '50%',
    transform: 'translate(-50%, 0)',
  },
  selectEmpty: {
    marginTop: theme.spacing(5),
  },
  input: {
    display: 'none',
  },
  inputLabel: {
    position: 'relative',
    marginBottom: theme.spacing(-1),
  },
  snuckBarstyle: {
    position: 'relative',
    marginTop: theme.spacing(7),
    height: 'auto',
    fontSize: '1em',
  },
}));
export default useStyles;