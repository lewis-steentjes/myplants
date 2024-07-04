

import axios from "axios";

const rootURL = "/";

export default async function getRed() {
  try {
    const response = (await axios({url: "http://127.0.0.1:5110/"}));
    return response.data
  } catch (error) {
    console.error('Error fetching data: ', error)
    return (`uh oh ${error}`)
  }
}