import React from 'react';
import { withStyles } from '@material-ui/core/styles';
import Button from '@material-ui/core/Button';
import Dialog from '@material-ui/core/Dialog';
import MuiDialogTitle from '@material-ui/core/DialogTitle';
import MuiDialogContent from '@material-ui/core/DialogContent';
import MuiDialogActions from '@material-ui/core/DialogActions';
import IconButton from '@material-ui/core/IconButton';
import CloseIcon from '@material-ui/icons/Close';
import Typography from '@material-ui/core/Typography';
import moment from 'moment';

const styles = (theme) => ({
  root: {
    margin: 0,
    padding: theme.spacing(2),
  },
  closeButton: {
    position: 'absolute',
    right: theme.spacing(1),
    top: theme.spacing(1),
    color: theme.palette.grey[500],
  },
  showMoreButton: {
    width: '100%'
  },
});

const DialogTitle = withStyles(styles)((props) => {
  const { children, classes, onClose, ...other } = props;
  return (
    <MuiDialogTitle disableTypography className={classes.root} {...other}>
      <Typography variant="h6">{children}</Typography>
      {onClose ? (
        <IconButton aria-label="close" className={classes.closeButton} onClick={onClose}>
          <CloseIcon />
        </IconButton>
      ) : null}
    </MuiDialogTitle>
  );
});

const DialogContent = withStyles((theme) => ({
  root: {
    padding: theme.spacing(2),
  },
}))(MuiDialogContent);


export default function CustomizedDialogs(props) {
  const [open, setOpen] = React.useState(false);
  const foundationDate = moment(props.foundationDate).format('YYYY-MM-DD');
  const description = props.description;
  const countryCode = props.countryCode;

  const handleClickOpen = () => {
    setOpen(true);
  };
  const handleClose = () => {
    setOpen(false);
  };

  return (
    <div>
      <Button variant="text" onClick={handleClickOpen} style={{ width: '100%' }}>
        Детальніше
      </Button>
      <Dialog onClose={handleClose} aria-labelledby="customized-dialog-title" open={open}>
        <DialogTitle id="customized-dialog-title" onClose={handleClose}>
          {props.name}
        </DialogTitle>
        <DialogContent dividers>
          {props.foundationDate ? (<Typography gutterBottom>
            Дата створення: {foundationDate}
          </Typography>) : ('')}
          {countryCode ? (<Typography gutterBottom>
            Країна: {countryCode}
          </Typography>) : ('')}
          {description ? (<Typography gutterBottom>
            Опис: {description}
          </Typography>) : ('')}

        </DialogContent>
      </Dialog>
    </div>
  );
}