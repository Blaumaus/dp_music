import React, { useState } from 'react'
import { useTranslation } from 'react-i18next'
import _isEmpty from 'lodash/isEmpty'
import _toString from 'lodash/toString'
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

import { validateUsername, validateEmail } from '../../../api'
import getStyles from '../styles'

export default function ({ navigation, register: _register, authorised, theme }) {
  const styles = getStyles(theme)
  const { t } = useTranslation('common')
  const [username, setUsername] = useState('')
  const [email, setEmail] = useState('')
  const [usernameError, setUsernameError] = useState('')
  const [emailError, setEmailError] = useState('')
  const [password, setPassword] = useState('')
  const [loading, setLoading] = useState(false)
  const [emailVerified, setEmailVerified] = useState(false)
  const [usernameVerified, setUsernameVerified] = useState(false)

  const register = () => {
    setLoading(true)
    const data = {
      userName: username,
      password,
      email
    }

    _register(data, err => {
      setLoading(false)
      setPassword('')
      if (!err) {
        setEmail('')
        setUsername('')
        setEmailVerified(false)
        setUsernameVerified(false)
        navigation.navigate('Auth.Signin')
      }
    })
  }

  const checkUsernameAvailability = () => {
    if (!_isEmpty(username)) {
      validateUsername(username)
        .then(({ data, errorMessage }) => {
          if (!data || errorMessage) {
            setUsernameError(t('auth.usernameTaken'))
            setUsernameVerified(false)
          } else {
            setUsernameError('')
            setUsernameVerified(true)
          }
        })
        .catch(e => {
          console.error('Error while checking username availability')
          console.error(e)
          setUsernameError(t('auth.usernameTaken'))
          setUsernameVerified(false)
        })
    }
  }

  const checkEmailAvailability = () => {
    if (!_isEmpty(email)) {
      validateEmail(email)
        .then(({ data, errorMessage }) => {
          if (!data || errorMessage) {
            setEmailError(t('auth.emailTaken'))
            setEmailVerified(false)
          } else {
            setEmailError('')
            setEmailVerified(true)
          }
        })
        .catch(e => {
          console.error('Error while checking email availability')
          console.error(e)
          setEmailError(t('auth.emailTaken'))
          setEmailVerified(false)
        })
    }
  }

  if (authorised) {
    navigation.navigate('Main')
    return <></>
  }

  return (
    <KeyboardAvoidingView behavior="height" enabled style={styles.keyboardView}>
      <ScrollView contentContainerStyle={styles.container}>
        <View style={styles.imageContainer}>
          <Image
            resizeMode="contain"
            style={styles.image}
            source={require('../../../assets/register.png')}
          />
        </View>
        <View style={styles.form}>
          <Text style={{ ...styles.formHeader, ...styles.text }} uppercase>
            {t('auth.signup')}
					</Text>
          <TextField
            title={t('auth.email')}
            error={emailError}
            containerStyle={styles.mt10}
            placeholder="you@example.com"
            value={email}
            autoCapitalize="none"
            autoCompleteType="off"
            autoCorrect={false}
            keyboardType="email-address"
            onChangeText={(text) => {
              setEmailError('')
              setEmail(text)
            }}
            onBlur={checkEmailAvailability}
          />
          <TextField
            title={t('auth.login')}
            error={usernameError}
            containerStyle={styles.mt10}
            placeholder="username74"
            value={username}
            autoCapitalize="none"
            autoCompleteType="off"
            autoCorrect={false}
            keyboardType="email-address"
            onChangeText={(text) => {
              setUsernameError('')
              setUsername(text)
            }}
            onBlur={checkUsernameAvailability}
          />
          <TextField
            title={t('auth.password')}
            containerStyle={styles.mt10}
            placeholder={t('auth.passwordPlaceholder')}
            value={password}
            autoCapitalize="none"
            autoCompleteType="off"
            autoCorrect={false}
            secureTextEntry={true}
            onChangeText={(text) => setPassword(text)}
          />
          <Button
            label={loading ? `${t('common.loading')}...` : t('common.continue')}
            disabled={!emailVerified || !usernameVerified || loading || _isEmpty(username) || _isEmpty(password) || _isEmpty(email)}
            style={styles.actionButton}
            onPress={register}
            backgroundColor="#3366ff"
            enableShadow
          />

          <View style={styles.secondaryContainer}>
            <Text style={styles.text}>{t('auth.haveAnAccount')}</Text>
            <TouchableOpacity onPress={() => navigation.navigate('Auth.Signin')}>
              <Text style={{...styles.bottomText, ...styles.link}}>
                {t('auth.loginHere')}
							</Text>
            </TouchableOpacity>
          </View>
        </View>
      </ScrollView>
    </KeyboardAvoidingView>
  )
}
