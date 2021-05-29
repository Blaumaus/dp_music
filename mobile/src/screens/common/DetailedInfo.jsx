import React, { memo } from 'react'
import { StyleSheet, ScrollView, Dimensions } from 'react-native'
import { View, Text, Image } from 'react-native-ui-lib'
import { useTranslation } from 'react-i18next'
import { Flag } from 'react-native-svg-flagkit'
import _isEmpty from 'lodash/isEmpty'
import _toUpper from 'lodash/toUpper'
import _map from 'lodash/map'

import { CDN_URL } from '../../../env'

const styles = StyleSheet.create({
  container: {
    minHeight: Dimensions.get('window').height,
    backgroundColor: '#fff',
    paddingTop: 40,
    paddingLeft: 20,
    paddingRight: 20,
  },
  image_container: {
    alignItems: 'center',
    maxHeight: 400,
    marginBottom: 20,
  },
  image: {
    width: Dimensions.get('window').width - 40,
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
  }
})

const params = {
  genre: ['name', 'description'],
  band: ['name', 'description', 'foundationDate', 'countryCode'],
  album: [],
}

const DetailedInfo = ({ route, navigation }) => {
  const { t } = useTranslation('common')
  const { data, type } = route.params
  if (_isEmpty(data) || !type) {
    navigation.goBack(null)
  }
  const { image } = data

  const getTextRepesentation = (el) => {
    if (el === 'countryCode') return t(`countries.${data[el]}`)
    if (el === 'foundationDate') return new Date(data[el]).getUTCFullYear()
    
    return data[el]
  }

  return (
    <ScrollView contentContainerStyle={styles.container}>
      {image && (
        <View style={styles.image_container}>
          {/* TODO: Fix image is not displaying bug. For some weird reason images in this component neither are loaded nor displayed to the user. */}
          <Image source={{ uri: CDN_URL + data.image }} style={styles.image} resizeMode='contain' />
        </View>
      )}
      {_map(params[type], el => (
        <Text key={el} style={styles.textBlock}>
          <Text style={styles.col_name}>{t(`home.${el}`)}: </Text>
          <Text style={styles.desc}>
            {el === 'countryCode' && <Flag id={_toUpper(data[el])} width={35} height={15} />}
            {getTextRepesentation(el)}
          </Text>
        </Text>
      ))}
    </ScrollView>
  )
}

export default memo(DetailedInfo)
