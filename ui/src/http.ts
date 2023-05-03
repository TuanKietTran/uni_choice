import axios from 'axios';

const httpClient = axios.create({
  baseURL: import.meta.env.VITE_API_ENDPOINT,
})

export default httpClient
