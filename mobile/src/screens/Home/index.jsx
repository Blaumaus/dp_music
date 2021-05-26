import React, { memo, useState, useEffect } from 'react'
import { StyleSheet } from 'react-native'
import { View, Text, Card } from 'react-native-ui-lib'
import _isArray from 'lodash/isArray'
import _values from 'lodash/values'
import _toLower from 'lodash/toLower'
import _includes from 'lodash/includes'
import _filter from 'lodash/filter'
import _isEmpty from 'lodash/isEmpty'
import _map from 'lodash/map'

import { getGenres } from '../../api'
import Loading from '../common/Loading'

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    paddingTop: 50,
    paddingLeft: 20,
    paddingRight: 20,
  },
  text: {
    marginBottom: 20,
    fontSize: 18,
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

const Home = () => {
  const [genres, setGenres] = useState([])
	const [loading, setLoading] = useState(false)
	const [filterInput, setFilterInput] = useState('')

  const onSeatchByName = () => {
		return _filter(genres, ({ name }) => _includes(_toLower(name), _toLower(filterInput)))
	}

  useEffect(() => {
    const loadGenres = async () => {
      // try {
      //   const data = await getGenres()
      //   console.log(data)
  
      //   if (_isArray(data)) {
      //     setGenres(data)
      //   } else {
      //     setGenres(_values(data))
      //   }
  
      //   setLoading(false)
      // } catch (e) {
      //   console.error(e)
      // }
      setGenres([{"id":"8158cc6f-aebb-418d-9b0a-e0acc3f443a3","name":"Rock","image":"https://media-cdn.tripadvisor.com/media/photo-s/14/7f/1a/46/rock-n-roll-athens.jpg","description":"Rock.","file":null}, {"id":"8158cc6f-aebb-418d-9b0a-e0acc3f443a4","name":"Pop","image":"https://upload.wikimedia.org/wikipedia/commons/thumb/0/0c/Shure_mikrofon_55S.jpg/492px-Shure_mikrofon_55S.jpg","description":"Pop genre description blah blah blah blah.","file":null}])
    }

    loadGenres()
  }, [])

  if (loading) {
    return (
      <Loading />
    )
  }

  return (
    <View style={styles.container}>
      {_isEmpty(genres) ? (
        <Text style={styles.text}>There are currently no genres available.. :(</Text>
      ) : (
        <>
          <Text style={styles.text}>Available genres</Text>
          {_map(genres, ({ id, name, image, description }) => (
            <Card
              key={id}
              height={160}
              style={styles.card}
              onPress={() => {}}
              borderRadius={styles.card.borderRadius}
              backgroundColor={styles.card.backgroundColor}
              activeOpacity={1}
              activeScale={0.96}
              useNative
              row
            >
              {image && (
                <Card.Section
                  imageSource={{ uri: image }}
                  imageStyle={styles.cardImage}
                />
              )}
              <Card.Section
                content={[
                  {text: name, text70: true, grey10: true},
                  {text: description, text80: true, grey10: true},
                ]}
                style={styles.cardSection}
              />
            </Card>
          ))}
        </>
      )}
    </View>
  )
}

export default memo(Home)
