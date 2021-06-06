import axios from 'axios'
import { API_URL as baseURL } from '../../env.js'
import { get } from '../utils/storage'
import constants from '../redux/constants'

const api = axios.create({
  baseURL,
  headers: {
    'Content-Type': 'application/json',
  }
})

api.interceptors.request.use(
  async (config) => {
    const token = await get(constants.TOKEN)
    if (token) {
      config.headers['Cookie'] = `jwtToken=${token}`
    }

    return config
  },
  error => {
    return Promise.reject(error)
  }
)

api.interceptors.response.use(
  response => response,
  error => {
    return Promise.reject(error)
  }
)

// export const authMe = () =>
//   api
//     .get('/auth/me')
//     .then(response => response.data)
//     .catch(error => {
//       throw new Error(error.response.data.message)
//     })

export const login = (credentials) =>
  api
    .post('/account/login', credentials)
    .then(({ headers, data }) => ({ headers, data }))
    .catch(error => {
      console.error('response error', JSON.stringify(error))
      throw new Error(error.response.data.errorMessage)
    })

export const signup = (data) =>
  api
    .post('/account/register', data)
    .then(({ headers, data }) => ({ headers, data }))
    .catch(error => {
      throw new Error(error.response.data.errorMessage)
    })

export const logout = () =>
  api
    .delete('/account/logout')
    .then(({ headers, data }) => ({ headers, data }))
    .catch(error => {
      throw new Error(error.response.data.errorMessage)
    })

export const isAuthorised = () =>
  api
    .get('/account​/isauthorizeduser')
    .then(({ data }) => data)
    .catch(error => {
      throw new Error(error.response.data.errorMessage)
    })

export const validateUsername = (username) =>
  api
    .get(`/UserValidation/ValidateUserName/${username}`)
    .then(({ data }) => data)
    .catch(error => {
      console.error(error)
    })

export const validateEmail = (email) =>
  api
    .get(`/UserValidation/ValidateEmail/${email}`)
    .then(({ data }) => data)
    .catch(error => {
      console.error(error)
    })

export const getGenres = () =>
  api
    .get('/genre')
    .then(({ data }) => data)
    .catch(error => {
      console.error(error)
    })

export const getBands = (genreId) =>
  api
    .get(`/band?genreId=${genreId}`)
    .then(({ data }) => data)
    .catch(error => {
      console.error(error)
    })

export const getAlbums = (bandId) =>
  api
    .get(`/album?bandId=${bandId}`)
    .then(({ data }) => data)
    .catch(error => {
      console.error(error)
    })

export const getSongs = (albumId, bandId) =>
  api
    .get(`/song?albumId=${albumId}&bandId={bandId}`) /////////////
    .then(({ data }) => data)
    .catch(error => {
      console.error(error)
    })
