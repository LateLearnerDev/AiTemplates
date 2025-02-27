import {FC} from "react";
import {
    Button, GroupBox,
    Window,
    WindowContent,
    WindowHeader
} from "react95";
import {DynamicRow} from "../data/hooks/useExecuteSqlQuery.ts";
import {DynamicRowTable} from "./global/DynamicRowTable.tsx";

interface ITableProps {
    data: DynamicRow[],
    restart: () => void;
}

export const ExecutedSqlResults: FC<ITableProps> = (props) => {
    if (props.data.length === 0) return <>
        <Window style={{ width: "80%", margin: "20px auto" }}>
            <WindowHeader active>
                <span role="img" aria-label="database">📊</span> Query Results
            </WindowHeader>
            <WindowContent>
                Query returned no results
            </WindowContent>
        </Window>
    </>;

    return <>
        <Window style={{ paddingBottom: "10px", display: "flex", flexDirection: "column" }}>
            <WindowHeader active>
                <span role="img" aria-label="database">📊</span> Query Results
            </WindowHeader>
            <WindowContent style={{ flex: 1, display: "flex", flexDirection: "column", gap: "10px" }}>
                <GroupBox>
                    <div style={{ display: "flex", flexDirection: "column", gap: "10px" }}>
                        <DynamicRowTable data={props.data} />
                    </div>
                </GroupBox>
                <div style={{ display: "flex", justifyContent: "flex-end", marginTop: "10px" }}>
                    <Button
                        style={{ height: 40, width: 100 }}
                        onClick={props.restart}
                    >
                        Restart
                    </Button>
                </div>
            </WindowContent>
        </Window>
    </>;
}