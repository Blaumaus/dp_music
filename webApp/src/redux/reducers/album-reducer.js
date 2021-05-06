
import { v4 as uuidv4 } from 'uuid';

const CREATE_ALBUM = 'CREATE_ALBUM';
const UPDATE_ALBUM = 'UPDATE_ALBUM';
const DELETE_ALBUM = 'DELETE_ALBUM';
const SET_ALBUMS = 'SET_ALBUMS';


let initialState = {
    albums: [

    ]
};
const AlbumReducer = (state = initialState, action) => {
    switch (action.type) {
       
        case SET_ALBUMS: {
            return {
                ...state,
                albums: [...action.albums]
            }
        }
        case CREATE_ALBUM: {

            let newAlbum = {
                ...action.album
            };
            return {
                ...state,
                albums: [...state.albums, newAlbum]
            }
        }
        case UPDATE_ALBUM: {

            return {
                ...state,
                albums: state.albums.map(a => {
                    if (a.id === action.album.id) {
                        return action.album
                    }
                    return a;
                })
            }
        }
        case DELETE_ALBUM: {
            return {
                ...state,
                albums: state.albums.filter(item => item !== action.album),
            }
        }
        default:
            return state;
    }
}
export const SetAlbumsSuccess = (albums) => ({
    type: SET_ALBUMS, albums
})
export const CreateSuccess = (album) => ({
    type: CREATE_ALBUM, album
})
export const UpdateSuccess = (album) => ({
    type: UPDATE_ALBUM, album
})
export const DeleteSuccess = (album) => ({
    type: DELETE_ALBUM, album
})

//TODO: Get WITH GenreId Param
export const getAlbums = () => {
    return (dispatch) => {
        //TODO: Get FROM API
        dispatch(SetAlbumsSuccess([
            {
                id: uuidv4(),
                name: 'Unleashed',
                image: 'https://upload.wikimedia.org/wikipedia/ru/8/8c/SkilletUnleasedCover.jpg',
                year: 2016,
                description: 'This is Unleashed Album Skillet group'
            },
            {
                id: uuidv4(),
                name: 'Back in Black',
                image: 'https://342031.selcdn.ru/rusplt/images/25072020/1595670438055-upload.jpeg',
                year: 1980,
                description: 'This is Back in Black Album AC/DC group'
            }
        ]));
    }
}
export const Create = (album) => {
    return (dispatch) => {
        //TODO: POST REQUEST TO SERVER IF OK THEN dispatch
        dispatch(CreateSuccess(album))
    }
}
export const Update = (album) => {
    return (dispatch) => {
        //TODO: PUT REQUEST TO SERVER IF OK THEN dispatch
        dispatch(UpdateSuccess(album))
    }
}
export const Delete = (album) => {
    return (dispatch) => {
        //TODO: DELETE REQUEST TO SERVER IF OK THEN dispatch
        dispatch(DeleteSuccess(album))
    }
}
export default AlbumReducer;