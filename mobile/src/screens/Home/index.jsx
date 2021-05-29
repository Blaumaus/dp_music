import React, { memo, useState, useEffect } from 'react'
import { StyleSheet, ScrollView, Dimensions } from 'react-native'
import { Text, Card, Button } from 'react-native-ui-lib'
import { useTranslation } from 'react-i18next'
import _isArray from 'lodash/isArray'
import _values from 'lodash/values'
import _toLower from 'lodash/toLower'
import _includes from 'lodash/includes'
import _filter from 'lodash/filter'
import _isEmpty from 'lodash/isEmpty'
import _map from 'lodash/map'
import _truncate from 'lodash/truncate'

import { CDN_URL } from '../../../env'
import { getGenres } from '../../api'
import Loading from '../common/Loading'

const styles = StyleSheet.create({
  container: {
    minHeight: Dimensions.get('window').height,
    backgroundColor: '#fff',
    alignItems: 'center',
    paddingTop: 40,
    paddingBottom: 30,
    paddingLeft: 20,
    paddingRight: 20,
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
  card: {
    marginBottom: 15,
    borderRadius: 10,
    backgroundColor: '#ffffff',
  },
  cardImage: {
    width: 115,
    height: '100%',
  },
  cardSection: {
    padding: 20,
    flex: 1,
  }
})

const Home = ({ navigation }) => {
  const { t } = useTranslation('common')
  const [genres, setGenres] = useState([])
	const [loading, setLoading] = useState(true)
	const [filterInput, setFilterInput] = useState('')

  const onSeatchByName = () => {
		return _filter(genres, ({ name }) => _includes(_toLower(name), _toLower(filterInput)))
	}

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
        <Text style={styles.text}>{t('home.noGenres')}</Text>
      ) : (
        <>
          <Text style={styles.text}>{t('home.availableGenres')}</Text>
          <Text style={styles.desc}>{t('home.holdForInfo')}</Text>
          {_map(genres, genre => {
            const { id, name, image, description } = genre
            const hasImage = _includes(image, id)

            return (
              <Card
                key={id}
                height={160}
                style={styles.card}
                onPress={() => navigation.navigate('Bands', {
                  info: genre,
                })}
                onLongPress={() => navigation.navigate('DetailedInfo', {
                  data: genre,
                  type: 'genre',
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
                    {text: name, text70: true, grey10: true},
                    {text: _truncate(description, {
                      'length': hasImage ? 70 : 85,
                      'omission': '...',
                    }), text80: true, grey10: true}
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
