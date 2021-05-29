import React, { memo, useEffect, useCallback } from 'react'
import PropTypes from 'prop-types'
import constants from '../../../redux/constants'
import { get } from '../../../utils/storage'
import LoadingScreen from '../../common/Loading'

// Loading data from async storage and saving it into the redux state via initialise action
const SplashInitialisation = ({ children, initialised, initialise }) => {
  const load = useCallback(async () => {
    const token = (await get(constants.TOKEN)) || null
    initialise({ token })
  }, [])

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
