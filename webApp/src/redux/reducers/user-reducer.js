
import UserApi from 'api/modules/user';

const SET_USER = 'SET_USER';
const DELETE_USER = 'DELETE_USER';


let initialState = {
    user: {

    }
};
const UserReducer = (state = initialState, action) => {
    switch (action.type) {
        case SET_USER: {
            return {
                ...state,
                user: action.user
            }
        }
        case DELETE_USER: {
            return {
                ...state,
                user: null
            }
        }
        default:
            return state;
    }
}
export const SetUserSuccess = (user) => ({
    type: SET_USER, user
})
export const DeleteUserSuccess = () => ({
    type: SET_USER
})

export const getUser = () => {
    return (dispatch) => {
        UserApi.getUser().then(data=>{
            dispatch(SetUserSuccess(data))
        });
    }
}
export const DeleteUser = () => {
    return (dispatch) => {
        dispatch(DeleteUserSuccess())
    }
}

export default UserReducer;