import AlbumApi from 'api/modules/album';
import BuildUrl from 'helpers/BuildUrl'

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

export const getAlbums = (bandId) => {
    return (dispatch) => {
        return AlbumApi.getAlbums(bandId).then(data => {
            const albums = Object.values(data.data);
            albums.forEach(album => {
                album.image = BuildUrl.getUrl(album.image)
            })
            dispatch(SetAlbumsSuccess(albums))
        });
    }
}
export const Create = (album) => {
    return (dispatch) => {
        return AlbumApi.create(album).then(
            dispatch(CreateSuccess(album))
        );

    }
}
export const Update = (album) => {
    return (dispatch) => {
        return AlbumApi.update(album).then(
            dispatch(UpdateSuccess(album))
        );
    }
}
export const Delete = (album) => {
    return (dispatch) => {
        return AlbumApi.delete(album).then(
            dispatch(DeleteSuccess(album))
        );
    }
}
export default AlbumReducer;