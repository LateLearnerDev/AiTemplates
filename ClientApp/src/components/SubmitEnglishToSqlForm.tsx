import {FC, useEffect, useState} from "react";
import {Button, GroupBox, Select, TextInput, Window, WindowContent} from "react95";
import {AiServiceSelection} from "../models/enums/AiServiceSelection.ts";
import {SchemaSelection} from "../models/enums/SchemaSelection.ts";
import {useEnglishToSqlMutation} from "../data/hooks/useEngilshToSqlQuery.ts";


export const SubmitEnglishToSqlForm: FC = () => {
    const [serviceSelected, setServiceSelected] = useState<AiServiceSelection>();
    const [schemaSelected, setSchemeSelecteed] = useState<SchemaSelection>();
    const [userQuery, setUserQuery] = useState<string>('');

    const submitEnglishToSqlMutation = useEnglishToSqlMutation();

    useEffect(() => {
        console.log(userQuery);
    }, [userQuery])

    useEffect(() => {
        console.log({"SCHEMA SELECTED: ": schemaSelected});
    }, [schemaSelected]);
    
    return <>
        <Window style={{width: 600, height: 500}}>
            <WindowContent>
                <GroupBox label='English Query'>
                    <TextInput
                        multiline
                        rows={12}
                        defaultValue={"Please enter your request..."}
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
                                    {label: 'Azure OpenAi Gpt 4o-Mini', value: AiServiceSelection.AZURE_OPENAI_GPT4o_MINI},
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
                                    setSchemeSelecteed(e.value);
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
                            onClick={() => (!!schemaSelected && !!serviceSelected) && submitEnglishToSqlMutation.mutate({
                                schemaSelection: schemaSelected,
                                aiServiceSelection: serviceSelected,
                                userQuery: userQuery
                            })}
                        >
                            Submit
                        </Button>
                    </div>
                </GroupBox>
                {/*<GroupBox label='Disabled' disabled>*/}
                {/*    Some content here*/}
                {/*    <span role='img' aria-label='😍'>*/}
                {/*        😍*/}
                {/*    </span>*/}
                {/*</GroupBox>*/}
            </WindowContent>
        </Window>
    </>;
}