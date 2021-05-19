import React, { Component } from "react";
import { withRouter } from 'react-router';
import SignUp from 'components/SignUp';
import AccountApi from 'api//modules/account';
import { isMobile } from 'react-device-detect';

class SignUpContainer extends Component {

    state = {
        nativeLanguages: null,
        targetLanguages: true,
        user: {
            userName: "",
            email: "",
            password: "",
            confirmPassword: "",
        },
        isLoading: true,
        isValidatingUserName: false,
        isValidatedUserName: false,
        isValidatingEmail: false,
        isValidatedEmail: false,
        isValidUserName: false,
        isValidEmail: false,
    };
    onChange = (field, value) => {
        this.setState({
            user: { ...this.state.user, [field]: value }
        });
    };

    sleep = (ms) => {
        return new Promise(resolve => setTimeout(resolve, ms));
    };

    validateUserName = async () => {
        const { user } = this.state;
        this.setState({
            isValidatingUserName: true
        });
        const isValid = await Promise.all([AccountApi.validateUserName(user.userName), this.sleep(1000)]).then((data) => {
            const validation = data;
            this.setState({
                isValidUserName: validation[0],
                isValidatingUserName: false,
                isValidatedUserName: true
            });
            return validation[0];
        });
        return isValid;
    };

    validateEmail = async () => {
        const { user } = this.state;
        this.setState({
            isValidatingEmail: true
        });
        const isValid = await Promise.all([AccountApi.validateEmail(user.email), this.sleep(1000)]).then((data) => {
            const validation = data;
            this.setState({
                isValidEmail: validation[0],
                isValidatingEmail: false,
                isValidatedEmail: true
            });
            return validation[0];
        });
        return isValid;
    };

    handleSubmit = () => {
        const { user } = this.state;
        AccountApi.register(user);
        const { history } = this.props;
        history.push(`/SignIn`);
    };

    showLoader = () => this.setState({ isLoading: true });

    hideLoader = () => this.setState({ isLoading: false });


    handleEmailFieldChange = (event) => {
        const fieldName = event.target.name;
        const fieldValue = event.target.value;
        this.onChange(fieldName, fieldValue);
        this.setState({
            isValidatedEmail: false
        });
    };
    
    handleUserNameFieldChange = (event) => {
        const fieldName = event.target.name;
        const fieldValue = event.target.value;
        this.onChange(fieldName, fieldValue);
        this.setState({
            isValidatedUserName: false
        });
    };

    render() {
        return (
            <div>        
                    <SignUp     
                        user={this.state.user}
                        isValidatingUserName={this.state.isValidatingUserName}
                        isValidatedUserName={this.state.isValidatedUserName}
                        isValidatingEmail={this.state.isValidatingEmail}
                        isValidatedEmail={this.state.isValidatedEmail}
                        currentStep={this.state.currentStep}
                        isValidEmail={this.state.isValidEmail}
                        isValidUserName={this.state.isValidUserName}         
                        onChange={this.onChange}
                        validateUserName={this.validateUserName}
                        validateEmail={this.validateEmail}
                        handleSubmit={this.handleSubmit}
                        handleUserNameFieldChange={this.handleUserNameFieldChange}
                        handleEmailFieldChange={this.handleEmailFieldChange}
                        isMobile={isMobile}               
                    />
            </div>
        )
    }
};
export default withRouter(SignUpContainer);