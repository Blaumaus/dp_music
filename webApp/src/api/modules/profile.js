import ApiClient from '../apiClient';

export default class ProfileApi {
  static getUserInfo(userId) {
    return ApiClient.get(`/UserProfile/${userId}`)
      
  }
  static updateUserInfo(user) {
    return ApiClient.put(`/UserProfile/${user.userId}`,user)
      
  }
}