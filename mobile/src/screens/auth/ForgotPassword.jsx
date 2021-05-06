import React, { useState } from 'react'
import { StatusBar } from 'expo-status-bar'
import {
  ScrollView,
  TouchableOpacity,
  View,
  KeyboardAvoidingView,
  Image,
  TextInput,
  Button,
  Text,
} from 'react-native'
import styles from './styles'

export default function ({ navigation }) {
  const [email, setEmail] = useState('')
  const [loading, setLoading] = useState(false)

  async function forget() {
    setLoading(true)
    // TODO
  }
  return (
    <KeyboardAvoidingView behavior="height" enabled style={styles.keyboardView}>
      <StatusBar style="auto" translucent backgroundColor="#f7f7f7" />
      <ScrollView contentContainerStyle={styles.container}>
        <View style={styles.imageContainer}>
          <Image
            resizeMode="contain"
            style={styles.image}
            source={require('../../assets/forget.png')}
          />
        </View>
        <View style={styles.form}>
          <Text size="h3" fontWeight="bold" style={styles.formHeader}>
            Forget Password
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
          <Button
            title={loading ? 'Loading...' : 'Reset password'}
            onPress={forget}
            style={styles.actionButton}
            disabled={loading}
          />
          <View style={styles.secondaryContainer}>
            <Text size="md">Already have an account?</Text>
            <TouchableOpacity onPress={() => navigation.navigate('Auth.Signin')}>
              <Text size="md" fontWeight="bold" style={styles.bottomText}>
                Login here
								</Text>
            </TouchableOpacity>
          </View>
        </View>
      </ScrollView>
    </KeyboardAvoidingView>
  )
}
