import axios, { AxiosPromise, AxiosRequestConfig, Method } from 'axios';
export default class BaseApi {
    constructor(private controller: string) { }

    public request<T>(method: Method, action = '', data?: any, params?: URLSearchParams, headers?: any): AxiosPromise<T> {
        const baseURL = process.env.VUE_APP_API_URL;
        const { searchParams, href: url } = new URL(action, this.controller);
        params?.forEach((value: string, key: string) => searchParams.set(key, value));

        return axios({ baseURL, url, method, data, params, headers });
    }
}
