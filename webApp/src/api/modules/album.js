import ApiClient, { apiUrl } from '../apiClient';
import axios from 'axios';

export default class AlbumApi {
    static async create(album) {
        await axios({
            method: 'post',
            url: `${apiUrl}/Album`,
            data: album,
            headers: { 'Content-Type': 'multipart/form-data' }
        })
    }
    static async update(album) {
        await axios({
            method: 'put',
            url: `${apiUrl}/Album`,
            data: album,
            headers: { 'Content-Type': 'multipart/form-data' }
        })
    }
    static async getAlbums(bandId) {
        return ApiClient.get(`/Album`,
            {
                params:
                {
                    bandId
                }
            }
        );
    }

    static async delete(id) {
        await ApiClient.delete(`/Album/${id}`)

    }
}
