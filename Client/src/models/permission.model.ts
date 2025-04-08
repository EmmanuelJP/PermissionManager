import BaseEntity from '@/core/models/base-entity.model';

export default class Permission extends BaseEntity {
    employeeFirstName = '';
    employeeLastName = '';
    permissionDate = new Date();
    permissionTypeId?: number | null = null;
    permissionTypeDescription = '';
}