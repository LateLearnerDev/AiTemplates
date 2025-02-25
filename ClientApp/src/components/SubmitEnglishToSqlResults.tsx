import {FC, useEffect, useState} from "react";
import {Button, GroupBox, TextInput, Window, WindowContent} from "react95";

interface ISubmitEnglishToSqlResultsProps {
    response: string;
    timeTaken: number;
    tokenCost: number;
    success: boolean;
    validationMessage: string;
    restart: () => void;
}

export const SubmitEnglishToSqlResults: FC<ISubmitEnglishToSqlResultsProps> = (props) => {
    const [response, setResponse] = useState<string>(props.response);

    useEffect(() => {
        console.log({props: props});
    }, [props]);
    
    return <>
        {<Window style={{ width: 600, position: 'relative', paddingBottom: '50px' }}>
            <WindowContent>
                <GroupBox label='Results'>
                    <TextInput
                        multiline
                        rows={10}
                        placeholder={"Ai Result"}
                        fullWidth
                        value={response}
                        onChange={() => setResponse(response)}
                    />
                </GroupBox>
                <br />
                <GroupBox label='Setup'>
                    <div style={{ display: 'flex', alignItems: 'center', justifyContent: 'space-between' }}>
                        <div style={{ display: 'flex', flexDirection: 'column', gap: '10px' }}>
                            <GroupBox>
                                <span style={{ fontWeight: 'bold' }}>Validation:</span>
                                <span style={{ color: props.success ? 'green' : 'red', fontWeight: 'bold' }}> {props.success ? ' SUCCESS!' : ' FAILURE!'}</span>
                            </GroupBox>
                            <GroupBox>
                                <span style={{ fontWeight: 'bold' }}>Time Taken:</span>
                                <span style={{ color: 'blue', fontWeight: 'bold' }}> {props.timeTaken}</span>
                            </GroupBox>
                            <GroupBox>
                                <span style={{ fontWeight: 'bold' }}>Tokens Used:</span>
                                <span style={{ color: 'blue', fontWeight: 'bold' }}> {props.tokenCost}</span>
                            </GroupBox>
                        </div>
                        <Button
                            style={{ height: 50, width: 150 }}
                            primary
                            onClick={() => console.log("execute")}
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
    </>;
}