
import { v4 as uuidv4 } from 'uuid';

const CREATE = 'CREATE';
const UPDATE = 'UPDATE';
const DELETE = 'DELETE';
const SET_GENRES = 'SET_GENRES';


let initialState = {
    genres: [
        { id: uuidv4(), name: 'Rock', image: 'https://image.freepik.com/free-vector/rock-and-music-logo-template_1895-5.jpg', description: 'This is Rock' },
        { id: uuidv4(), name: 'Rap', image: 'https://besthqwallpapers.com/Uploads/24-5-2020/134447/thumb2-gunna-4k-american-rapper-blue-neon-lights-music-stars.jpg', description: 'This is Rap' }
    ]
};
const GenreReducer = (state = initialState, action) => {
    switch (action.type) {
        case SET_GENRES: {
            return {
                ...state,
                genres: [...state.genres, ...action.genres]
            }
        }
        case CREATE: {
            let newGenre = {
                id: action.id,
                name: action.name,
                image: action.image,
                description: action.description,
            };
            return {
                ...state,
                genres: [...state.genres, newGenre]
            }
        }
        case UPDATE: {
            return {
                ...state,
                genres: state.genres.map(g => {
                    if (g.id === action.id) {
                        return { action }
                    }
                    return g;
                })
            }
        }
        case DELETE:
        default:
            return state;
    }
}
export const SetGenresAC = (genres) => ({
    type: SET_GENRES, genres
})
export const CreateSuccess = (genre) => ({
    type: CREATE, genre
})
export const UpdateSuccess = (genreId) => ({
    type: UPDATE, genreId
})
export const DeleteSuccess = (genreId) => ({
    type: DELETE, genreId
})

export const getGenres = () => {
    return (dispatch) => {
        //TODO: Get FROM API
        dispatch(SetGenresAC())
    }
}
export const Create = (genre) => {
    return (dispatch) => {
        //TODO: POST REQUEST TO SERVER IF OK THEN dispatch
        dispatch(CreateSuccess(genre))
    }
}
export const Update = (genreId) => {
    return (dispatch) => {
        //TODO: PUT REQUEST TO SERVER IF OK THEN dispatch
        dispatch(UpdateSuccess(genreId))
    }
}
export default GenreReducer;