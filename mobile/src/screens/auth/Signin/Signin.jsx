import React, { useState } from 'react'
import _isEmpty from 'lodash/isEmpty'
import { useTranslation } from 'react-i18next'
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

import styles from '../styles'

export default function ({ navigation, login: _login, authorised }) {
  const { t } = useTranslation('common')
  const [username, setUsername] = useState('')
  const [password, setPassword] = useState('')
  const [loading, setLoading] = useState(false)

  const login = () => {
    setLoading(true)
    const data = {
      login: username,
      password,
    }

    _login(data, err => {
      setLoading(false)
      setPassword('')
      if (!err) {
        setUsername('')
        navigation.navigate('Main')
      }
    })
  }

  if (authorised) {
    navigation.navigate('Main')
    return <></>
  }

  return (
    <KeyboardAvoidingView behavior="height" enabled style={styles.keyboardView}>
      <StatusBar style="auto" translucent backgroundColor="#f7f7f7" />
      <ScrollView contentContainerStyle={styles.container}>
        <View style={styles.imageContainer}>
          <Image
            resizeMode="contain"
            style={styles.image}
            source={require('../../../assets/login.png')}
          />
        </View>
        <View style={styles.form}>
          <Text style={styles.formHeader} uppercase>
            {t('auth.signin')}
					</Text>
          <TextField
            title={t('auth.login')}
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
            title={t('auth.password')}
            containerStyle={styles.mt10}
            placeholder={t('auth.passwordPlaceholder')}
            value={password}
            autoCapitalize="none"
            autoCompleteType="off"
            autoCorrect={false}
            secureTextEntry={true}
            onChangeText={setPassword}
          />
          <Button
            label={loading ? `${t('common.loading')}...` : t('common.continue')}
            disabled={loading || _isEmpty(username) || _isEmpty(password)}
            style={styles.actionButton}
            onPress={login}
            backgroundColor="#3366ff"
            enableShadow
          />

          <View style={styles.secondaryContainer}>
            <Text>{t('auth.dontHaveAnAccount')}</Text>
            <TouchableOpacity onPress={() => navigation.navigate('Auth.Signup')}>
              <Text style={{ ...styles.bottomText, ...styles.link }}>
                {t('auth.registerHere')}
							</Text>
            </TouchableOpacity>
          </View>
          {/* <View style={styles.tertiaryContainer}>
            <TouchableOpacity onPress={() => navigation.navigate('Auth.ForgotPassword')}>
              <Text style={styles.link}>
                {t('auth.forgotPassword')}
							</Text>
            </TouchableOpacity>
          </View> */}
          <View style={styles.secondaryContainer}>
            <TouchableOpacity onPress={() => navigation.navigate('Main')}>
              <Text style={styles.link}>
                {t('auth.anonymousContinue')}
							</Text>
            </TouchableOpacity>
          </View>
        </View>
      </ScrollView>
    </KeyboardAvoidingView>
  )
}
