import { makeStyles } from '@material-ui/core/styles';
const useStyles = makeStyles((theme) => ({

    paper: {
        marginTop: '5%',
        width: '80%',
        display: 'flex',
        margin: 'auto'
    },
    fullWidthButton: {
        width: '100%',
    },
    modeChoiceText: {
        'font-size': 'calc(10px + 2vw)'
    },
    
    mediaCardContainer: {
        maxWidth: '100%',

    },
    media: {
        width: 'auto',
        height: '25em',
    },
    buttonsBackContainer: {
        display: 'flex',
        margin: '1em'
    }

}));

export default useStyles;