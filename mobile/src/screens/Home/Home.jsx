import React, { memo, useState, useEffect } from 'react'
import { StyleSheet, ScrollView, Dimensions } from 'react-native'
import { Text, Card, Button } from 'react-native-ui-lib'
import { useTranslation } from 'react-i18next'
import _isArray from 'lodash/isArray'
import _values from 'lodash/values'
import _includes from 'lodash/includes'
import _isEmpty from 'lodash/isEmpty'
import _map from 'lodash/map'
import _truncate from 'lodash/truncate'

import constants from '../../redux/constants'
import { CDN_URL } from '../../../env'
import { getGenres } from '../../api'
import Loading from '../common/Loading'

const getStyles = theme => StyleSheet.create({
  container: {
    minHeight: Dimensions.get('window').height - 80,
    backgroundColor: theme === 'dark' ? constants.BACKGROUND_DARK : constants.BACKGROUND_LIGHT,
    alignItems: 'center',
    paddingTop: 10,
    paddingBottom: 15,
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
  }
})

const Home = ({ navigation, theme }) => {
  const styles = getStyles(theme)
  const { t } = useTranslation('common')
  const [genres, setGenres] = useState([])
	const [loading, setLoading] = useState(true)

  const loadGenres = async () => {
    try {
      const data = await getGenres()

      if (_isArray(data)) {
        setGenres(data)
      } else {
        setGenres(_values(data))
      }
    } catch (e) {
      console.error('Error while receiving genres')
      console.error(e)
    } finally {
      setLoading(false)
    }
  }

  useEffect(() => {
    loadGenres()
  }, [])

  if (loading) {
    return (
      <Loading />
    )
  }

  return (
    <ScrollView contentContainerStyle={styles.container}>
      {_isEmpty(genres) ? (
        <Text style={[styles.text, styles.themedText]}>{t('home.noGenres')}</Text>
      ) : (
        <>
          <Text style={[styles.text, styles.themedText]}>{t('home.availableGenres')}</Text>
          <Text style={[styles.desc, styles.themedText]}>{t('home.holdForInfo')}</Text>
          {_map(genres, genre => {
            const { id, name, image, description } = genre
            const hasImage = _includes(image, id)

            return (
              <Card
                key={id}
                height={160}
                style={styles.card}
                onPress={() => navigation.navigate('bands', {
                  info: genre,
                })}
                onLongPress={() => navigation.navigate('detailedInfo', {
                  data: genre,
                  type: 'genre',
                  theme,
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
                <Card.Section
                  content={[
                    { text: name, text70: true, color: styles.themedText.color },
                    {
                      text: _truncate(description, {
                        'length': hasImage ? 90 : 130,
                        'omission': '...',
                      }),
                      text80: true,
                      color: styles.themedText.color,
                    }
                  ]}
                  style={styles.cardSection}
                />
              </Card>
            )
          })}
        </>
      )}
      <Button onPress={loadGenres} label={t('home.refresh')} backgroundColor="#3366ff" />
    </ScrollView>
  )
}

export default memo(Home)
