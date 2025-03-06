import {FC, useEffect, useState} from "react";
import {Button, GroupBox, Tab, TabBody, Tabs, TextInput, Window, WindowContent, WindowHeader} from "react95";
import {DynamicRow, useExecuteSqlMutation} from "../data/hooks/useExecuteSqlQuery.ts";
import {LoadingBar} from "./global/LoadingBar.tsx";
import {ExecutedSqlResults} from "./ExecutedSqlResults.tsx";

interface ISubmitEnglishToSqlResultsProps {
    response: string;
    timeTaken: number;
    tokenCost: number;
    success: boolean;
    validationMessage: string;
    restart: () => void;
}

enum TabSelection
{
    MAIN = 1,
    VALIDATION_INFO = 2
}

export const SubmitEnglishToSqlResults: FC<ISubmitEnglishToSqlResultsProps> = (props) => {
    const [aiResponse, setAiResponse] = useState<string>(props.response);
    const [executedSqlResults, setExecutedSqlResults] = useState<DynamicRow[]>();
    const [selectedTab, setSelectedTab] = useState<TabSelection>(TabSelection.MAIN);

    const handleChange = (
        value: number
    ) => {
        setSelectedTab(value);
    };

    const executeSqlMutation = useExecuteSqlMutation();

    useEffect(() => {
        console.log({props: props});
    }, [props]);

    useEffect(() => {
        console.log({results: executedSqlResults});
    }, [executedSqlResults]);

    return <>
        {executeSqlMutation.isPending && <LoadingBar loadingText={`Executing`}/>}
        {!executedSqlResults &&
            <Window style={{width: 600, minHeight: 650, position: 'relative', paddingBottom: '50px'}}>
                <WindowHeader>Ai Response</WindowHeader>
                <WindowContent>
                    <Tabs value={selectedTab} onChange={handleChange}>
                        <Tab value={TabSelection.MAIN}>Main</Tab>
                        <Tab value={TabSelection.VALIDATION_INFO}>Validation Info</Tab>
                    </Tabs>
                    <TabBody style={{minHeight: 550}}>
                        {selectedTab === TabSelection.MAIN && <>
                            <GroupBox label='Results' style={{marginTop: 20}}>
                                <TextInput
                                    multiline
                                    rows={8}
                                    placeholder={"Ai Result"}
                                    fullWidth
                                    value={aiResponse}
                                    onChange={() => setAiResponse(aiResponse)}
                                />
                            </GroupBox>
                            <br/>
                            <GroupBox label='Setup'>
                                <div style={{display: 'flex', alignItems: 'center', justifyContent: 'space-between'}}>
                                    <div style={{display: 'flex', flexDirection: 'column', gap: '10px'}}>
                                        <GroupBox onClick={() => console.log("hi")}>
                                            <span style={{fontWeight: 'bold'}}>Validation:</span>
                                            <span style={{
                                                color: props.success ? 'green' : 'red',
                                                fontWeight: 'bold'
                                            }}> {props.success ? ' SUCCESS!' : ' FAILURE!'}</span>
                                        </GroupBox>
                                        <GroupBox>
                                            <span style={{fontWeight: 'bold'}}>Time Taken:</span>
                                            <span style={{color: 'blue', fontWeight: 'bold'}}> {props.timeTaken}</span>
                                        </GroupBox>
                                        <GroupBox>
                                            <span style={{fontWeight: 'bold'}}>Tokens Used:</span>
                                            <span style={{color: 'blue', fontWeight: 'bold'}}> {props.tokenCost}</span>
                                        </GroupBox>
                                    </div>
                                    <Button
                                        style={{height: 50, width: 150}}
                                        primary
                                        onClick={async () => {
                                            const result = await executeSqlMutation.mutateAsync({
                                                sqlQuery: props.response
                                            });

                                            setExecutedSqlResults(result.data);
                                        }}
                                        disabled={!props.success || executeSqlMutation.isPending}
                                    >
                                        Execute!
                                    </Button>
                                </div>
                            </GroupBox>
                        </>}
                        {selectedTab === TabSelection.VALIDATION_INFO && <>
                            <GroupBox label='Validation Info'>
                                <TextInput
                                    multiline
                                    rows={25}
                                    placeholder={"Validation Info"}
                                    fullWidth
                                    value={props.validationMessage}
                                    onChange={() => setAiResponse(aiResponse)}
                                />
                            </GroupBox>
                        </>}
                    </TabBody>
                </WindowContent>

                <Button
                    style={{
                        position: 'absolute',
                        right: '10px',
                        height: 40,
                        width: 100,
                        marginRight: 10
                    }}
                    onClick={props.restart}
                >
                    Restart
                </Button>
            </Window>}
        {!!executedSqlResults && <ExecutedSqlResults
            data={executedSqlResults}
            restart={() => {
                setExecutedSqlResults(undefined);
                props.restart();
            }}
        />}
    </>;
}