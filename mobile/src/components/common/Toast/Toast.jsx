import React from 'react'
import { ToastAndroid } from 'react-native'
import _toString from 'lodash/toString'

const Toast = ({ error, clearErrors }) => {
  if (error) {
    ToastAndroid.showWithGravity(_toString(error), ToastAndroid.BOTTOM, 5000)
    clearErrors()
  }

  return <></>
}

export default Toast
