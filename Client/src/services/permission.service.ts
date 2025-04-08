import Permission from '@/models/permission.model';
import BaseSerivce from '../core/http-clients/service.base';
import ApiClient from '../core/http-clients/api.base';

export class PermissionService extends BaseSerivce<Permission> {
    constructor() { super(new ApiClient('Permissions')) }
}

export default new PermissionService();