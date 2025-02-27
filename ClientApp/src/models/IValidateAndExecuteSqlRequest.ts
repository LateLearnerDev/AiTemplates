import {AiServiceSelection} from "./enums/AiServiceSelection.ts";
import {SchemaSelection} from "./enums/SchemaSelection.ts";

export interface IValidateAndExecuteSqlRequest {
    aiServiceSelection: AiServiceSelection,
    schemaSelection: SchemaSelection,
    userQuery: string,
}