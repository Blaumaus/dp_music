import React, { Component } from "react";
import { withRouter } from 'react-router';
import SignIn from 'components/SignIn';
import { isMobile } from 'react-device-detect';
import AuthenticationService from 'components/AuthenticationService';
import { message } from 'antd';

class SignUpContainer extends Component {

    state = {
        user: {
            login: "",
            password: "",
        },
        errorMessageTime: 1,
        successMessageTime: 1,
        successMessageContent: 'Ви успішно авторизувались',
        errorMessageContent: 'Невірний логін або пароль'
    };

    onChange = (field, value) => {
        this.setState({
            user: { ...this.state.user, [field]: value }
        });
    };

    error = (content) => {
        const { errorMessageTime } = this.state;
        message.error(content, errorMessageTime);
    };

    success = (content) => {
        const { history } = this.props;
        const { successMessageTime } = this.state;
        message.success(content, successMessageTime).then(
            setTimeout(() => {
                history.push('/Genres')
            }, successMessageTime * 1000)
        );
    };

    handleSubmit = async () => {
        const { user, successMessageContent, errorMessageContent } = this.state;
        const authenticationError = await AuthenticationService.authenticate(user);
        if (authenticationError) {
            this.error(errorMessageContent);
        }
        else {
            this.success(successMessageContent);
        }
    };

    render() {
        return (
            <div>
                <SignIn
                    user={this.state.user}
                    onChange={this.onChange}
                    handleSubmit={this.handleSubmit}
                    isMobile={isMobile}
                />
            </div>
        )
    }
};
export default withRouter(SignUpContainer);