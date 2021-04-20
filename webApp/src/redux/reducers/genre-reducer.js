
const CREATE = 'CREATE';
const UPDATE = 'UPDATE';
const DELETE = 'DELETE';

let initialState = {
    genres: [
        { id: 1, name: 'Rock', image: 'https://image.freepik.com/free-vector/rock-and-music-logo-template_1895-5.jpg', description: 'This is Rock' }
    ]
};
const GenreReducer = (state = initialStat, action) => {
    switch (action.type) {
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
        case UPDATE:
        case DELETE:
        default:
            return state;
    }
}
export const CreateAC = () => ({
    type: CREATE, genreId
})
export const UpdateAC = () => ({
    type: UPDATE, genreId
})
export const DeleteAC = () => ({
    type: DELETE, genreId
})