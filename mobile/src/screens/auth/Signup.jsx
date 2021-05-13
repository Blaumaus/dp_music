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
          <Text style={styles.formHeader} uppercase>
            Sign up
					</Text>
          <TextField
            containerStyle={styles.mt10}
            placeholder="you@example.com"
            value={email}
            autoCapitalize="none"
            autoCompleteType="off"
            autoCorrect={false}
            keyboardType="email-address"
            onChangeText={(text) => setEmail(text)}
          />

          <TextField
            containerStyle={styles.mt10}
            placeholder="your password"
            value={password}
            autoCapitalize="none"
            autoCompleteType="off"
            autoCorrect={false}
            secureTextEntry={true}
            onChangeText={(text) => setPassword(text)}
          />
          <Button
            label={loading ? 'Loading...' : 'Sign up'}
            disabled={loading}
            style={styles.actionButton}
            onPress={register}
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
