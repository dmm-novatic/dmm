import axios from 'axios';
const baseDomain = 'http://api.dmm.novatic.vn'; // API for products
export const basePostUrl = 'http://api.dmm.novatic.vn'; // API for post
export const baseStoreURL = 'http://api.dmm.novatic.vn'; // API for vendor(store)

export const customHeaders = {
    Accept: 'application/json',
};

export const baseUrl = `${baseDomain}`;
const axiosInstance = axios.create({
    baseUrl,
    headers: customHeaders,
});
axiosInstance.interceptors.request.use(
    async (config) => {
        const idToken = localStorage.getItem('idTokenClaims');
        if (idToken) {
            config.headers.Authorization = `Bearer ${idToken}`;
        }
        return config;
    },
    (error) => {
        return Promise.reject(error);
    }
);
export default axiosInstance;

export const serializeQuery = (query) => {
    return Object.keys(query)
        .map(
            (key) =>
                `${encodeURIComponent(key)}=${encodeURIComponent(query[key])}`
        )
        .join('&');
};
