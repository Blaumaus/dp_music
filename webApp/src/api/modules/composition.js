import ApiClient, { apiUrl } from '../apiClient';
import axios from 'axios';

export default class CompositionApi {
    static async create(composition) {
        await axios({
            method: 'post',
            url: `${apiUrl}/Composition`,
            data: composition,
            headers: { 'Content-Type': 'multipart/form-data' }
        })
    }
    static async update(composition) {
        await axios({
            method: 'put',
            url: `${apiUrl}/Composition`,
            data: composition,
            headers: { 'Content-Type': 'multipart/form-data' }
        })
    }
    static async getCompositions(albumId, bandId) {
        if (albumId === 'undefined')
            albumId = null;
        return ApiClient.get(`/Composition`,
            {
                params:
                {
                    albumId,
                    bandId
                }
            }
        );
    }

    static async delete(id) {
        await ApiClient.delete(`/Composition/${id}`)

    }
}
