import ApiClient, { apiUrl } from '../apiClient';
import axios from 'axios';

export default class CompositionApi {
    static async create(band) {
        await axios({
            method: 'post',
            url: `${apiUrl}/Composition`,
            data: band,
            headers: { 'Content-Type': 'multipart/form-data' }
        })
    }
    static async update(band) {
        await axios({
            method: 'put',
            url: `${apiUrl}/Composition`,
            data: band,
            headers: { 'Content-Type': 'multipart/form-data' }
        })
    }
    static async getAlbums(genreId) {
        return ApiClient.get(`/Composition`,
            {
                params:
                {
                    genreId
                }
            }
        );
    }

    static async delete(id) {
        await ApiClient.delete(`/Composition${id}`)

    }
}
