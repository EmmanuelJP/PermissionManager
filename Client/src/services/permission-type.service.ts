import PermissionType from '@/models/permission-type.model';
import BaseSerivce from '../core/http-clients/service.base';
import ApiClient from '../core/http-clients/api.base';

export class PermissionTypeService extends BaseSerivce<PermissionType>{
    constructor() {
        super(new ApiClient('PermissionTypes'));
    }
}

export default new PermissionTypeService();