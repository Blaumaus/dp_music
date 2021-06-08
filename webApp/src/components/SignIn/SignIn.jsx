import React from 'react';
import { Typography } from 'antd';
import { Formik } from 'formik';
import * as yup from 'yup';
import { Link } from 'react-router-dom';
import useStyles from './SignIn.styles';
import { Input, Button, Row, Col } from 'antd';
import { Form } from 'formik-antd';
import { ArrowRightOutlined } from '@ant-design/icons';
import 'antd/dist/antd.css';
import './SignIn.css';

const { Text, Title } = Typography;

const SignIn = (props) => {
  const classes = useStyles();
  const {
    user,
    onChange,
    handleSubmit,
    isMobile,
  } = props;

  const validationSchema = yup.object({
    login: yup
      .string()
      .required('Username required'),
    password: yup
      .string()
      .required('Password required'),
  })

  const handleBlur = () => {
  };

  const onFieldChange = (event) => {
    const fieldName = event.target.name;
    const fieldValue = event.target.value;
    onChange(fieldName, fieldValue);
  };

  const getLoginForm = (values, touched, errors) => {
    return <div className={isMobile ? classes.paperMobile : classes.paperDesktop} align='center'>
      <div>
        <Title level={3}>
          Вхід
      </Title>
      </div>
      <Row className={classes.signUpFieldsContainer}>
        <Col xs={24} sm={12}>
          <Form.Item
            name="login"
            help={touched.login && errors.login ? errors.login : ''}
          >
            <Input
              className={classes.textField}
              name="login"
              placeholder="User Name"
              value={values.login}
              onChange={onFieldChange}
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
      </Row>
      <Button
        type="primary"
        onClick={handleSubmit}
        className={classes.stepButton}
        icon={<ArrowRightOutlined />}
        disabled={
          !(Object.keys(touched).length === 0) && (Object.keys(errors).length === 0) ? (false) : (true)
        }
      >
      </Button>
      <Row className={classes.alreadyHaveAccountGridItem}>
        <Col xs={24} sm={24}>
          <Text level={5} >
            <Link to="/SignUp">Ще не маєте аккаунту?</Link>
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
          {getLoginForm(values, touched, errors)}
        </Form>
      )}
    </Formik>
  )
};

export default SignIn;