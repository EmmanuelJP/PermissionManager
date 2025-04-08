export interface ValidationFailedModel {
    propertyName: string;
    errorCode: string;
    errorMessage: string;
    propertyValue: any;
    propertyText: string;
}