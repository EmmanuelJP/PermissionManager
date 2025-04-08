import { ValidationFailedModel } from './validaton-failed.mode.';

export interface EntityValidationResult<T> {
    success: boolean;
    data: T;
    errors: ValidationFailedModel[];
}