import React, { memo } from 'react'
import PropTypes from 'prop-types'
import { StyleSheet, Dimensions, Image } from 'react-native'
import { View, Text, ProgressBar, Colors, Card, TouchableOpacity } from 'react-native-ui-lib'

import constants from '../../redux/constants'
import Spinner from '../common/Spinner'

import play from '../../assets/play.png'
import loop from '../../assets/loop.png'
import pause from '../../assets/pause.png'
import next from '../../assets/next.png'
import previous from '../../assets/previous.png'
import stop from '../../assets/stop.png'

const getStyles = theme => StyleSheet.create({
  card: {
    marginBottom: 15,
    borderRadius: 10,
    backgroundColor: theme === 'dark' ? constants.BACKGROUND_DARK_2 : constants.BACKGROUND_LIGHT,
    width: Dimensions.get('window').width - 40,
  },
  cardSection: {
    paddingHorizontal: 20,
    paddingTop: 10,
    flex: 1,
  },
  progressBar: {
    position: 'absolute',
    bottom: 50,
    left: 20,
    width: Dimensions.get('window').width - 80,
  },
  songTitle: {
    textAlign: 'center',
    fontSize: 18,
  },
  songAuthor: { // would be useful if it's been implemented on the backend side

  },
  themedText: {
    color: theme === 'dark' ? constants.TEXT_LIGHT : constants.TEXT_DARK,
  },
  buttonsGroupContainer: {
    position: 'absolute',
    bottom: 10,
    width: Dimensions.get('window').width - 40,
  },
  buttonsGroup: {
    flexDirection: 'row',
    justifyContent: 'space-around',
  },
  button: {
    width: 28,
    height: 28,
    tintColor: theme === 'dark' ? constants.TEXT_LIGHT : constants.TEXT_DARK,
  },
  buttonActive: {
    tintColor: '#3366ff',
  },
  spinner: {
    position: 'absolute',
    top: 15,
    right: 15,
  },
})

// todo: add mute functionality
const Player = ({
  theme, name, isPlaying, positionMillis, durationMillis, onTogglePlay, onToggleLoop,
  onToggleNext, onToggleStop, onTogglePrev, isLoaded, isBuffering, isLooping, // isMuted,
}) => {
  const styles = getStyles(theme)

  return (
    <Card
      height={160}
      style={styles.card}
      borderRadius={styles.card.borderRadius}
      backgroundColor={styles.card.backgroundColor}
      useNative
      row
    >
      <View style={styles.cardSection}>
        {(!isLoaded || isBuffering) && (
          <Spinner style={styles.spinner} size='small' />
        )}
        <Text style={[styles.songTitle, styles.themedText]}>{name}</Text>
        <View style={styles.progressBar}>
          <ProgressBar
            progress={(positionMillis / durationMillis) * 100}
            height={6}
            backgroundColor='#3366ff'
            progressBackgroundColor={Colors.blue70}
          />
        </View>
        <View style={styles.buttonsGroupContainer}>
          <View style={styles.buttonsGroup}>
            <TouchableOpacity onPress={onToggleStop}>
              <Image source={stop} style={styles.button} />
            </TouchableOpacity>
            <TouchableOpacity onPress={onTogglePrev}>
              <Image source={previous} style={styles.button} />
            </TouchableOpacity>
            <TouchableOpacity onPress={onTogglePlay}>
              {isPlaying ? (
                <Image source={pause} style={styles.button} />
              ) : (
                <Image source={play} style={styles.button} />
              )}
            </TouchableOpacity>
            <TouchableOpacity onPress={onToggleNext}>
              <Image source={next} style={styles.button} />
            </TouchableOpacity>
            <TouchableOpacity onPress={onToggleLoop}>
              <Image source={loop} style={[styles.button, isLooping && styles.buttonActive]} />
            </TouchableOpacity>
          </View>
        </View>
      </View>
    </Card>
  )
}

Player.propTypes = {
  theme: PropTypes.oneOf(['dark', 'white']).isRequired,
  isLoaded: PropTypes.bool.isRequired,
  isLooping: PropTypes.bool,
  isPlaying: PropTypes.bool,
  positionMillis: PropTypes.number,
  durationMillis: PropTypes.number,
  isBuffering: PropTypes.bool.isRequired,
  name: PropTypes.string,
  onTogglePlay: PropTypes.func,
  onToggleLoop: PropTypes.func,
  onToggleNext: PropTypes.func,
  onTogglePrev: PropTypes.func,
  onToggleStop: PropTypes.func,
}

Player.defaultProps = {
  name: '',
  onTogglePlay: () => { },
  onToggleLoop: () => { },
  onToggleNext: () => { },
  onTogglePrev: () => { },
  onToggleStop: () => { },
  positionMillis: 0,
  durationMillis: 100,
  isPlaying: true,
  isLooping: false,
}

export default memo(Player)