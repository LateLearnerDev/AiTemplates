import './App.css'
import {QueryClient, QueryClientProvider} from "@tanstack/react-query";
import {
    styleReset,
} from 'react95';
import {createGlobalStyle, ThemeProvider} from 'styled-components';

import original from 'react95/dist/themes/original';

import ms_sans_serif from 'react95/dist/fonts/ms_sans_serif.woff2';
import ms_sans_serif_bold from 'react95/dist/fonts/ms_sans_serif_bold.woff2';
import {SubmitEnglishToSqlForm} from "./components/SubmitEnglishToSqlForm.tsx";

const GlobalStyles = createGlobalStyle`
    ${styleReset}

    @font-face {
        font-family: 'ms_sans_serif';
        src: url('${ms_sans_serif}') format('woff2');
        font-weight: 400;
        font-style: normal
    }

    @font-face {
        font-family: 'ms_sans_serif';
        src: url('${ms_sans_serif_bold}') format('woff2');
        font-weight: bold;
        font-style: normal
    }

    body, input, select, textarea {
        font-family: 'ms_sans_serif';
    }
`;


function App() {
    const queryClient = new QueryClient();
    
    return (
        <QueryClientProvider client={queryClient}>
            <GlobalStyles/>
            <ThemeProvider theme={original}>
                <SubmitEnglishToSqlForm/>
                
            </ThemeProvider>
        </QueryClientProvider>
    )
}

export default App
