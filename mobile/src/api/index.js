import axios from 'axios'
import { API_URL as baseURL } from '../../env.js'
// import { store } from '../redux/store'
import { authActions } from '../redux/actions/auth'
// import { getAccessToken, removeAccessToken } from '../utils/accessToken'

const api = axios.create({
  baseURL,
  headers: {
    'Content-Type': 'application/json',
  }
})

api.interceptors.request.use(
  (config) => {
    // const token = getAccessToken()
    // config.headers['Accept'] = 'application/json'
    // config.headers['Cookie'] = `jwtToken=${token}`
    return config
  },
  error => {
    console.log('request', error)
    return Promise.reject(error)
  }
)

api.interceptors.response.use(
  response => response,
  error => {
    // if (error.response.data.statusCode === 401) {
    //   // removeAccessToken()
    //   store.dispatch(authActions.logout())
    // }
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
    .get(`/band/id?id=${genreId}`)
    .then(({ data }) => data)
    .catch(error => {
      console.error(error)
    })
