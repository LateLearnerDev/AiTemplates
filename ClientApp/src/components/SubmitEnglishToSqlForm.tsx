import {FC, useCallback, useState} from "react";
import {Button, Checkbox, GroupBox, Select, TextInput, Window, WindowContent, WindowHeader} from "react95";
import {AiServiceSelection} from "../models/enums/AiServiceSelection.ts";
import {SchemaSelection} from "../models/enums/SchemaSelection.ts";
import {LoadingBar} from "./global/LoadingBar.tsx";
import {SubmitEnglishToSqlResults} from "./SubmitEnglishToSqlResults.tsx";
import {IEnglishToSqlDto} from "../models/IEnglishToSqlDto.ts";
import {DynamicRow, useExecuteSqlMutation} from "../data/hooks/useExecuteSqlQuery.ts";
import {ExecutedSqlResults} from "./ExecutedSqlResults.tsx";
import {useValidateEnglishToSqlMutation} from "../data/hooks/useValidateEngilshToSqlQuery.ts";


export const SubmitEnglishToSqlForm: FC = () => {
    const [serviceSelected, setServiceSelected] = useState<AiServiceSelection>(AiServiceSelection.AZURE_OPENAI_GPT4o_MINI);
    const [schemaSelected, setSchemeSelected] = useState<SchemaSelection>(SchemaSelection.SIMPLE_SCHEMA);
    const [userQuery, setUserQuery] = useState<string>('');
    const [formResults, setValidationResults] = useState<IEnglishToSqlDto>();
    const [executeResults, setExecuteResults] = useState<DynamicRow[]>();
    const [skipReviewAndExecute, setSkipReviewAndExecute] = useState<boolean>(false);

    const submitEnglishToSqlMutation = useValidateEnglishToSqlMutation();
    const executeSqlMutation = useExecuteSqlMutation();

    const restart = useCallback(() => {
        setServiceSelected(AiServiceSelection.AZURE_OPENAI_GPT4o_MINI);
        setSchemeSelected(SchemaSelection.SIMPLE_SCHEMA);
        setUserQuery('');
        setValidationResults(undefined);
        setExecuteResults(undefined);
    }, []);

    const handleServiceChange = useCallback((value: number) => {
        setServiceSelected(value);
    }, []);

    const handleSchemaChange = useCallback((value: number) => {
        setSchemeSelected(value);
    }, []);

    const handleSkipReviewChange = useCallback(() => {
        setSkipReviewAndExecute(prev => !prev);
    }, []);

    const handleSubmit = useCallback(async () => {
        if (!!schemaSelected && !!serviceSelected) {
            if (!skipReviewAndExecute) {
                const validationResult = await submitEnglishToSqlMutation.mutateAsync({
                    schemaSelection: schemaSelected,
                    aiServiceSelection: serviceSelected,
                    userQuery: userQuery
                });
                setValidationResults(validationResult.data);
            } else {
                await submitEnglishToSqlMutation.mutateAsync({
                    schemaSelection: schemaSelected,
                    aiServiceSelection: serviceSelected,
                    userQuery: userQuery
                }, {
                    onSuccess: async validationResult => {
                        if (validationResult.data.success) {
                            const executionResult = await executeSqlMutation.mutateAsync({
                                sqlQuery: validationResult.data.response
                            });
                            setExecuteResults(executionResult.data);
                        } else {
                            setValidationResults(validationResult.data);
                        }
                    }
                });
            }
        }
    }, [executeSqlMutation, schemaSelected, serviceSelected, skipReviewAndExecute, submitEnglishToSqlMutation, userQuery]);

    return <>
        {(submitEnglishToSqlMutation.isPending || executeSqlMutation.isPending) && <LoadingBar/>}
        {(!formResults && !executeResults) &&
            <Window style={{width: 600, minHeight: 500}}>
                <WindowHeader>English To Sql</WindowHeader>
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
                                        handleServiceChange(e.value);
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
                                        handleSchemaChange(e.value);
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
                                onClick={handleSubmit}
                                disabled={!userQuery || submitEnglishToSqlMutation.isPending || executeSqlMutation.isPending}
                            >
                                Submit
                            </Button>
                        </div>
                    </GroupBox>
                    <div style={{display: "flex", justifyContent: "flex-end", marginTop: "auto", padding: "10px"}}>
                        <Checkbox checked={skipReviewAndExecute}
                                  onChange={handleSkipReviewChange}
                                  label="Skip review and execute"/>
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