import ApiClient from '../apiClient';

export default class AccountApi {
  static async register(user) {
    await ApiClient.post('/Account', user)
  }
}
