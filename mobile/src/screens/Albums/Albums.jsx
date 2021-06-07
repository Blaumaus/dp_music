import React, { memo, useState, useEffect } from 'react'
import { StyleSheet, ScrollView, Dimensions, TouchableOpacity } from 'react-native'
import { Text, Card, Button, View } from 'react-native-ui-lib'
import { useTranslation } from 'react-i18next'
import _toUpper from 'lodash/toUpper'
import _isArray from 'lodash/isArray'
import _values from 'lodash/values'
import _includes from 'lodash/includes'
import _isEmpty from 'lodash/isEmpty'
import _map from 'lodash/map'
import _truncate from 'lodash/truncate'

import { CDN_URL } from '../../../env'
import constants from '../../redux/constants'
import { getAlbums } from '../../api'
import Loading from '../common/Loading'

const getStyles = theme => StyleSheet.create({
  container: {
    minHeight: Dimensions.get('window').height - 80,
    backgroundColor: theme === 'dark' ? constants.BACKGROUND_DARK : constants.BACKGROUND_LIGHT,
    alignItems: 'center',
    paddingTop: 10,
    paddingBottom: 30,
    paddingHorizontal: 20,
  },
  text: {
    marginBottom: 5,
    fontSize: 21,
    textAlign: 'center',
  },
  desc: {
    marginBottom: 20,
    fontSize: 16,
    textAlign: 'center',
    fontStyle: 'italic',
  },
  themedText: {
    color: theme === 'dark' ? constants.TEXT_LIGHT : constants.TEXT_DARK,
  },
  card: {
    marginBottom: 15,
    borderRadius: 10,
    backgroundColor: theme === 'dark' ? constants.BACKGROUND_DARK_2 : constants.BACKGROUND_LIGHT,
  },
  cardImage: {
    width: 115,
    height: '100%',
  },
  cardSection: {
    paddingHorizontal: 20,
    paddingTop: 10,
    flex: 1,
  },
  metadata: {
    position: 'absolute',
    bottom: 8,
    left: 18,
    alignItems: 'center',
  },
  link: {
    color: '#3366ff',
    fontSize: 18,
    marginBottom: 5,
  }
})

const Albums = ({ route, navigation, theme }) => {
  const styles = getStyles(theme)
  const { t } = useTranslation('common')
  const { info } = route.params
  if (_isEmpty(info)) {
    navigation.goBack(null)
  }
  const { id, name } = info

  const [albums, setAlbums] = useState([])
	const [loading, setLoading] = useState(true)

  const loadAlbums = async () => {
    setLoading(true)
    try {
      const data = await getAlbums(id)

      if (_isArray(data)) {
        setAlbums(data)
      } else {
        setAlbums(_values(data))
      }
    } catch (e) {
      console.error('Error while loading albums')
      console.error(e)
    } finally {
      setLoading(false)
    }
  }

  useEffect(() => {
    loadAlbums()
  }, [info])

  if (loading) {
    return (
      <Loading />
    )
  }

  return (
    <ScrollView contentContainerStyle={styles.container}>
      {_isEmpty(albums) ? (
        <Text style={[styles.text, styles.themedText]}>{t('albums.noAlbums', { band: name })}</Text>
      ) : (
        <>
          <Text style={[styles.text, styles.themedText]}>{t('albums.availableAlbums', { band: name })}</Text>
          <TouchableOpacity onPress={() => navigation.navigate('songs', { band: info, album: null })}>
            <Text style={styles.link}>
              {t('albums.goToTracks')}
					  </Text>
          </TouchableOpacity>
          <Text style={[styles.desc, styles.themedText]}>{t('home.holdForInfo')}</Text>
          {_map(albums, album => {
            const { id, name, image, description, year } = album
            const hasImage = _includes(image, id)

            return (
              <Card
                key={id}
                height={170}
                style={styles.card}
                onPress={() => navigation.navigate('songs', { band: info, album })}
                onLongPress={() => navigation.navigate('detailedInfo', {
                  data: album,
                  type: 'album',
                })}
                borderRadius={styles.card.borderRadius}
                backgroundColor={styles.card.backgroundColor}
                activeOpacity={1}
                activeScale={0.96}
                useNative
                row
              >
                {hasImage && (
                  <Card.Section
                    imageSource={{ uri: CDN_URL + image }}
                    imageStyle={styles.cardImage}
                  />
                )}
                <View style={styles.cardSection}>
                  <Text style={styles.themedText} text70>
                    {name}
                  </Text>
                  <View>
                    <Text style={styles.themedText} text80>
                      {_truncate(description, {
                        'length': hasImage ? 66 : 130,
                        'omission': '...',
                      })}
                    </Text>
                  </View>

                  <View style={styles.metadata} row>
                    <Text style={styles.themedText}>{year}</Text>
                  </View>
                </View>
              </Card>
            )
          })}
        </>
      )}
      <Button onPress={loadAlbums} label={t('home.refresh')} backgroundColor="#3366ff" />
    </ScrollView>
  )
}

export default memo(Albums)
