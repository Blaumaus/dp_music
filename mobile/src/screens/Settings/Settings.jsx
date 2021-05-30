import React, { memo } from 'react'
import { ScrollView, StyleSheet, Dimensions } from 'react-native'
import { Flag } from 'react-native-svg-flagkit'
import _map from 'lodash/map'
import { Picker, Text, View, Colors, Assets, Image, Checkbox } from 'react-native-ui-lib'
import { useTranslation } from 'react-i18next'
import i18next from 'i18next'

import constants, { whitelist } from '../../redux/constants'

const flagICOs = {
  'ru': 'RU',
  'en': 'GB',
  'uk': 'UA',
}


const getStyles = theme => StyleSheet.create({
  container: {
    minHeight: Dimensions.get('window').height,
    backgroundColor: theme === 'dark' ? constants.BACKGROUND_DARK : constants.BACKGROUND_LIGHT,
    paddingTop: 40,
    paddingLeft: 20,
    paddingRight: 20,
  },
  text: {
    color: theme === 'dark' ? constants.TEXT_LIGHT : constants.TEXT_DARK,
    fontSize: 16,
  },
  pickerItemContainer: {
    height: 56,
    borderBottomWidth: 1,
    borderColor: Colors.dark80,
  }
})

const Settings = ({ theme, onThemeChange }) => {
  const { t, i18n: { language } } = useTranslation('common')
  const styles = getStyles(theme)

  const onLanguageChange = (lngCode) => {
    i18next.changeLanguage(lngCode)
  }

  return (
    <ScrollView contentContainerStyle={styles.container}>
      <View>
        <Picker
          placeholder={t('languages.selectLanguage')}
          value={language}
          onChange={({ value }) => onLanguageChange(value)}
          topBarProps={{ title: t('languages.pickerTitle') }}
          searchPlaceholder={t('languages.searchLanguage')}
          floatingPlaceholder
          showSearch
        >
          {_map(whitelist, option => (
            <Picker.Item key={option} value={option} renderItem={(item, props) => (
              <View style={styles.pickerItemContainer} paddingH-15 row centerV spread>
                <View row centerV>
                  <Flag id={flagICOs[item]} width={45} height={24} />
                  <Text marginL-10 text70 dark10>
                    {t(`languages.${item}`)}
                  </Text>
                </View>
                {props.isSelected && <Image source={Assets.icons.check} />}
              </View>
            )}
              label={t(`languages.${option}`)}
            />
          ))}
        </Picker>
      </View>
      <View>
        <Checkbox
          value={theme === 'dark'}
          label={t('settings.darkTheme')}
          color='#3366ff'
          onValueChange={theme => onThemeChange(theme ? 'dark' : 'light')}
          labelStyle={styles.text}
        />
      </View>
    </ScrollView>
  )
}

export default memo(Settings)
