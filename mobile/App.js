import { StatusBar } from 'expo-status-bar'
import * as Localisation from 'expo-localization'
import React from 'react'
import { Provider, useSelector } from 'react-redux'
import { SafeAreaView } from 'react-native'
import i18next from 'i18next'
import { I18nextProvider, initReactI18next } from 'react-i18next'
import _includes from 'lodash/includes'

import SplashInitialisation from './src/screens/common/SplashInitialisation'
import Toast from './src/components/common/Toast'
import { store } from './src/redux/store'
import constants, { languages as whitelist } from './src/redux/constants'
import AppNavigator from './src/navigation/AppNavigator'
import { get, set } from './src/utils/storage'

import en from './src/i18n/en.json'
import uk from './src/i18n/uk.json'
import ru from './src/i18n/ru.json'

const languageDetector = {
  type: 'languageDetector',
  async: true,
  init: (_services, _detectorOptions, _i18nextOptions) => {
    /* use services and options */
  },
  detect: callback => {
    Localisation.getLocalizationAsync()
      .then(({ locale }) => {
        const lang = locale.substr(0, 2)

        get(constants.APP_LANGUAGE)
          .then(res => {
            if (!res) {
              console.log('No language is set, choosing the best available or English as fallback')
              const bestLng = _includes(whitelist, lang) ? lang : 'uk'
      
              callback(bestLng)
              return
            }
            callback(res)
          })
          .catch(e => {
            console.error('Error fetching APP_LANGUAGE from async store', e)
            const bestLng = _includes(whitelist, lang) ? lang : 'uk'

            callback(bestLng)
          })
      })
  },
  cacheUserLanguage: lng => {
    set(constants.APP_LANGUAGE, lng)
  },
};


i18next
  .use(languageDetector)
  .use(initReactI18next)
	.init({
		interpolation: {
			escapeValue: false,
		},
		whitelist,
		resources: {
			en: { common: en },
			ru: { common: ru },
			uk: { common: uk },
		},
    react: {
      useSuspense: false,
    }
	})

const EStatusBar = () => {
  const theme = useSelector(state => state.themeReducer?.theme)

  return (
    <StatusBar
      backgroundColor={theme === 'dark' ? constants.BACKGROUND_DARK : constants.BACKGROUND_LIGHT}
      style={theme === 'dark' ? 'light' : 'dark'}
      translucent
    />
  )
}

export default () => (
  <Provider store={store}>
    <I18nextProvider i18n={i18next}>
      <SplashInitialisation>
        <SafeAreaView style={{ flex: 1 }}>
          <EStatusBar />
          <AppNavigator />
          <Toast />
        </SafeAreaView>
      </SplashInitialisation>
    </I18nextProvider>
  </Provider>
)
