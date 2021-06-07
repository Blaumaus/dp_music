import CompositionApi from 'api/modules/composition';
import BuildUrl from 'helpers/BuildUrl'


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

export const getCompositions = (albumId, bandId) => {
    return (dispatch) => {
        return CompositionApi.getCompositions(albumId, bandId).then(data => {
            const compositions = Object.values(data.data);
            compositions.forEach(composition => {
                composition.filePath = BuildUrl.getUrl(composition.filePath)
            })
            dispatch(SetCompositionsSuccess(compositions))
        });
    }
}
export const Create = (composition) => {
    return (dispatch) => {
        return CompositionApi.create(composition).then(
            dispatch(CreateSuccess(composition))
        );
    }
}
export const Update = (composition) => {
    return (dispatch) => {
        return CompositionApi.update(composition).then(
            dispatch(UpdateSuccess(composition))
        );
    }
}
export const Delete = (composition) => {
    return (dispatch) => {
        return CompositionApi.delete(composition.id).then(
            dispatch(DeleteSuccess(composition))
        );
    }
}
export const SortCompositions = () => {
    return (dispatch) => {
        dispatch(SortCompositionsSuccess())
    }
}
export default CompositionReducer;