import { FC, useEffect, useState } from 'react';
import { Window, WindowHeader, WindowContent, ProgressBar } from 'react95';

interface ILoadingBarProps {
    loadingText?: string;
}

export const LoadingBar: FC<ILoadingBarProps> = (props) => {
    const [percent, setPercent] = useState<number>(0);

    useEffect(() => {
        const timer = setInterval(() => {
            setPercent(previousPercent => {
                if (previousPercent === 100) return 0;
                const diff = Math.random() * 10;
                return Math.min(previousPercent + diff, 100);
            });
        }, 500);

        return () => clearInterval(timer);
    }, []);

    return (
        <div
            style={{
                position: 'fixed',
                top: '50%',
                left: '50%',
                transform: 'translate(-50%, -50%)',
                zIndex: 9999, 
                padding: '20px',
                borderRadius: '10px'
            }}
        >
            <Window resizable className='window'>
                <WindowHeader className='window-title'>
                    <span>{props.loadingText ?? "Loading"}...</span>
                </WindowHeader>
                <WindowContent>
                    <ProgressBar style={{ height: 30, width: 400 }} variant='tile' value={Math.floor(percent)} />
                </WindowContent>
            </Window>
        </div>
    );
};
