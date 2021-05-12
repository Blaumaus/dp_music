
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
                compositionFile: 'https://xoctik.ucoz.ru/_ld/2/272_yellow-claw-dj-.mp3',
                description: 'This is DJ Turn it Up'
            },
            {
                id: 2,
                name: 'Another Music',
                compositionFile: 'https://xoctik.ucoz.ru/_ld/2/271_Slipknot-Eyeles.mp3',
                description: 'This is Rock Composition'
            },
            {
                id: 3,
                name: 'ANOTHE',
                compositionFile: 'https://xoctik.ucoz.ru/_ld/2/262_LIL_PEEP-ANOTHE.mp3',
                description: 'This is DJ Turn it Up'
            },
            {
                id: 4,
                name: 'DJ Turn it Up',
                compositionFile: 'https://xoctik.ucoz.ru/_ld/2/272_yellow-claw-dj-.mp3',
                description: 'This is DJ Turn it Up'
            },
            {
                id: 5,
                name: 'DJ Turn it Up',
                compositionFile: 'https://xoctik.ucoz.ru/_ld/2/272_yellow-claw-dj-.mp3',
                description: 'This is DJ Turn it Up'
            },
            {
                id: 6,
                name: 'ANOTHE',
                compositionFile: 'https://xoctik.ucoz.ru/_ld/2/262_LIL_PEEP-ANOTHE.mp3',
                description: 'This is DJ Turn it Up'
            },
            {
                id: 7,
                name: 'DJ Turn it Up',
                compositionFile: 'https://xoctik.ucoz.ru/_ld/2/272_yellow-claw-dj-.mp3',
                description: 'This is DJ Turn it Up'
            },
            {
                id: 8,
                name: 'DJ Turn it Up',
                compositionFile: 'https://xoctik.ucoz.ru/_ld/2/272_yellow-claw-dj-.mp3',
                description: 'This is DJ Turn it Up'
            },
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