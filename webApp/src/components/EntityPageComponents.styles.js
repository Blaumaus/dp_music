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
        width: '20em',
        height: '15em',
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
        marginTop: theme.spacing(2),
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
        paddingBottom: theme.spacing(5),
        padding: '1em'
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
    buttonsFormContainer: {
        marginTop: '1em',
        display: 'flex',
        width: '100%',
        gap: '1em'
    },
    buttonBackContainer: {
        width: '25%'
    },
    buttonSubmitContainer: {
        width: '75%'
    },
    input: {
        display: 'none',
    },
    audioPlayer: {
        marginTop: theme.spacing(8),
        marginBottom: theme.spacing(8),
        marginLeft: '1em',
        marginRight: '1em',
        alignContent:'center',
        alignItems:'center'
    },
    compositionName: {
        padding: '0.5em'
    },
    audioPlayerCompositionName: {
        padding: '1em',
        'text-align': 'center'
    },
    arrayEmpty: {
        marginLeft: '10%',
        marginTop: theme.spacing(4),
        display: 'flex',
        fontSize: '2em'
    },
    compositonsActions: {
        display: 'flex',
        fontSize: '2em',
        'cursor': 'pointer',
        marginLeft: theme.spacing(2),
    },
    compositonsActionsContainer: {
        marginLeft: '2%',
        padding: theme.spacing(2),
    },
    listItem: {

        padding: theme.spacing(2),
        borderColor: "#0275d8",
        '&:hover': {
            backgroundColor: "#3f50b5",
            color: "blue",
        },
    },
    compositionIcons: {
        display: 'grid',
        'justify-items': 'center',
        'align-items': 'center',
        'cursor': 'pointer'
    },
    addCompositionButton: {
        marginTop: theme.spacing(1),
        position: 'relative',
        marginLeft: '50%',
        transform: 'translate(-50%, 0)',
        margin: theme.spacing(0.5),
        width: '4em',
        'cursor': 'pointer'
    },
    buttonsBackContainer: {
        display: 'flex',
        margin: '1em'
    }
}));

export default useStyles;