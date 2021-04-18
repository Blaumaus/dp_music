import React, { useCallback } from 'react';
import Button from '@material-ui/core/Button';
import CssBaseline from '@material-ui/core/CssBaseline';
import TextField from '@material-ui/core/TextField';
import Grid from '@material-ui/core/Grid';
import Container from '@material-ui/core/Container';
import useStyles from './Profile.styles'
import { useEffect, useState } from 'react';
import ProfileApi from './../../api/modules/profile'
import { Formik, Form, ErrorMessage } from 'formik'
import * as yup from 'yup';
import Snackbar from '@material-ui/core/Snackbar';
import MuiAlert from '@material-ui/lab/Alert';

export default function Profile(props) {

  const classes = useStyles();
  const [user, setUser] = useState(null); 
  const [loading, setLoading] = useState(false);
  const [isUpdateData, setIsUpdateData] = useState(false);

  const phoneRegExp = /^((\+[1-9]{1,4}[ \\-]*)|(\\([0-9]{2,3}\\)[ \\-]*)|([0-9]{2,4})[ \\-]*)*?[0-9]{3,4}?[ \\-]*[0-9]{3,4}?$/
  const emailRegExp = /^[^@]+@[^@]+\.[^@]+$/

  function Alert(props) {
    return <MuiAlert elevation={6} variant="filled" {...props} />;
  }
  const validationSchema = yup.object({  
    email: yup.string()
      .required("Please enter the required field")
      .matches(emailRegExp, "Incorrect email "),
    phone: yup.string()
      .matches(phoneRegExp, "Incorrect phone "),

  });

  const onChange = (event) => {
    const name = event.target.name;
    setUser({ ...user, [name]: event.target.value })
  };


  const loadInitialData = async () => {
    try {
      const userResponse = await ProfileApi.getUserInfo(1); // TODO: Remove this hardcoded userId
      setUser(userResponse.data);
        
    } catch (e) {
      console.error(e)
    }
  }
  useEffect(() => {
    loadInitialData();
    setLoading(true);
  }, []);

  const handleSubmit = async () => {
    const userToSubmit = {
      ...user
    }
    await ProfileApi.updateUserInfo(userToSubmit);
    setIsUpdateData(true);
  }
  const handleCloseAlert = (event, reason) => {
    if (reason === 'clickaway') {
      return;
    }
    setIsUpdateData(false);
  };

  return (
    <Container component="main" maxWidth="xs">
      <CssBaseline />
      {loading && (
        <div className={classes.paper}>
          <Formik className={classes.form} enableReinitialize={true}
            initialValues={{ ...user }}
            validationSchema={validationSchema}
            onSubmit={handleSubmit}
          >
            {({ handleSubmit, values, touched, errors }) => (
              <Form onSubmit={handleSubmit}>
                <Grid container spacing={2}>
                <Grid item xs={12}>
                    <TextField
                      onChange={onChange}
                      id="email"
                      name="email"
                      variant="outlined"
                      value={values.email}
                      autoComplete="email"
                      label="Email"
                      fullWidth
                      error={touched.email && Boolean(errors.email)}
                      helperText={touched.email && errors.email}
                    />
                  </Grid>
                  <Grid item xs={12}>
                    <TextField
                      onChange={onChange}
                      name="phone"
                      id="phone"
                      variant="outlined"
                      value={values.phone}
                      label="Phone"
                      fullWidth
                      error={touched.phone && Boolean(errors.phone)}
                      helperText={touched.phone && errors.phone}
                    />
                  </Grid>    
                </Grid>
                                   
                <Button
                  type="submit"
                  fullWidth
                  variant="contained"
                  color="primary"
                  className={classes.submit}
                >
                  Save
                </Button>
                <Grid item xs={12}>
                  <Snackbar className={classes.snuckBarstyle} open={isUpdateData} autoHideDuration={2000} onClose={handleCloseAlert} anchorOrigin={{
                    vertical: 'top',
                    horizontal: 'center'
                  }}>
                    <Alert onClose={handleCloseAlert} severity="success" >
                      Data has been successfully updated
                  </Alert>
                  </Snackbar>
                </Grid>

              </Form>
            )}
          </Formik>
        </div>
      )
      }
    </Container >
  );
}
