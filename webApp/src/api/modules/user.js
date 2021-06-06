import ApiClient from '../apiClient';
import axios from 'axios';

export default class UserApi {
    static getUser() {
        return ApiClient.get('/User').then(response => {
            return response.data.data;       
        }).catch(_ => ({}));
    }
}
