
import { v4 as uuidv4 } from 'uuid';

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

//TODO: Get WITH GenreId Param
export const getBands = () => {
    return (dispatch) => {
        //TODO: Get FROM API
        dispatch(SetBandsSuccess([
            {
                id: uuidv4(),
                name: 'AC/DC',
                image: 'https://acdcfans.ru/wp-content/uploads/2020/10/800px-acdcpowerup.jpg',
                countryCode: 'UA',
                foundationDate:new Date('10/11/2014'),
                description: 'This is AC/DC'
            },
            {
                id: uuidv4(),
                name: 'Skillet',
                image: 'https://tekst-pesni.online/wp-content/uploads/2020/03/32-4.jpg',
                countryCode: 'RU',
                foundationDate:new Date('12/02/2020'),
                description: 'This is Skillet'
            }
        ]));
    }
}
export const Create = (band) => {
    return (dispatch) => {
        //TODO: POST REQUEST TO SERVER IF OK THEN dispatch
        dispatch(CreateSuccess(band))
    }
}
export const Update = (band) => {
    return (dispatch) => {
        //TODO: PUT REQUEST TO SERVER IF OK THEN dispatch
        dispatch(UpdateSuccess(band))
    }
}
export const Delete = (band) => {
    return (dispatch) => {
        //TODO: DELETE REQUEST TO SERVER IF OK THEN dispatch
        dispatch(DeleteSuccess(band))
    }
}
export default BandReducer;