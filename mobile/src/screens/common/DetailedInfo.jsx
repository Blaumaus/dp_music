import React, { memo } from 'react'
import { StyleSheet, ScrollView, Dimensions } from 'react-native'
import { View, Text, Image } from 'react-native-ui-lib'
import { useTranslation } from 'react-i18next'
import { Flag } from 'react-native-svg-flagkit'
import _isEmpty from 'lodash/isEmpty'
import _toUpper from 'lodash/toUpper'
import _map from 'lodash/map'

import constants from '../../redux/constants'
import { CDN_URL } from '../../../env'

const getStyles = theme => StyleSheet.create({
  container: {
    minHeight: Dimensions.get('window').height - 80,
    backgroundColor: theme === 'dark' ? constants.BACKGROUND_DARK : constants.BACKGROUND_LIGHT,
    paddingHorizontal: 20,
    paddingVertical: 10,
  },
  image_container: {
    alignItems: 'center',
    maxHeight: 400,
  },
  image: {
    width: Dimensions.get('window').width - 40,
    height: 400,
    borderRadius: 10,
  },
  col_name: {
    fontSize: 18,
    fontWeight: 'bold',
  },
  desc: {
    fontSize: 16,
  },
  textBlock: {
    marginTop: 10,
  },
  text: {
    color: theme === 'dark' ? constants.TEXT_LIGHT : constants.TEXT_DARK,
  },
})

const params = {
  genre: ['name', 'description'],
  band: ['name', 'description', 'foundationDate', 'countryCode'],
  album: ['name', 'description', 'year'],
}

const DetailedInfo = ({ route, navigation }) => {
  const { t } = useTranslation('common')
  const { data, type, theme } = route.params
  const styles = getStyles(theme)
  if (_isEmpty(data) || !type) {
    navigation.goBack(null)
  }
  const { image } = data

  const getTextRepesentation = (el) => {
    if (el === 'countryCode') return t(`countries.${_toUpper(data[el])}`)
    if (el === 'foundationDate' || el === 'year') return new Date(data[el]).getUTCFullYear()
    
    return data[el]
  }

  return (
    <ScrollView contentContainerStyle={styles.container}>
      {image && (
        <View style={styles.image_container}>
          <Image source={{ uri: CDN_URL + image }} style={styles.image} />
        </View>
      )}
      {_map(params[type], el => (
        <Text key={el} style={{ ...styles.textBlock, ...styles.text }}>
          <Text style={{ ...styles.col_name, ...styles.text }}>{t(`home.${el}`)}: </Text>
          <Text style={{ ...styles.desc, ...styles.text }}>
            {el === 'countryCode' && <Flag id={_toUpper(data[el])} width={35} height={15} />}
            {getTextRepesentation(el)}
          </Text>
        </Text>
      ))}
    </ScrollView>
  )
}

export default memo(DetailedInfo)
