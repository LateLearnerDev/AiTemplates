import {AiServiceSelection} from "./enums/AiServiceSelection.ts";
import {SchemaSelection} from "./enums/SchemaSelection.ts";

export interface ISubmitEnglishToSqlRequest {
    AiServiceSelection: AiServiceSelection,
    SchemaSelection: SchemaSelection,
    UserQuery: string,
    CustomSchema?: string 
}