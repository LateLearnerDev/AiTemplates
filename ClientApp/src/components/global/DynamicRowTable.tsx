import {FC} from "react";
import {DynamicRow} from "../../data/hooks/useExecuteSqlQuery.ts";
import {
    Window, WindowContent, WindowHeader, Table as React95Table, TableHead, TableRow, TableBody, TableHeadCell,
    TableDataCell
} from "react95";

interface ITableProps {
    data: DynamicRow[]
}

export const DynamicRowTable: FC<ITableProps> = (props) => {
    if (props.data.length === 0) return <>
        <Window style={{width: "80%", margin: "20px auto"}}>
            <WindowHeader active>
                <span role="img" aria-label="database">📊</span> Query Results
            </WindowHeader>
            <WindowContent>
                Query returned no results
            </WindowContent>
        </Window>
    </>;

    const headers = Object.keys(props.data[0]);

    return <>
        <React95Table>
            <TableHead>
                <TableRow>
                    {headers.map((header) => (
                        <TableHeadCell key={header}>
                            {header}
                        </TableHeadCell>
                    ))}
                </TableRow>
            </TableHead>
            <TableBody>
                {props.data.map((row, rowIndex) => (
                    <TableRow key={rowIndex}>
                        {headers.map((header) => (
                            <TableDataCell key={header}>{String(row[header])}</TableDataCell>
                        ))}
                    </TableRow>
                ))}
            </TableBody>
        </React95Table>
    </>
}