import React, { memo, useState, useEffect } from 'react'
import { StyleSheet, Dimensions, FlatList, SafeAreaView, Image } from 'react-native'
import { Text, Button, View, BorderRadiuses, ListItem, Colors } from 'react-native-ui-lib'
import { useTranslation } from 'react-i18next'
import { Audio } from 'expo-av'
import _isArray from 'lodash/isArray'
import _values from 'lodash/values'
import _isEmpty from 'lodash/isEmpty'
import _findIndex from 'lodash/findIndex'
import _size from 'lodash/size'
import _head from 'lodash/head'
import _last from 'lodash/last'
import _get from 'lodash/get'

import Player from '../../components/Player'
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
  activeText: {
    color: '#3366ff',
  },
  image: {
    width: 54,
    height: 54,
    borderRadius: BorderRadiuses.br20,
    marginHorizontal: 14,
  },
  card: {
    backgroundColor: theme === 'dark' ? constants.BACKGROUND_DARK : constants.BACKGROUND_LIGHT,
    flex: 1,
    height: 60,
    width: Dimensions.get('window').width - 40,
    justifyContent: 'flex-start',
    alignItems: 'center',
    borderBottomWidth: StyleSheet.hairlineWidth,
    borderColor: theme === 'dark' ? Colors.grey30 : Colors.dark70,
  },
})

const Songs = ({ route, navigation, theme }) => {
  const styles = getStyles(theme)
  const { t } = useTranslation('common')
  const [songs, setSongs] = useState([])
  const [activeSong, setActiveSong] = useState([])
  const [loading, setLoading] = useState(true)
  const [sound, setSound] = useState()
  const [playbackStatus, setPlaybackStatus] = useState({})

  const { band, album } = route.params
  let bandId, bandName, albumId, albumName

  if (!_isEmpty(album)) {
    const { id, name } = album
    albumId = id
    albumName = name
  }
  if (!_isEmpty(band)) {
    const { id, name } = band
    bandId = id
    bandName = name
  }

  if (_isEmpty(album) && _isEmpty(band)) {
    navigation.goBack(null)
  }

  const _onPlaybackStatusUpdate = (status) => {
    setPlaybackStatus(status)
  }

  const loadSound = async (uri) => {
    const { sound } = await Audio.Sound.createAsync({ uri }, {}, _onPlaybackStatusUpdate)
    setSound(sound)
    await sound.playAsync()
  }

  const playSound = async () => {
    await sound.playAsync()
  }

  const pauseSound = async () => {
    await sound.pauseAsync()
  }

  const stopSound = async () => {
    await sound.stopAsync()
  }

  const onTogglePlay = async () => {
    if (playbackStatus.isPlaying) {
      await pauseSound()
    } else {
      await playSound()
    }
  }

  const onToggleLoop = async () => {
    await sound.setIsLoopingAsync(!playbackStatus.isLooping)
  }

  const onToggleNext = () => {
    const currentID = _findIndex(songs, ({ id }) => id === activeSong.id)

    if (1 + currentID < _size(songs)) {
      setActiveSong(_get(songs, currentID + 1, {}))
    } else {
      setActiveSong(_head(songs))
    }
  }

  const onTogglePrev = () => {
    const currentID = _findIndex(songs, ({ id }) => id === activeSong.id)

    if (currentID <= 0) {
      setActiveSong(_last(songs))
    } else {
      setActiveSong(_get(songs, currentID - 1, {}))
    }
  }

  useEffect(() => {
    return sound
      ? () => { sound.unloadAsync() }
      : undefined
  }, [sound])

  useEffect(() => {
    if (!_isEmpty(activeSong)) {
      stopSound()
      const { filePath } = activeSong
      loadSound(filePath)
    }
  }, [activeSong])

  const loadSongs = async () => {
    setLoading(true)
    try {
      // const data = await getSongs(albumId, bandId)

      // if (_isArray(data)) {
      //   setSongs(data)
      // } else {
      //   setSongs(_values(data))
      // }
      setSongs([
        { id: 'abcdef1', name: 'Twista ft. Faith Evans - Hope', filePath: 'https://minty.club/artist/twista/hope-feat-faith-evans/twista-hope-feat-faith-evans.mp3' },
        { id: 'abcdef2', name: '2Pac - Dear Mama', filePath: 'https://www.naijafinix.com.ng/wp-content/uploads/2020/10/2Pac-%E2%80%93-Dear-Mama-via-Naijafinix.com_.mp3' },
        { id: 'abcdef3', name: 'Twista ft. Faith Evans - Hope', filePath: 'https://minty.club/artist/twista/hope-feat-faith-evans/twista-hope-feat-faith-evans.mp3' },
        { id: 'abcdef4', name: '2Pac - Dear Mama', filePath: 'https://www.naijafinix.com.ng/wp-content/uploads/2020/10/2Pac-%E2%80%93-Dear-Mama-via-Naijafinix.com_.mp3' },
        { id: 'abcdef5', name: 'Twista ft. Faith Evans - Hope', filePath: 'https://minty.club/artist/twista/hope-feat-faith-evans/twista-hope-feat-faith-evans.mp3' },
        { id: 'abcdef6', name: '2Pac - Dear Mama', filePath: 'https://www.naijafinix.com.ng/wp-content/uploads/2020/10/2Pac-%E2%80%93-Dear-Mama-via-Naijafinix.com_.mp3' },
        { id: 'abcdef7', name: 'Twista ft. Faith Evans - Hope', filePath: 'https://minty.club/artist/twista/hope-feat-faith-evans/twista-hope-feat-faith-evans.mp3' },
        { id: 'abcdef8', name: '2Pac - Dear Mama', filePath: 'https://www.naijafinix.com.ng/wp-content/uploads/2020/10/2Pac-%E2%80%93-Dear-Mama-via-Naijafinix.com_.mp3' },
        { id: 'abcdef9', name: 'Twista ft. Faith Evans - Hope', filePath: 'https://minty.club/artist/twista/hope-feat-faith-evans/twista-hope-feat-faith-evans.mp3' },
        { id: 'abcdef10', name: '2Pac - Dear Mama', filePath: 'https://www.naijafinix.com.ng/wp-content/uploads/2020/10/2Pac-%E2%80%93-Dear-Mama-via-Naijafinix.com_.mp3' },
      ])
    } catch (e) {
      console.error('Error while loading songs')
      console.error(e)
    } finally {
      setLoading(false)
    }
  }

  useEffect(() => {
    loadSongs()
  }, [bandId, albumId])

  if (loading) {
    return (
      <Loading />
    )
  }

  const keyExtractor = ({ name, id }) => id || name

  const renderRow = ({ item }) => {
    const { name, id } = item

    const onPress = async () => {
      if (id === activeSong.id) {
        onTogglePlay()
      } else {
        setActiveSong(item)
      }
    }

    return (
      <ListItem
        activeBackgroundColor={Colors.dark60}
        activeOpacity={0.3}
        onPress={onPress}
        style={styles.card}
      >
        <Text text70 style={[styles.themedText, id === activeSong.id && styles.activeText]}>{name}</Text>
      </ListItem>
    )
  }

  return (
    <View style={styles.container}>
      {_isEmpty(songs) ? (
        <Text style={[styles.text, styles.themedText]}>{albumName ? t('songs.noSongs', { album: albumName }) : t('songs.noSongsBand', { band: bandName })}</Text>
      ) : (
        <>
          <Text style={[styles.text, styles.themedText]}>{albumName ? t('songs.availableSongs', { album: albumName }) : t('songs.availableSongsBand', { band: bandName })}</Text>
          {/* <Text style={[styles.desc, styles.themedText]}>{t('home.holdForInfo')}</Text> */}
          {!_isEmpty(activeSong) && (
            <Player
              onTogglePlay={onTogglePlay}
              onToggleLoop={onToggleLoop}
              onToggleNext={onToggleNext}
              onTogglePrev={onTogglePrev}
              onToggleStop={stopSound}
              name={activeSong.name}
              bandName={bandName}
              {...playbackStatus}
            />
          )}
          <SafeAreaView style={{ flex: 1, marginBottom: 10 }}>
            <FlatList
              data={songs}
              renderItem={renderRow}
              keyExtractor={keyExtractor}
            />
          </SafeAreaView>
        </>
      )}
      <Button onPress={loadSongs} label={t('home.refresh')} backgroundColor='#3366ff' />
    </View>
  )
}

export default memo(Songs)
