export default class SelectItem implements ISelectItem {
    constructor(public value?: number | string | null, public text: string = '') { }
}

export interface ISelectItem {
    value?: number | string | null;
    text: string
}