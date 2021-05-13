import axios from 'axios'
import { store } from 'store'
import { authActions } from 'actions/auth'
import { getAccessToken, removeAccessToken } from 'utils/accessToken'

const api = axios.create({
  baseURL: process.env.REACT_APP_API_URL,
})

api.interceptors.request.use(
  (config) => {
    const token = getAccessToken()
    if (token) {
      config.headers['Authorization'] = `Bearer ${token}`
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
    if (error.response.data.statusCode === 401) {
      removeAccessToken()
      store.dispatch(authActions.logout())
    }
    return Promise.reject(error)
  }
)

export const authMe = () =>
  api
    .get('/auth/me')
    .then(response => response.data)
    .catch(error => {
      throw new Error(error.response.data.message)
    })

export const login = (credentials) =>
  api
    .post('/auth/login', credentials)
    .then(response => response.data)
    .catch(error => {
      throw new Error(error.response.data.message)
    })

export const refresh = () =>
  api
    .get('/auth/refresh')
    .then(response => response.data)
    .catch(error => {
      throw new Error(error.response.data.message)
    })

export const signup = (data) =>
  api
    .post('/auth/register', data)
    .then(response => response.data)
    .catch(error => {
      const errorsArray = error.response.data.message
      if (Array.isArray(errorsArray)) {
        throw errorsArray
      }
      throw new Error(errorsArray)
    })

export const logout = () =>
  api
    .get('/auth/logout')
    .then(response => response.data)
    .catch(error => {
      const errorsArray = error.response.data.message
      if (Array.isArray(errorsArray)) {
        throw errorsArray
      }
      throw new Error(errorsArray)
    })

export const deleteUser = () =>
  api
    .delete('/customers')
    .then(response => response.data)
    .catch(error => {
      throw new Error(JSON.stringify(error.response.data))
    })

export const changeCustomerDetails = (data) =>
  api
    .put('/customers', data)
    .then(response => response.data)
    .catch(error => {
      const errorsArray = error.response.data.message
      if (Array.isArray(errorsArray)) {
        throw errorsArray
      }
      throw new Error(errorsArray)
    })

export const forgotPassword = (email) =>
  api
    .post('/auth/customer/reset-password', email)
    .then(response => response.data)
    .catch(error => {
      throw new Error(error.response.data.message)
    })

export const confirmEmail = () =>
  api
    .post('/customers/confirm_email')
    .then(response => response.data)
    .catch(error => {
      throw new Error(error.response.data.message)
    })

export const createNewPassword = (id, password) =>
  api
    .post(`/auth/password-reset/${id}`, password)
    .then(response => response.data)
    .catch(error => {
      const errorsArray = error.response.data.message
      if (Array.isArray(errorsArray)) {
        throw errorsArray
      }
      throw new Error(errorsArray)
    })

export const verifyEmail = ({ path, id }) =>
  api
    .get(`/auth/${path}/${id}`)
    .then(response => response.data)
    .catch(error => {
      throw new Error(error.response.data.message)
    })
