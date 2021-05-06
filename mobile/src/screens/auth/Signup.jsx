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

  async function register() {
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
            source={require('../../assets/register.png')}
          />
        </View>
        <View style={styles.form}>
          <Text fontWeight="bold" size="h3" style={styles.formHeader}>
            Sign up
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
            onChangeText={(text) => setEmail(text)}
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
            onChangeText={(text) => setPassword(text)}
          />
          <Button
            title={loading ? 'Loading...' : 'Sign up'}
            onPress={register}
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
