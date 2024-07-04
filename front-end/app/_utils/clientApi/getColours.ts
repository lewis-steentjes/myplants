
import axios from "axios";

const rootURL = process.env.NEXT_PUBLIC_MY_SERVER_URL;

export async function getRed() {
  try {
    const response = (await axios({url: `${rootURL}/red`}));
    return response.data
  } catch (error) {
    console.error('Error fetching data: ', error)
    return (`uh oh ${error}`)
  }
}

export async function getGreen() {
  try {
    const response = (await axios({url: `${rootURL}/green`}));
    return response.data
  } catch (error) {
    console.error('Error fetching data: ', error)
    return (`uh oh ${error}`)
  }
}

export async function getBlue() {
  try {
    const response = (await axios({url: `${rootURL}/blue`}));
    return response.data
  } catch (error) {
    console.error('Error fetching data: ', error)
    return (`uh oh ${error}`)
  }
}