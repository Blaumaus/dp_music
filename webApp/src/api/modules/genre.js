import ApiClient, { apiUrl } from '../apiClient';
import axios from 'axios';

export default class GenreApi {
  static async create(genre) {
    await axios({
      method: 'post',
      url: `${apiUrl}/Genre`,
      data: genre,
      headers: { 'Content-Type': 'multipart/form-data'}
    })
  }
  static async update(genre) {
    await axios({
      method: 'put',
      url: `${apiUrl}/Genre`,
      data: genre,
      headers: { 'Content-Type': 'multipart/form-data'}
    })
  }
  static async getGenres() {
    return ApiClient.get('/Genre');
  }
  static async delete(id) {
    await ApiClient.delete(`/Genre/${id}`)

  }
}
