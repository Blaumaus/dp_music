
import GenreApi from 'api/modules/genre';
import BuildUrl from 'helpers/BuildUrl'
const CREATE_GENRE = 'CREATE_GENRE';
const UPDATE_GENRE = 'UPDATE_GENRE';
const DELETE_GENRE = 'DELETE_GENRE';
const SET_GENRES = 'SET_GENRES';


let initialState = {
    genres: [

    ]
};
const GenreReducer = (state = initialState, action) => {
    switch (action.type) {
        case SET_GENRES: {
            return {
                ...state,
                genres: [...action.genres]
            }
        }
        case CREATE_GENRE: {

            let newGenre = {
                ...action.genre
            };
            return {
                ...state,
                genres: [...state.genres, newGenre]
            }
        }
        case UPDATE_GENRE: {

            return {
                ...state,
                genres: state.genres.map(g => {
                    if (g.id === action.genre.id) {
                        return action.genre
                    }
                    return g;
                })
            }
        }
        case DELETE_GENRE: {
            return {
                ...state,
                genres: state.genres.filter(item => item !== action.genre),
            }
        }
        default:
            return state;
    }
}
export const SetGenresSuccess = (genres) => ({
    type: SET_GENRES, genres
})
export const CreateSuccess = (genre) => ({
    type: CREATE_GENRE, genre
})
export const UpdateSuccess = (genre) => ({
    type: UPDATE_GENRE, genre
})
export const DeleteSuccess = (genre) => ({
    type: DELETE_GENRE, genre
})

export const getGenres = () => {
    return (dispatch) => {
        GenreApi.getGenres().then(data => {
            const genres = Object.values(data.data);
            genres.forEach(genre => {
                genre.image = BuildUrl.getUrl(genre.image)
            })
            console.log(genres);
            dispatch(SetGenresSuccess(genres))
        });
    }
}
export const Create = (genre) => {
    return  (dispatch) => {
        GenreApi.create(genre);
        dispatch(CreateSuccess(genre))
    }
}
export const Update = (genre) => {
    return (dispatch) => {
        //TODO: PUT REQUEST TO SERVER IF OK THEN dispatch
        dispatch(UpdateSuccess(genre))
    }
}
export const Delete = (genre) => {
    return (dispatch) => {
        //TODO: DELETE REQUEST TO SERVER IF OK THEN dispatch
        GenreApi.delete(genre.id);
        dispatch(DeleteSuccess(genre))
    }
}

export default GenreReducer;