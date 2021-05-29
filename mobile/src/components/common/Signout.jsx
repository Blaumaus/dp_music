import React, { useEffect } from 'react'
import { useDispatch } from 'react-redux'
import { authActions } from '../../redux/actions/auth'

// temp solution
export default ({ navigation }) => {
  const dispatch = useDispatch()

  useEffect(() => {
    dispatch(authActions.logout())
    navigation.navigate('Auth')
  }, [])

  return <></>
}