

import axios from "axios";

const rootURL = process.env.NEXT_PUBLIC_MY_SERVER_URL;

export async function getDouble(valueToDouble: number) {
  try {
    const response = (await axios({url: `${rootURL}/double?num=${valueToDouble}`}));
    return response.data
  } catch (error) {
    console.error('Error fetching data: ', error)
    return (`uh oh ${error}`)
  }
}
