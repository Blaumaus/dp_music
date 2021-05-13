import React, { useEffect } from 'react'

// temp solution
export default ({ navigation }) => {
  useEffect(() => {
    navigation.navigate('Auth')
  }, [])

  return <></>
}