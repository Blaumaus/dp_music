import ApiClient from '../apiClient';
import axios from 'axios';

export default class GenreApi {
  static async create(genre) {
    await axios({
      method: 'post',
      url: 'https://localhost:44304/api/Genre',
      data: genre,
      headers: { 'Content-Type': 'multipart/form-data'}
    })
  }
  static getGenres() {
    return ApiClient.get('/Genre');
  }
  static async delete(id) {
    await ApiClient.delete(`/Genre/${id}`)

  }
}
