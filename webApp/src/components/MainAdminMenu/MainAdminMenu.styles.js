import { makeStyles } from '@material-ui/core/styles';
import { BorderColor } from '@material-ui/icons';

const useStyles = makeStyles((theme) => ({
    root: {
        marginTop: '2%',
       
    },
    main: {
        marginLeft: '2%',
        marginRight: '2%',
    },
    
    listItem: {
        padding: theme.spacing(2),
        borderColor: "#0275d8",
        '&:hover': {
            background: "#3f50b5",
            color: "white",
        },
    },
    buttonEdit: {
        position: 'relative',
        left: '50%',
        transform: 'translate(-50%, 0)',
    },
    buttonDelete: {
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
    arrayEmpty: {
        marginLeft: '10%',
        marginTop: theme.spacing(4),
        display: 'flex',
        fontSize:'2em'
    },
}));

export default useStyles;