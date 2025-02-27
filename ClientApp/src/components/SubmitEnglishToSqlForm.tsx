import {FC, useState} from "react";
import {Button, Checkbox, GroupBox, Select, TextInput, Window, WindowContent} from "react95";
import {AiServiceSelection} from "../models/enums/AiServiceSelection.ts";
import {SchemaSelection} from "../models/enums/SchemaSelection.ts";
import {useEnglishToSqlMutation} from "../data/hooks/useEngilshToSqlQuery.ts";
import {LoadingBar} from "./global/LoadingBar.tsx";
import {SubmitEnglishToSqlResults} from "./SubmitEnglishToSqlResults.tsx";
import {IEnglishToSqlDto} from "../models/IEnglishToSqlDto.ts";
import {DynamicRow, useValidateAndExecuteSqlMutation} from "../data/hooks/useExecuteSqlQuery.ts";
import {ExecutedSqlResults} from "./ExecutedSqlResults.tsx";


export const SubmitEnglishToSqlForm: FC = () => {
    const [serviceSelected, setServiceSelected] = useState<AiServiceSelection>(AiServiceSelection.AZURE_OPENAI_GPT4o_MINI);
    const [schemaSelected, setSchemeSelected] = useState<SchemaSelection>(SchemaSelection.SIMPLE_SCHEMA);
    const [userQuery, setUserQuery] = useState<string>('');
    const [formResults, setFormResults] = useState<IEnglishToSqlDto>();
    const [executeResults, setExecuteResults] = useState<DynamicRow[]>();
    const [skipReviewAndExecute, setSkipReviewAndExecute] = useState<boolean>(false);

    const submitEnglishToSqlMutation = useEnglishToSqlMutation();
    const validateAndExecuteSqlMutation = useValidateAndExecuteSqlMutation();
    
    const restart = () => {
        setServiceSelected(AiServiceSelection.AZURE_OPENAI_GPT4o_MINI);
        setSchemeSelected(SchemaSelection.SIMPLE_SCHEMA);
        setUserQuery('');
        setFormResults(undefined);
        setExecuteResults(undefined);
    }

    return <>
        {(submitEnglishToSqlMutation.isPending || validateAndExecuteSqlMutation.isPending) && <LoadingBar/>}
        {(!formResults && !executeResults) && <Window style={{width: 600, height: 500}}>
            <WindowContent>
                <GroupBox label='English Query'>
                    <TextInput
                        multiline
                        rows={12}
                        placeholder={"Please enter your request..."}
                        fullWidth
                        onChange={e => setUserQuery(e.target.value)}
                    />
                </GroupBox>
                <br/>
                <GroupBox label='Setup'>
                    <div style={{display: 'flex', alignItems: 'center', justifyContent: 'space-between'}}>
                        <div style={{display: 'flex', flexDirection: 'column', gap: '10px'}}>
                            <Select
                                defaultValue={1}
                                options={[
                                    {
                                        label: 'Azure OpenAi Gpt 4o-Mini',
                                        value: AiServiceSelection.AZURE_OPENAI_GPT4o_MINI
                                    },
                                    {label: 'LocallyHosted (WIP)', value: AiServiceSelection.LOCALLY_HOSTED}
                                ]}
                                menuMaxHeight={160}
                                width={250}
                                onChange={e => {
                                    setServiceSelected(e.value);
                                }}
                                onOpen={e => console.log('open', e)}
                                onClose={e => console.log('close', e)}
                                onBlur={e => console.log('blur', e)}
                                onFocus={e => console.log('focus', e)}
                            />
                            <Select
                                defaultValue={1}
                                options={[
                                    {label: 'Simple Schema', value: SchemaSelection.SIMPLE_SCHEMA},
                                    {label: 'Complex Schema (WIP)', value: SchemaSelection.COMPLEX_SCHEMA},
                                    {label: 'Custom Schema(WIP)', value: SchemaSelection.CUSTOM_SCHEMA}
                                ]}
                                menuMaxHeight={160}
                                width={250}
                                onChange={e => {
                                    setSchemeSelected(e.value);
                                }}
                                onOpen={e => console.log('open', e)}
                                onClose={e => console.log('close', e)}
                                onBlur={e => console.log('blur', e)}
                                onFocus={e => console.log('focus', e)}
                            />
                        </div>
                        <Button
                            style={{width: 150, height: 50}}
                            primary
                            onClick={async () => {
                                if (!!schemaSelected && !!serviceSelected) {
                                    if(!skipReviewAndExecute) {
                                        const formResult = await submitEnglishToSqlMutation.mutateAsync({
                                            schemaSelection: schemaSelected,
                                            aiServiceSelection: serviceSelected,
                                            userQuery: userQuery
                                        });
                                        setFormResults(formResult.data);
                                    }
                                    else {
                                        const executeResult = await validateAndExecuteSqlMutation.mutateAsync({
                                            schemaSelection: schemaSelected,
                                            aiServiceSelection: serviceSelected,
                                            userQuery: userQuery
                                        });
                                        
                                        setExecuteResults(executeResult.data)
                                    }
                                    
                                }
                            }}
                            disabled={!userQuery || submitEnglishToSqlMutation.isPending || validateAndExecuteSqlMutation.isPending}
                        >
                            Submit
                        </Button>
                    </div>
                </GroupBox>
                <div style={{display: "flex", justifyContent: "flex-end", marginTop: "auto", padding: "10px"}}>
                    <Checkbox checked={skipReviewAndExecute} onChange={() => setSkipReviewAndExecute(!skipReviewAndExecute)} label="Skip review and execute"/>
                </div>
            </WindowContent>
        </Window>}
        {!!formResults && <SubmitEnglishToSqlResults
            response={formResults.response}
            timeTaken={formResults.timeTaken}
            tokenCost={formResults.tokenCost}
            success={formResults.success}
            validationMessage={formResults.validationMessage}
            restart={restart}
        />}
        {!!executeResults && <ExecutedSqlResults 
            data={executeResults} 
            restart={restart}
        />}
    </>;
}