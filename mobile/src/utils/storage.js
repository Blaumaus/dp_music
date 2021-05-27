import * as SecureStore from 'expo-secure-store'

const set = async (key, value) => {
  await SecureStore.setItemAsync(key, value)
}

const get = async (key) => {
  return await SecureStore.getItemAsync(key)
}

export {
  set, get,
}
