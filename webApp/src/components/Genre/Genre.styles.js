import { makeStyles } from '@material-ui/core/styles';

const useStyles = makeStyles((theme) => ({
    root: {
        marginTop: theme.spacing(4),
        display: 'flex',
    
    },
    paper: {
        padding: theme.spacing(2),

    },
    buttonEdit: {
        position: 'relative',
        left: '50%',
        transform: 'translate(-50%, 0)',
        
    },
     buttonCreate: {
        marginTop: theme.spacing(4),
        position: 'relative',
        left: '50%',
        transform: 'translate(-50%, 0)',       
    },


}));

export default useStyles;