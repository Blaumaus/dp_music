import React, { useState } from 'react'
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
import styles from './styles'

export default function ({ navigation }) {
  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')
  const [loading, setLoading] = useState(false)

  async function login() {
    setLoading(true)
    // TODO: Implement auth logic using Redux Saga patterns
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
              title="Email"
              containerStyle={styles.mt10}
              placeholder="you@example.com"
              value={email}
              autoCapitalize="none"
              autoCompleteType="off"
              autoCorrect={false}
              keyboardType="email-address"
              onChangeText={setEmail}
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
              disabled={loading}
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
          </View>
        </ScrollView>
    </KeyboardAvoidingView>
  )
}
