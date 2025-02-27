import {FC, useEffect, useState} from "react";
import {Button, GroupBox, TextInput, Window, WindowContent} from "react95";
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

export const SubmitEnglishToSqlResults: FC<ISubmitEnglishToSqlResultsProps> = (props) => {
    const [aiResponse, setAiResponse] = useState<string>(props.response);
    const [executedSqlResults, setExecutedSqlResults] = useState<DynamicRow[]>();
    
    const executeSqlMutation = useExecuteSqlMutation();

    useEffect(() => {
        console.log({props: props});
    }, [props]);

    useEffect(() => {
        console.log({results: executedSqlResults});
    }, [executedSqlResults]);

    return <>
        {executeSqlMutation.isPending && <LoadingBar loadingText={`Executing`}/>}
        {!executedSqlResults && <Window style={{width: 600, position: 'relative', paddingBottom: '50px'}}>
            <WindowContent>
                <GroupBox label='Results'>
                    <TextInput
                        multiline
                        rows={10}
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
                            <GroupBox>
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