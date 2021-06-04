import React, { memo, useState, useEffect } from 'react'
import { StyleSheet, ScrollView, Dimensions } from 'react-native'
import { Text, Button, View } from 'react-native-ui-lib'
import { useTranslation } from 'react-i18next'
import _isArray from 'lodash/isArray'
import _values from 'lodash/values'
import _isEmpty from 'lodash/isEmpty'
import _map from 'lodash/map'

import { CDN_URL } from '../../../env'
import constants from '../../redux/constants'
import { getSongs } from '../../api'
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
})

const Songs = ({ route, navigation, theme }) => {
  const styles = getStyles(theme)
  const { t } = useTranslation('common')
  const { info } = route.params
  if (_isEmpty(info)) {
    navigation.goBack(null)
  }
  const { id, name } = info

  const [songs, setSongs] = useState([])
  const [activeSong, setActiveSong] = useState([])
	const [loading, setLoading] = useState(true)

  const loadSongs = async () => {
    setLoading(true)
    try {
      const data = await getSongs(id)

      if (_isArray(data)) {
        setSongs(data)
      } else {
        setSongs(_values(data))
      }
    } catch (e) {
      console.error('Error while loading songs')
      console.error(e)
    } finally {
      setLoading(false)
    }
  }

  useEffect(() => {
    loadSongs()
  }, [info])

  if (loading) {
    return (
      <Loading />
    )
  }

  return (
    <ScrollView contentContainerStyle={styles.container}>
      {_isEmpty(songs) ? (
        <Text style={[styles.text, styles.themedText]}>{t('songs.noSongs', { album: name })}</Text>
      ) : (
        <>
          <Text style={[styles.text, styles.themedText]}>{t('songs.availableSongs', { album: name })}</Text>
          <Text style={[styles.desc, styles.themedText]}>{t('home.holdForInfo')}</Text>
          {activeSong && (
            <></>
          )}
          {_map(songs, song => {
            const { id, name, description } = song

            return (
              <></>
            )
          })}
        </>
      )}
      <Button onPress={loadSongs} label={t('home.refresh')} backgroundColor="#3366ff" />
    </ScrollView>
  )
}

export default memo(Songs)
