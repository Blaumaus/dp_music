import axios from 'axios';

const responseInterceptor = response => {
    const realResponse = { ...response.data };
    const realStatusCode = response.status;
    const isSuccessStatusCode = realStatusCode >= 200 && realStatusCode < 300;
    const statusCode = response.status;

    if (isSuccessStatusCode) {
        response.status = realStatusCode;
        response.data = realResponse;
        response.errorMessage = realResponse.errorMessage;
        return response;
    } else {
        if (statusCode === 401 || statusCode === 403) {
            window.location.href = '/login';
            window.location.reload();
        } else {
            response.status = realStatusCode;
            const { errorCode, errorMessage, data } = _mapRealResponse(realResponse);

            const errorResponse = { errorCode, errorMessage, data };

            response.data = errorResponse;
            return Promise.reject(response);
        }
    }
};

const rejectInterceptor = error => {
    const statusCode = error.response ? error.response.status : null;

    if (statusCode === 401 || statusCode === 403) {

        return Promise.reject(error);
    } else {
        return Promise.reject(error);
    }
};

const _mapRealResponse = realResponse => {
    const errorCode = realResponse.errorCode || realResponse.ErrorCode;
    const errorMessage = realResponse.errorMessage || realResponse.ErrorMessage;
    const data = realResponse.data || realResponse.Data;
    return { errorCode, errorMessage, data };
};

const apiConfig = {
    responseType: 'json',   
    headers: {
        'X-Requested-With': 'XMLHttpRequest',
        Accept: 'application/json',
        'Content-Type': 'application/json',
    },
};

const apiUrl = process.env.REACT_APP_API_BASE + '/api';
//Uncomment later, because current CORS configuration doesn`t work when Credentials are true
//apiConfig.withCredentials = true;
//
apiConfig.withCredentials = true;

apiConfig.baseURL = apiUrl;
apiConfig.headers['Access-Control-Allow-Origin'] = apiUrl;

const restResponseInstance = axios.create(apiConfig);

export const notRestResponseInstance = axios.create(apiConfig);
export const restResponseInterceptor = restResponseInstance.interceptors.response.use(
    responseInterceptor,
    rejectInterceptor
);
export default restResponseInstance;