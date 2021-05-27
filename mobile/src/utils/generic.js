import _split from 'lodash/split'
import _last from 'lodash/last'
import _map from 'lodash/map'
import _find from 'lodash/find'
import _head from 'lodash/head'

export const parseCookie = (key, data) => {
  return _last(_find(_map(_split(data, ';'), el => _split(el, '=')), el => _head(el) === key))
}
