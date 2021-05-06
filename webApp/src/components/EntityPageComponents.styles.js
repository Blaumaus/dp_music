import { makeStyles } from '@material-ui/core/styles';
import { BorderColor } from '@material-ui/icons';

const useStyles = makeStyles((theme) => ({
    root: {
        marginTop: theme.spacing(4),
        display: 'flex',

    },
    main: {
        marginLeft: '2%',
        marginRight: '2%',
    },
    avatar: {
        position: 'relative',
        left: '49%',
        transform: 'translate(-50%, 0)',
        width: 'auto',
        height: '12em',
        'border-radius': '5%',
    },
    upload: {
        position: 'relative',
        marginLeft: '50%',
        transform: 'translate(-50%, 0)',
        margin: theme.spacing(0.5),
        width: '4em',
    },
    paper: {
        padding: theme.spacing(2),
        borderColor: "#0275d8",
        '&:hover': {
            background: "#3f50b5",
            color: "white",
        },
    },
    
    paperForm: {
        marginTop: theme.spacing(8),
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
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
    buttonBack: {
        marginTop: theme.spacing(1),
        position: 'relative',
        left: '50%',
        transform: 'translate(-50%, 0)',
    },
    input: {
        display: 'none',
    },
}));

export default useStyles;