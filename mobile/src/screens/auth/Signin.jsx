import React, { useState } from 'react'
import { StatusBar } from 'expo-status-bar'
import {
  ScrollView,
  TouchableOpacity,
  View,
  KeyboardAvoidingView,
  Image,
  Text,
  TextInput,
  Button,
} from 'react-native'
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
            <Text fontWeight="bold" style={styles.formHeader} size="h3">
              Sign in
						</Text>
            <Text>Email</Text>
            <TextInput
              containerStyle={styles.mt15}
              placeholder="you@example.com"
              value={email}
              autoCapitalize="none"
              autoCompleteType="off"
              autoCorrect={false}
              keyboardType="email-address"
              onChangeText={setEmail}
            />

            <Text style={styles.mt15}>Password</Text>
            <TextInput
              containerStyle={styles.mt15}
              placeholder="password"
              value={password}
              autoCapitalize="none"
              autoCompleteType="off"
              autoCorrect={false}
              secureTextEntry={true}
              onChangeText={setPassword}
            />
            <Button
              title={loading ? 'Loading...' : 'Continue'}
              onPress={login}
              style={styles.actionButton}
              disabled={loading}
            />

            <View style={styles.secondaryContainer}>
              <Text size="md">Don't have an account?</Text>
              <TouchableOpacity onPress={() => navigation.navigate('Auth.Signup')}>
                <Text size="md" fontWeight="bold" style={styles.bottomText}>
                  Register here
								</Text>
              </TouchableOpacity>
            </View>
            <View style={styles.tertiaryContainer}>
              <TouchableOpacity onPress={() => navigation.navigate('Auth.ForgotPassword')}>
                <Text size="md" fontWeight="bold">
                  Forgot password
								</Text>
              </TouchableOpacity>
            </View>
          </View>
        </ScrollView>
    </KeyboardAvoidingView>
  )
}
