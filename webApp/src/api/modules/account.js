import ApiClient from '../apiClient';

export default class AccountApi {
  static async register(user) {
    await ApiClient.post('/Account/Register', user);
  }
  static async validateUserName(userName) {
    return await ApiClient.get(`/UserValidation/ValidateUserName/${userName}`).then(response => {
      return response.data;
    });
  }
  static async validateEmail(email) {
    return await ApiClient.get(`/UserValidation/ValidateEmail/${email}`).then(response => {
      return response.data.data;
    });
  }
  static async login(user) {
    return await ApiClient.post('/Account/LogIn', user);
  }
  static async logout() {
    return await ApiClient.delete('/Account/LogOut');
  }
  static async isAuthorisedUser() {
    return await ApiClient.get('/Account/IsAuthorizedUser');
    
  }
}
