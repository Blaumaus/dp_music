import BandApi from 'api/modules/band';
import BuildUrl from 'helpers/BuildUrl'

const CREATE_BAND = 'CREATE_BAND';
const UPDATE_BAND = 'UPDATE_BAND';
const DELETE_BAND = 'DELETE_BAND';
const SET_BANDS = 'SET_BANDS';


let initialState = {
    bands: [

    ]
};
const BandReducer = (state = initialState, action) => {
    switch (action.type) {

        case SET_BANDS: {
            return {
                ...state,
                bands: [...action.bands]
            }
        }
        case CREATE_BAND: {

            let newBand = {
                ...action.band
            };
            return {
                ...state,
                bands: [...state.bands, newBand]
            }
        }
        case UPDATE_BAND: {

            return {
                ...state,
                bands: state.bands.map(b => {
                    if (b.id === action.band.id) {
                        return action.band
                    }
                    return b;
                })
            }
        }
        case DELETE_BAND: {
            return {
                ...state,
                bands: state.bands.filter(item => item !== action.band),
            }
        }
        default:
            return state;
    }
}
export const SetBandsSuccess = (bands) => ({
    type: SET_BANDS, bands
})
export const CreateSuccess = (band) => ({
    type: CREATE_BAND, band
})
export const UpdateSuccess = (band) => ({
    type: UPDATE_BAND, band
})
export const DeleteSuccess = (band) => ({
    type: DELETE_BAND, band
})


export const getBands = (genreId) => {
    return (dispatch) => {
        return BandApi.getBands(genreId).then(data => {
            const bands = Object.values(data.data);
            bands.forEach(band => {
                band.image = BuildUrl.getUrl(band.image)
            })
            dispatch(SetBandsSuccess(bands))
        });
    }
}
export const Create = (band) => {
    return (dispatch) => {
        return BandApi.create(band).then(
            dispatch(CreateSuccess(band))
        );
    };
}
export const Update = (band) => {
    return (dispatch) => {
        return BandApi.update(band).then(
            dispatch(UpdateSuccess(band))
        );
    }
}
export const Delete = (band) => {
    return (dispatch) => {
        return BandApi.delete(band.id).then(
            dispatch(DeleteSuccess(band))
        );       
    }
}
export default BandReducer;