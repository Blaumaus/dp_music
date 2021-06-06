
import { v4 as uuidv4 } from 'uuid';

const CREATE_COMPOSITION = 'CREATE_COMPOSITION';
const UPDATE_COMPOSITION = 'UPDATE_COMPOSITION';
const DELETE_COMPOSITION = 'DELETE_COMPOSITION';
const SET_COMPOSITIONS = 'SET_COMPOSITIONS';
const SORT_COMPOSITIONS = 'SORT_COMPOSITIONS';


let initialState = {
    compositions: [

    ]
};
const CompositionReducer = (state = initialState, action) => {
    switch (action.type) {
       
        case SET_COMPOSITIONS: {
            return {
                ...state,
                compositions: [...action.compositions]
            }
        }
        case CREATE_COMPOSITION: {

            let newComposition = {
                ...action.composition
            };
            return {
                ...state,
                compositions: [...state.compositions, newComposition]
            }
        }
        case UPDATE_COMPOSITION: {

            return {
                ...state,
                compositions: state.compositions.map(c => {
                    if (c.id === action.composition.id) {
                        return action.composition
                    }
                    return c;
                })
            }
        }
        case DELETE_COMPOSITION: {
            return {
                ...state,
                compositions: state.compositions.filter(item => item !== action.composition),
            }
        }
        case SORT_COMPOSITIONS: {
            return {
                ...state,
                compositions: state.compositions.sort((a, b) => a.name.localeCompare(b.name))
            }
        }
        default:
            return state;
    }
}
export const SetCompositionsSuccess = (compositions) => ({
    type: SET_COMPOSITIONS, compositions
})
export const CreateSuccess = (composition) => ({
    type: CREATE_COMPOSITION, composition
})
export const UpdateSuccess = (composition) => ({
    type: UPDATE_COMPOSITION, composition
})
export const DeleteSuccess = (composition) => ({
    type: DELETE_COMPOSITION, composition
})
export const SortCompositionsSuccess = () => ({
    type: SORT_COMPOSITIONS
})

//TODO: Get WITH GenreId Param
export const getCompositions = () => {
    return (dispatch) => {
        //TODO: Get FROM API
        dispatch(SetCompositionsSuccess([
            {
                id: 1,
                name: 'DJ Turn it Up',
                filePath: 'https://xoctik.ucoz.ru/_ld/2/272_yellow-claw-dj-.mp3',
                description: 'This is DJ Turn it Up',
                lyrics:'f',
                bandId:'9616770f-6cb1-4c0e-a2a5-876881e9e3ba',
                genreId:'362b347c-be84-4d0d-a9fc-08e3ad7360a6',
                albumId:'41c5064d-515c-4a6c-8d4b-f403ee6d5117',
                year:2020,
            },
            {
                id: 2,
                name: 'Another Music',
                filePath: 'https://xoctik.ucoz.ru/_ld/2/271_Slipknot-Eyeles.mp3',
                description: 'This is Rock Composition',
                lyrics:'k',
                bandId:'c5a8e3f2-7aab-45fd-99f2-6492185c46c7',
                genreId:'3e4c7b2e-9d04-413c-bff5-d37c4d4d5453',
                albumId:'6b89cbb4-ca85-486f-9749-0335c36fa602',
                year:2019,
            },
            // {
            //     id: 3,
            //     name: 'ANOTHE',
            //     filePath: 'https://xoctik.ucoz.ru/_ld/2/262_LIL_PEEP-ANOTHE.mp3',
            //     description: 'This is DJ Turn it Up'
            // }
        ]));
    }
}
export const Create = (composition) => {
    return (dispatch) => {
        //TODO: POST REQUEST TO SERVER IF OK THEN dispatch
        dispatch(CreateSuccess(composition))
    }
}
export const Update = (composition) => {
    return (dispatch) => {
        //TODO: PUT REQUEST TO SERVER IF OK THEN dispatch
        dispatch(UpdateSuccess(composition))
    }
}
export const Delete = (composition) => {
    return (dispatch) => {
        //TODO: DELETE REQUEST TO SERVER IF OK THEN dispatch
        dispatch(DeleteSuccess(composition))
    }
}
export const SortCompositions = () => {
    return (dispatch) => {
        dispatch(SortCompositionsSuccess())
    }
}
export default CompositionReducer;