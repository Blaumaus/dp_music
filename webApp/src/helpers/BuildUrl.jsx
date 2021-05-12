import React from "react";
export default class BuildUrl {
    static getUrl(image) {

      return process.env.REACT_APP_STORAGE_URL.concat(image);
      
    }
  }