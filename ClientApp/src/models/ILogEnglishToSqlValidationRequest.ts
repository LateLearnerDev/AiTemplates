
export interface ILogEnglishToSqlValidationRequest {
    UserRequest: string;
    AiResponse: string;
    Success: boolean;
    TokenCost: number;
    TimeTaken: number;
    ErrorMessage?: string;
    ErrorType?: string;
}