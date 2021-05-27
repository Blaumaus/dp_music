import React, { useState } from 'react'
import _isEmpty from 'lodash/isEmpty'
import { useDispatch } from 'react-redux'
import { StatusBar } from 'expo-status-bar'
import {
  ScrollView,
  TouchableOpacity,
  KeyboardAvoidingView,
  Image,
} from 'react-native'
import {
  Text,
  TextField,
  View,
  Button,
} from 'react-native-ui-lib'

import { authActions } from '../../redux/actions/auth'
import styles from './styles'

export default function ({ navigation }) {
	const dispatch = useDispatch()
  const [username, setUsername] = useState('')
  const [password, setPassword] = useState('')
  const [loading, setLoading] = useState(false)

  const login = () => {
    setLoading(true)
    const data = {
      login: username,
      password,
    }

		dispatch(authActions.loginAsync(data, err => {
      setLoading(false)
      if (err) {
        setPassword('')
      } else {
        navigation.navigate('Main')
      }
    }))
  }

  return (
    <KeyboardAvoidingView behavior="height" enabled style={styles.keyboardView}>
      <StatusBar style="auto" translucent backgroundColor="#f7f7f7" />
        <ScrollView contentContainerStyle={styles.container}>
          <View style={styles.imageContainer}>
            <Image
              resizeMode="contain"
              style={styles.image}
              source={require('../../assets/login.png')}
            />
          </View>
          <View style={styles.form}>
            <Text style={styles.formHeader} uppercase>
              Sign in
						</Text>
            <TextField
              title="Username"
              containerStyle={styles.mt10}
              placeholder="you@example.com"
              value={username}
              autoCapitalize="none"
              autoCompleteType="off"
              autoCorrect={false}
              keyboardType="email-address"
              onChangeText={setUsername}
            />

            <TextField
              title="Password"
              containerStyle={styles.mt10}
              placeholder="your secure password"
              value={password}
              autoCapitalize="none"
              autoCompleteType="off"
              autoCorrect={false}
              secureTextEntry={true}
              onChangeText={setPassword}
            />
            <Button
              label={loading ? 'Loading...' : 'Continue'}
              disabled={loading || _isEmpty(username) || _isEmpty(password)}
              style={styles.actionButton}
              onPress={login}
              backgroundColor="#3366ff"
              enableShadow
            />

            <View style={styles.secondaryContainer}>
              <Text>Don't have an account?</Text>
              <TouchableOpacity onPress={() => navigation.navigate('Auth.Signup')}>
                <Text style={{...styles.bottomText, ...styles.link}}>
                  Register here
								</Text>
              </TouchableOpacity>
            </View>
            <View style={styles.tertiaryContainer}>
              <TouchableOpacity onPress={() => navigation.navigate('Auth.ForgotPassword')}>
                <Text style={styles.link}>
                  Forgot password
								</Text>
              </TouchableOpacity>
            </View>
            <View style={styles.secondaryContainer}>
              <TouchableOpacity onPress={() => navigation.navigate('Main')}>
                <Text style={styles.link}>
                  Continue as an Anonymous
								</Text>
              </TouchableOpacity>
            </View>
          </View>
        </ScrollView>
    </KeyboardAvoidingView>
  )
}
