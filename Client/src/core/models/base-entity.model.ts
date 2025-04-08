export default class BaseEntity {
    id?: number | null;
    deleted: boolean;
    createdDate?: Date;
    updatedDate?: Date;
    constructor() {
        this.id = undefined;
        this.deleted = false;
    }
}