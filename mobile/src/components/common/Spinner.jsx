import React from 'react'
import { ActivityIndicator } from 'react-native'

export default ({ size = 'large', style = {} }) => (
  <ActivityIndicator style={style} size={size} color='#3366ff' />
)
