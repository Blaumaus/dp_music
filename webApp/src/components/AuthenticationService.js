import AccountApi from 'api//modules/account';
import UserApi from 'api//modules/user';

class AuthenticationService {
    constructor() {
        this.isAuthenticated = false;
    }

    async authenticate(user) {
        const data = await AccountApi.login(user)
        const response = data.data;
        if (response.errorMessage === null) {
            this.isAuthenticated = true;
        } else {
            return response.errorMessage
        }
    };

    async signout() {
        await AccountApi.logout();
        this.isAuthenticated = false;
    };

    async getUserInfo() {
        const data = await UserApi.getUser();
        return data
    };

    async checkAuthenticated() {
        const data = await AccountApi.isAuthorisedUser();
        const response = data.data;
        if (response.errorMessage === null) {
            this.isAuthenticated = true;
        }
        else {
            this.isAuthenticated = false;
        }

        return this.isAuthenticated;
    };
};
export default new AuthenticationService()