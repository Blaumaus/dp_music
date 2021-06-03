import ApiClient, { apiUrl } from '../apiClient';
import axios from 'axios';

export default class AlbumApi {
    static async create(band) {
        await axios({
            method: 'post',
            url: `${apiUrl}/Album`,
            data: band,
            headers: { 'Content-Type': 'multipart/form-data' }
        })
    }
    static async update(band) {
        await axios({
            method: 'put',
            url: `${apiUrl}/Album`,
            data: band,
            headers: { 'Content-Type': 'multipart/form-data' }
        })
    }
    static async getAlbums(genreId) {
        return ApiClient.get(`/Album`,
            {
                params:
                {
                    genreId
                }
            }
        );
    }

    static async delete(id) {
        await ApiClient.delete(`/Album/${id}`)

    }
}
