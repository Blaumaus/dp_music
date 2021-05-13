export const getAccessToken = () => {
	const accessToken = localStorage.getItem('access_token')

	if (!accessToken) {
		return null
	}
	return JSON.parse(accessToken)
}

export const setAccessToken = (token) => {
	localStorage.setItem('access_token', token)
}

export const removeAccessToken = () => {
	localStorage.removeItem('access_token')
}
