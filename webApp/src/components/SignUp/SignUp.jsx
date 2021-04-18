// import React, { useEffect, useState } from 'react';
// import Avatar from '@material-ui/core/Avatar';
// import TextField from '@material-ui/core/TextField';
// import CssBaseline from '@material-ui/core/CssBaseline';
// import { makeStyles } from '@material-ui/core/styles';
// import Button from '@material-ui/core/Button';
// import Container from '@material-ui/core/Container';
// import LockOutlinedIcon from '@material-ui/icons/LockOutlined';
// import Typography from '@material-ui/core/Typography';
// import Grid from '@material-ui/core/Grid';
// import IconButton from '@material-ui/core/IconButton';
// import Visibility from '@material-ui/icons/Visibility';
// import VisibilityOff from '@material-ui/icons/VisibilityOff';
// import OutlinedInput from '@material-ui/core/OutlinedInput';
// import InputLabel from '@material-ui/core/InputLabel';
// import InputAdornment from '@material-ui/core/InputAdornment';
// import AccountApi from '../../api/modules/account';
// import LanguageApi from '../../api/modules/language';
// import Select from '@material-ui/core/Select';
// import FormControl from '@material-ui/core/FormControl';
// import Stepper from '@material-ui/core/Stepper';
// import Step from '@material-ui/core/Step';
// import StepLabel from '@material-ui/core/StepLabel';
// import DateFnsUtils from '@date-io/date-fns';
// import {
//   MuiPickersUtilsProvider,
//   KeyboardDatePicker,
// } from '@material-ui/pickers';
// import { Formik, Form } from 'formik'
// import * as yup from 'yup';

// const useStyles = makeStyles((theme) => ({
//   paper: {
//     marginTop: theme.spacing(8),
//     display: 'flex',
//     flexDirection: 'column',
//     alignItems: 'center',
//   },
//   avatar: {
//     margin: theme.spacing(1),
//     backgroundColor: theme.palette.secondary.main,
//   },
//   form: {
//     width: '100%', // Fix IE 11 issue.
//     marginTop: theme.spacing(2),
//   },
//   inputLabel: {
//     marginBottom: theme.spacing(-1),
//     position: 'relative',
//     transform: 'translate(14px, -6px) scale(0.75)',
//   },
//   stepper: {
//     width: '90%',
//     position: 'inherit',
//     padding: 0,
//     margin: '5% 5% 10% 5%',
//     'background-color': 'inherit',
//   },
//   buttonsGrid: {
//     'margin-top': '2%',
//   },
//   errorLabel: {
//     'font-size': '0.75rem',
//     'margin-top': '3px',
//     'text-align': 'left',
//     'font-family': '"Roboto", "Helvetica", "Arial", sans-serif',
//     'font-weight': '400',
//     'line-height': '1.66',
//     'letter-spacing': '0.03333em',
//     color: '#f44336',
//     'margin-left': '14px',
//     'margin-right': '14px',
//   },/*  */
//   registrationFinishedText: {
//     'text-align': 'center',
//     'margin-top': '30%',
//   },
// }));

// const SignUp = (props) => {
//   const classes = useStyles();
//   const [user, setUser] = React.useState({
//     userName: "",
//     firstName: "",
//     lastName: "",
//     email: "",
//     password: "",
//     confirmPassword: "",
//     phone: "",
//     dateBirth: null,
//     nativeLanguageId: 0,
//     targetLanguageId: 1,
//     avatar: "",
//     showPassword: false,
//     showConfirmPassword: false,
//   });
//   const [nativelanguages, setNativeLanguages] = useState([]);
//   const [targetlanguages, setTargetLanguages] = useState([]);
//   const [loading, setLoading] = useState(true);
//   const [activeStep, setActiveStep] = React.useState(0);
//   const [selectedDate, setSelectedDate] = useState(new Date());
//   const [selectedLanguage, setSelectedLanguage] = useState([]);
//   const phoneRegExp = /^((\+[1-9]{1,4}[ \\-]*)|(\\([0-9]{2,3}\\)[ \\-]*)|([0-9]{2,4})[ \\-]*)*?[0-9]{3,4}?[ \\-]*[0-9]{3,4}?$/
//   const emailRegExp = /^[^@]+@[^@]+\.[^@]+$/
//   const validationSchema = yup.object({
//     userName: yup
//       .string()
//       .required('Username required'),
//     email: yup
//       .string()
//       .required('Email required')
//       .matches(emailRegExp, 'Incorrect email'),
//     firstName: yup
//       .string()
//       .required('First Name required'),
//     lastName: yup
//       .string()
//       .required('Last Name required'),
//     password: yup
//       .string()
//       .required('Password required'),
//     confirmPassword: yup
//       .string()
//       .oneOf([yup.ref('password'), null], "Passwords don't match!")
//       .required('Confirm password required'),
//     phone: yup
//       .string()
//       .matches(phoneRegExp, 'Incorrect phone'),
//     nativeLanguageId: yup
//       .number(),
//     targetLanguageId: yup
//       .number()
//       .test('', (value) =>
//         Promise.resolve(value != user.nativeLanguageId),
//   )});

//   useEffect(() => {
//     loadInitialLanguagesData();
//     setLoading(false);
//   }, []);

//   const handleSubmit = async () => (
//     (activeStep === steps.length - 1) ? (
//       setActiveStep((prevActiveStep) => prevActiveStep + 1),
//       AccountApi.register(user)
//     ) : (
//       setActiveStep((prevActiveStep) => prevActiveStep + 1))
//   );
  
//   const handleLanguageChange = (event) => {
//     const name = event.target.name;
//     setSelectedLanguage({
//       ...selectedLanguage,
//       [name]: event.target.value
//     })
//     setUser({
//       ...user,
//       [name]: +event.target.value
//     })
//   };

//   const handleClickShowPassword = () => {
//     setUser({ ...user, showPassword: !user.showPassword });
//   };

//   const handleClickShowConfirmPassword = () => {
//     setUser({ ...user, showConfirmPassword: !user.showConfirmPassword });
//   };

//   const handleMouseDownPassword = (event) => {
//     event.preventDefault();
//   };

//   const handleMouseDownConfirmPassword = (event) => {
//     event.preventDefault();
//   };

//   const handleChange = (event) => {
//     const { name, value } = event.target
//     setUser(prevState => ({
//       ...prevState,
//       [name]: value
//     }))
//   };

//   const setLanguage = (data) => {
//     const languages = Array.isArray(data) ? data : Object.values(data);
//     try {
//       setNativeLanguages(languages);
//       setTargetLanguages(languages);
//     }
//     catch (e) {
//       console.error(e)
//     }
//   }

//   const loadTranslations = async (languageId) => {
//     const { data } = await LanguageApi.getLanguage(languageId);
//     setLanguage(data)
//   }

//   const loadInitialLanguagesData = async () => {
//     const languageIso = window.navigator.language;
//     const { data } = await LanguageApi.getLanguageByIso(languageIso);
//     loadInitialLanguagesTranslations(data);
//     setSelectedLanguage({ ...selectedLanguage, nativeLanguageId: data.languageIdToTranslate });
//     setUser({ ...user, nativeLanguageId: data.languageIdToTranslate });
//   }

//   const loadInitialLanguagesTranslations = async (browserLanguageData) => {
//     try {
//       const nativeLanguageId = browserLanguageData.languageIdToTranslate;
//       const { data } = await LanguageApi.getLanguage(nativeLanguageId);
//       setLanguage(data)
//     } catch (e) {
//       console.error(e)
//     }
//   }

//   const handleDateChange = (date) => {
//     setSelectedDate(date)
//     user.dateBirth = date
//   };

//   const handleBack = () => {
//     setActiveStep((prevActiveStep) => prevActiveStep - 1);
//   };

//   const getSteps = () => {
//     return ['Main data', 'Additional data'];
//   }

//   const steps = getSteps();

//   const getStepContent = (step, values, touched, errors) => {
//     switch (step) {
//       case 0:
//         return <Grid container spacing={2}>
//           <Grid item xs={12}>
//             <TextField
//               fullWidth
//               autoFocus
//               name="userName"
//               label="User name"
//               variant="outlined"
//               value={values.userName || ''}
//               onChange={handleChange}
//               error={touched.userName && Boolean(errors.userName)}
//               helperText={touched.userName && errors.userName} />
//           </Grid>
//           <Grid item xs={12}>
//             <TextField
//               fullWidth
//               name="email"
//               label="Email"
//               variant="outlined"
//               value={values.email || ''}
//               onChange={handleChange}
//               error={touched.email && Boolean(errors.email)}
//               helperText={touched.email && errors.email} />
//           </Grid>
//           <Grid item xs={12} sm={6}>
//             <TextField
//               fullWidth
//               name="firstName"
//               label="First name"
//               variant="outlined"
//               value={values.firstName}
//               onChange={handleChange}
//               error={touched.firstName && Boolean(errors.firstName)}
//               helperText={touched.firstName && errors.firstName} />
//           </Grid>
//           <Grid item xs={12} sm={6}>
//             <TextField
//               fullWidth
//               name="lastName"
//               label="Last name"
//               variant="outlined"
//               value={values.lastName}
//               onChange={handleChange}
//               error={touched.lastName && Boolean(errors.lastName)}
//               helperText={touched.lastName && errors.lastName} />
//           </Grid>
//           <Grid item xs={12}>
//             {touched.password && errors.password ? (<InputLabel className={classes.inputLabel}></InputLabel>) : (<InputLabel className={classes.inputLabel}>Password</InputLabel>)}
//             <OutlinedInput
//               id="password"
//               name="password"
//               fullWidth
//               type={values.showPassword ? 'text' : 'password'}
//               value={values.password}
//               onChange={handleChange}
//               error={touched.password && Boolean(errors.password)}
//               endAdornment={
//                 <InputAdornment position="end">
//                   <IconButton
//                     aria-label="toggle password visibility"
//                     onClick={handleClickShowPassword}
//                     onMouseDown={handleMouseDownPassword}
//                     edge="end"
//                   >
//                     {values.showPassword ? <Visibility /> : <VisibilityOff />}
//                   </IconButton>
//                 </InputAdornment>
//               }
//             />
//             <InputLabel className={classes.errorLabel}>{touched.password && errors.password}</InputLabel>
//           </Grid>
//           <Grid item xs={12}>
//             {touched.confirmPassword && errors.confirmPassword ? (<InputLabel className={classes.inputLabel}></InputLabel>) : (<InputLabel className={classes.inputLabel}>Confirm password</InputLabel>)}
//             <OutlinedInput
//               id="confirmPassword"
//               name="confirmPassword"
//               fullWidth
//               type={values.showConfirmPassword ? 'text' : 'password'}
//               value={values.confirmPassword}
//               onChange={handleChange}
//               error={touched.confirmPassword && Boolean(errors.confirmPassword)}
//               endAdornment={
//                 <InputAdornment position="end">
//                   <IconButton
//                     aria-label="toggle confirmPassword visibility"
//                     onClick={handleClickShowConfirmPassword}
//                     onMouseDown={handleMouseDownConfirmPassword}
//                     edge="end"
//                   >
//                     {values.showConfirmPassword ? <Visibility /> : <VisibilityOff />}
//                   </IconButton>
//                 </InputAdornment>
//               }
//             />
//             <InputLabel className={classes.errorLabel}>{touched.confirmPassword && errors.confirmPassword}</InputLabel>
//           </Grid>
//         </Grid>;
//       case 1:
//         return <Grid container spacing={2}>
//           <Grid item xs={12}>
//             <TextField
//               fullWidth
//               autoFocus
//               name="phone"
//               label="Phone"
//               variant="outlined"
//               value={values.phone}
//               onChange={handleChange}
//               error={touched.phone && Boolean(errors.phone)}
//               helperText={touched.phone && errors.phone} />
//           </Grid>
//           <Grid item xs={12}>
//             <MuiPickersUtilsProvider utils={DateFnsUtils}>
//               <KeyboardDatePicker
//                 autoOk
//                 fullWidth
//                 variant="inline"
//                 name="dateBirth"
//                 inputVariant="outlined"
//                 label="Birth date"
//                 format="MM/dd/yyyy"
//                 value={selectedDate}
//                 InputAdornmentProps={{ position: "start" }}
//                 onChange={date => handleDateChange(date)}
//               />
//             </MuiPickersUtilsProvider>
//           </Grid>
//           <Grid item xs={12} sm={6}>
//             <FormControl variant="outlined" className={classes.form}>
//               <InputLabel shrink className={classes.inputLabel} >Native Language</InputLabel>
//               <Select
//                 native
//                 value={selectedLanguage.nativeLanguageId || ''}
//                 onChange={(e => {
//                   handleLanguageChange(e)
//                   loadTranslations(e.target.value)
//                 })}
//                 inputProps={{
//                   name: 'nativeLanguageId',
//                   id: 'nativeLanguageId',
//                 }}
//               >
//                 {nativelanguages.map((option) => {
//                   return <option value={option.languageIdToTranslate} key={option.meaning}>{option.meaning}</option>
//                 })}
//               </Select>
//             </FormControl>
//           </Grid>
//           <Grid item xs={12} sm={6}>
//             <FormControl variant="outlined" className={classes.form} >
//               <InputLabel shrink className={classes.inputLabel}>Target Language</InputLabel>
//               <Select
//                 native
//                 value={selectedLanguage.targetLanguageId || ''}
//                 onChange={handleLanguageChange}
//                 error={touched.targetLanguageId && Boolean(errors.targetLanguageId)}
//                 inputProps={{
//                   name: 'targetLanguageId',
//                   id: 'targetLanguageId',
//                 }}
//               >
//                 {targetlanguages.map((option) => {
//                   return <option value={option.languageIdToTranslate} key={option.meaning}>{option.meaning}</option>
//                 })}
//               </Select>
//             </FormControl>
//           </Grid>
//         </Grid>;
//       default:
//         return 'Unknown step';
//     }
//   }
//   return (
//     <Container component="main" maxWidth="xs">
//       <CssBaseline />
//       {!loading && (
//         <div className={classes.paper}>
//           <Avatar className={classes.avatar}>
//             <LockOutlinedIcon />
//           </Avatar>
//           <Typography component="h1" variant="h5">
//             Sign up
//           </Typography>
//           <Formik className={classes.form} enableReinitialize={true}
//             initialValues={{ ...user }}
//             validationSchema={validationSchema}
//             onSubmit={handleSubmit}
//           >
//             {({ handleSubmit, values, touched, errors }) => (
//               <Form onSubmit={handleSubmit}>
//                 <Stepper className={classes.stepper} activeStep={activeStep}>
//                   {steps.map((label, index) => {
//                     const stepProps = {};
//                     const labelProps = {};
//                     return (
//                       <Step key={label} {...stepProps}>
//                         <StepLabel {...labelProps}>{label}</StepLabel>
//                       </Step>
//                     );
//                   })}
//                 </Stepper>
//                 <div>
//                   {activeStep === steps.length ? (
//                     <div>
//                       <Typography variant="h4" className={classes.registrationFinishedText}>Congratulations!<br />You have successfully registered</Typography>
//                     </div>
//                   ) : (
//                     <Grid container spacing={2} >
//                       {getStepContent(activeStep, values, touched, errors)}
//                       <Grid item xs={12} sm={6} className={classes.buttonsGrid}>
//                         <Button
//                           fullWidth
//                           variant="contained"
//                           disabled={activeStep === 0}
//                           onClick={handleBack}
//                           className={classes.backButton}
//                           name="backButton"
//                         >
//                           Back
//                     </Button>
//                       </Grid>
//                       <Grid item xs={12} sm={6} className={classes.buttonsGrid}>
//                         {activeStep === steps.length - 1 ? (
//                           <Button fullWidth variant="contained" color="primary" name="registerButton" type="submit" onClick={handleSubmit}>
//                             Register
//                           </Button>
//                         ) : (
//                           <Button fullWidth variant="contained" color="primary" name="nextButton" onClick={handleSubmit} >
//                             Next
//                           </Button>
//                         )}
//                       </Grid>
//                     </Grid>
//                   )}
//                 </div>
//               </Form>
//             )}
//           </Formik>
//         </div>
//       )}
//     </Container >
//   )
// }
// export default SignUp;