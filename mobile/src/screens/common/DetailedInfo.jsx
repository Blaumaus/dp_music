import React, { memo } from 'react'
import { StyleSheet, ScrollView, Dimensions, Image } from 'react-native'
import { View, Text } from 'react-native-ui-lib'
import _isEmpty from 'lodash/isEmpty'
import _map from 'lodash/map'

import { CDN_URL } from '../../../env'

const styles = StyleSheet.create({
  container: {
    flex: 1,
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
})

// temporary
const translation = {
  'name': 'Name',
  'description': 'Description',
}

const params = {
  genre: ['name', 'description'],
  band: [],
  album: [],
}

const DetailedInfo = ({ route, navigation }) => {
  const { data, type } = route.params

  if (_isEmpty(data) || !type) {
    navigation.goBack(null)
  }

  return (
    <ScrollView contentContainerStyle={styles.container}>
      {data.image && (
        <View style={styles.image_container}>
          <Image source={{ uri: CDN_URL + data.image }} style={styles.image} />
        </View>
      )}
      {_map(params[type], el => (
        <Text key={el}>
          <Text style={styles.col_name}>{translation[el]}: </Text>
          <Text style={styles.desc}>{data[el]}</Text>
        </Text>
      ))}
    </ScrollView>
  )
}

export default memo(DetailedInfo)
