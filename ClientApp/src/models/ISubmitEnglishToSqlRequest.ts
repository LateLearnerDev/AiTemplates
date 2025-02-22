import {AiServiceSelection} from "./enums/AiServiceSelection.ts";
import {SchemaSelection} from "./enums/SchemaSelection.ts";

export interface ISubmitEnglishToSqlRequest {
    aiServiceSelection: AiServiceSelection,
    schemaSelection: SchemaSelection,
    userQuery: string,
    customSchema?: string 
}