import { makeStyles } from '@material-ui/core/styles';
const useStyles = makeStyles((theme) => ({
    root: {
        flexGrow: 1
    },
    menuButton: {
        marginRight: theme.spacing(2),
        color: 'white'
    },
    title: {
        [theme.breakpoints.down("xs")]: {
            flexGrow: 1
        },
        color:'white'
    },
    headerOptions: {
        display: "flex",
        flex: 1,
    },
    menuButtonMargin: {
        marginLeft: 'auto',
        marginRight: 0,
    },
    avatar: {
        position: 'relative',
        marginLeft: theme.spacing(2),
        transform: 'translate(-50%, 0)',
        width: '1.5em',
        height: '1.5em',
    },
}));

export default useStyles;