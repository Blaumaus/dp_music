import ApiClient, { apiUrl } from '../apiClient';
import axios from 'axios';

export default class GenreApi {
    static async create(band) {
        await axios({
            method: 'post',
            url: `${apiUrl}/Band`,
            data: band,
            headers: { 'Content-Type': 'multipart/form-data' }
        })
    }
    static async update(band) {
        await axios({
            method: 'put',
            url: `${apiUrl}/Band`,
            data: band,
            headers: { 'Content-Type': 'multipart/form-data' }
        })
    }
    static async getBands(genreId) {
        return ApiClient.get(`/Band`,
            {
                params:
                {
                    genreId
                }
            }
        );
    }

    static async delete(id) {
        await ApiClient.delete(`/Band/${id}`)

    }
}
