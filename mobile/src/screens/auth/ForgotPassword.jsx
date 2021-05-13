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
          <Text style={styles.formHeader} uppercase>
            Forgot Password
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
          <Button
            label={loading ? 'Loading...' : 'Reset password'}
            disabled={loading}
            style={styles.actionButton}
            onPress={forget}
            backgroundColor="#3366ff"
            enableShadow
          />
          <View style={styles.secondaryContainer}>
            <Text>Already have an account?</Text>
            <TouchableOpacity onPress={() => navigation.navigate('Auth.Signin')}>
              <Text style={{...styles.bottomText, ...styles.link}}>
                Login here
							</Text>
            </TouchableOpacity>
          </View>
        </View>
      </ScrollView>
    </KeyboardAvoidingView>
  )
}
