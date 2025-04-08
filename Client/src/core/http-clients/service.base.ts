import { EntityValidationResult } from '../models/entity-validation.result.model';
import ApiClient from './api.base';
import HTTP_METHODS from '../utils/http-methods';
const EMPTY = '';
export default class BaseService<T> {
    constructor(public baseApi: ApiClient) { }

    public async getById(id: number): Promise<T> {
        const { data } = await this.baseApi.request<T>(HTTP_METHODS.GET, id.toString());
        return data;
    }
    public async get(): Promise<T[]> {
        const { data } = await this.baseApi.request<T[]>(HTTP_METHODS.GET, EMPTY);
        return data;
    }
    public async add(entity: T): Promise<T> {
        const { data } = await this.baseApi.request<EntityValidationResult<T>>(HTTP_METHODS.POST, EMPTY, entity);
        return data.data;
    }
    public async update(id: number, entity: T): Promise<T> {
        const { data } = await this.baseApi.request<EntityValidationResult<T>>(HTTP_METHODS.PUT, id.toString(), entity);
        return data.data;
    }
    public async delete(id: Number): Promise<T> {
        const { data } = await this.baseApi.request<T>(HTTP_METHODS.DETELE, id.toString());
        return data;
    }
}
