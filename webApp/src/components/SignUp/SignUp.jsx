import React from 'react';
import { Typography } from 'antd';
import { Formik } from 'formik';
import * as yup from 'yup';
import { Link } from 'react-router-dom';
import useStyles from './SignUp.styles';
import 'antd/dist/antd.css';
import './SignUp.css';
import { Input, Button, Row, Col } from 'antd';
import { Form } from 'formik-antd';
import { ArrowRightOutlined, ArrowLeftOutlined } from '@ant-design/icons';

const { Text, Title } = Typography;

const SignUp = props => {
  const classes = useStyles();

  const {
    user,
    isValidatingUserName,
    isValidatedUserName,
    isValidatingEmail,
    isValidatedEmail,
    onChange,
    validateUserName,
    validateEmail,
    handleSubmit,
    handleUserNameFieldChange,
    handleEmailFieldChange,
    isValidEmail,
    isValidUserName,
    isMobile,
  } = props;

  const emailRegExp = /^[^@]+@[^@]+\.[^@]+$/
  const validationSchema = yup.object({
    userName: yup
      .string()
      .required(`Нікнейм є обов'язковим`)
      .test({
        name: 'userName',
        message: 'Такий Нікнейм уже існує',
        exclusive: true,
        test: (isValid) => {
          if (user.userName !== '' && isValidatedUserName === false) {
            isValid = validateUserName();

            return isValid;
          }
          return true;
        }
      }),
    email: yup
      .string()
      .required(`Адреса є обов'язковою`)
      .email('Невірна адреса')
      .test({
        name: 'email',
        exclusive: true,
        message: 'Така адреса уже існує',
        test: (isValid) => {
          if (user.email !== '' && isValidatedEmail === false && emailRegExp.test(user.email)) {
            isValid = validateEmail();
            return isValid;
          }
          return true;
        }
      }),
    password: yup
      .string()
      .required(`Пароль є обов'язковим`),
    confirmPassword: yup
      .string()
      .oneOf([yup.ref('password'), null], "Passwords don't match!")
      .required(`Підтвердження паролю є обов'язковим`)
  });
  const onFieldChange = (event) => {
    const fieldName = event.target.name;
    const fieldValue = event.target.value;
    onChange(fieldName, fieldValue);
  };

  const handleBlur = () => { };

  const getValidationStatusUserName = () => {
    if (isValidatingUserName) {
      return 'validating'
    }
    if (isValidatedUserName && isValidatingUserName === false) {
      if (isValidUserName) {
        return 'success'
      }
      return 'error'
    } else {
      return ''
    }
  };

  const getValidationStatusEmail = () => {
    if (isValidatingEmail) {
      return 'validating'
    }
    if (isValidatedEmail && isValidatingEmail === false) {
      if (isValidEmail) {
        return 'success'
      }
      return 'error'
    } else {
      return ''
    }
  };

  const getRegistrationForm = (values, touched, errors) => {

    return <div className={isMobile ? classes.paperMobileStepFirst : classes.paperDesktopStepFirst} align='center'>
      <Title level={3} className={classes.textLabel}>
        Реєстрація
          </Title>
      <Row className={classes.signUpFieldsContainer}>
        <Col xs={24} sm={12}>
          <Form.Item
            name="userName"
            help={touched.userName && errors.userName ? errors.userName : ''}
            validateStatus={getValidationStatusUserName()}
            hasFeedback
          >
            <Input
              className={classes.textField}
              name="userName"
              placeholder="User Name"
              value={values.userName}
              onChange={handleUserNameFieldChange}
              onBlur={handleBlur}
            />
          </Form.Item>
        </Col>
        <Col xs={24} sm={12}>
          <Form.Item
            name="email"
            error={touched.email && errors.email ? errors.email : ''}
            validateStatus={getValidationStatusEmail()}
            hasFeedback
          >
            <Input
              className={classes.textField}
              name="email"
              placeholder="Email"
              value={values.email}
              onChange={handleEmailFieldChange}
              onBlur={handleBlur}
            />
          </Form.Item>
        </Col>
        <Col xs={24} sm={12}>
          <Form.Item name="password" error={touched.password && errors.password ? errors.password : ''}>
            <Input.Password
              className={classes.textField}
              placeholder="Password"
              name="password"
              value={values.password}
              onChange={onFieldChange}
              onBlur={handleBlur}
            />
          </Form.Item>
        </Col>
        <Col xs={24} sm={12}>
          <Form.Item name="confirmPassword" error={touched.confirmPassword && errors.confirmPassword ? errors.confirmPassword : ''}>
            <Input.Password
              className={classes.textField}
              placeholder="Confirm Password"
              name="confirmPassword"
              value={values.confirmPassword}
              onChange={onFieldChange}
              onBlur={handleBlur}
            />
          </Form.Item>
        </Col>
      </Row>
      <Button
        type="primary"
        onClick={handleSubmit}
        className={classes.stepButton}
        icon={<ArrowRightOutlined />}
        disabled={
          !(Object.keys(touched).length === 0) && (Object.keys(errors).length === 0)
            && isValidatingEmail === false && isValidatingUserName === false ? (false) : (true)
        }
      >
      </Button>
      <Row className={classes.alreadyHaveAccountGridItem}>
        <Col xs={24} sm={24}>
          <Text level={5} >
            <Link to="/SignIn">Уже є аккаунт? Увійти!</Link>
          </Text>
        </Col>
      </Row>
    </div>
  };
  return (
    <Formik enableReinitialize={true}
      initialValues={{ ...user }}
      validationSchema={validationSchema}
      onSubmit={handleSubmit}
    >
      {({ handleSubmit, handleBlur, values, touched, errors }) => (
        <Form onSubmit={handleSubmit} onBlur={handleBlur} className={classes.form}>
          {getRegistrationForm(values, touched, errors)}
        </Form>
      )}
    </Formik>
  )
};
export default SignUp;