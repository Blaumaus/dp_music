import React, { memo, useState, useEffect } from 'react'
import { StyleSheet, ScrollView, Dimensions } from 'react-native'
import { Text, Card, Button, View } from 'react-native-ui-lib'
import { useTranslation } from 'react-i18next'
import { Flag } from 'react-native-svg-flagkit'
import _toUpper from 'lodash/toUpper'
import _isArray from 'lodash/isArray'
import _values from 'lodash/values'
import _includes from 'lodash/includes'
import _isEmpty from 'lodash/isEmpty'
import _map from 'lodash/map'
import _truncate from 'lodash/truncate'

import { CDN_URL } from '../../../env'
import constants from '../../redux/constants'
import { getBands } from '../../api'
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
  },
  metadata: {
    position: 'absolute',
    bottom: 10,
    left: 15,
    alignItems: 'center',
  }
})

const Bands = ({ route, navigation, theme }) => {
  const styles = getStyles(theme)
  const { t } = useTranslation('common')
  const { info } = route.params
  if (_isEmpty(info)) {
    navigation.goBack(null)
  }
  const { id, name } = info

  const [bands, setBands] = useState([])
	const [loading, setLoading] = useState(true)

  const loadBands = async () => {
    setLoading(true)
    try {
      const data = await getBands(id)

      if (_isArray(data)) {
        setBands(data)
      } else {
        setBands(_values(data))
      }
    } catch (e) {
      console.error('Error while receiving bands')
      console.error(e)
    } finally {
      setLoading(false)
    }
  }

  useEffect(() => {
    loadBands()
  }, [info])

  if (loading) {
    return (
      <Loading />
    )
  }

  return (
    <ScrollView contentContainerStyle={styles.container}>
      {_isEmpty(bands) ? (
        <Text style={styles.text}>{t('home.noBands', { genre: name })}</Text>
      ) : (
        <>
          <Text style={[styles.text, styles.themedText]}>{t('home.availableBands', { genre: name })}</Text>
          <Text style={[styles.desc, styles.themedText]}>{t('home.holdForInfo')}</Text>
          {_map(bands, band => {
            const { id, name, image, description, foundationDate, countryCode } = band
            const hasImage = _includes(image, id)

            return (
              <Card
                key={id}
                height={170}
                style={styles.card}
                onPress={() => navigation.navigate('albums', { info: band })}
                onLongPress={() => navigation.navigate('detailedInfo', {
                  data: band,
                  type: 'band',
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
                    <Text style={styles.themedText}>
                      {_truncate(description, {
                        'length': hasImage ? 76 : 130,
                        'omission': '...',
                      })}
                    </Text>
                  </View>

                  <View row style={styles.metadata}>
                    <Text>
                      <Flag id={_toUpper(countryCode)} width={35} height={17} />
                    </Text>
                    <Text style={styles.themedText} row right>| {new Date(foundationDate).getUTCFullYear()}</Text>
                  </View>
                </View>
              </Card>
            )
          })}
        </>
      )}
      <Button onPress={loadBands} label={t('home.refresh')} backgroundColor="#3366ff" />
    </ScrollView>
  )
}

export default memo(Bands)
