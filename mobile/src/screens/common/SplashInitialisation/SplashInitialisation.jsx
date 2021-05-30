import React, { memo, useEffect, useCallback } from 'react'
import { Appearance, useColorScheme } from 'react-native'
import PropTypes from 'prop-types'
import constants from '../../../redux/constants'
import { get, set } from '../../../utils/storage'
import LoadingScreen from '../../common/Loading'

// Loading data from async storage and saving it into the redux state via initialise action
const SplashInitialisation = ({ children, initialised, initialise, onThemeChange }) => {
  const colourTheme = useColorScheme()

  const load = useCallback(async () => {
    const token = (await get(constants.TOKEN)) || null
    let theme = await get(constants.THEME)

    if (!theme) {
      theme = colourTheme || constants.DEFAULT_FALLBACK_THEME
      await set(constants.THEME, theme)
    }

    initialise({ token, theme })
  }, [])

  const colourThemeHandler = useCallback((theme) => {
    onThemeChange(theme)
  })

  useEffect(() => {
    Appearance.addChangeListener(colourThemeHandler)

    return () => {
      Appearance.removeChangeListener(colourThemeHandler)
    }
  }, [colourThemeHandler])

  useEffect(() => {
    load()
  }, [load])

  if (!initialised) {
    return <LoadingScreen />
  }

  return children
}

SplashInitialisation.propTypes = {
  children: PropTypes.oneOfType([
    PropTypes.node, PropTypes.arrayOf(PropTypes.node),
  ]).isRequired,
  initialised: PropTypes.bool.isRequired,
  initialise: PropTypes.func.isRequired,
}

export default memo(SplashInitialisation)
