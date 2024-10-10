import './App.css'
import {QueryClient, QueryClientProvider} from "@tanstack/react-query";
import ProductList from "./components/ProductList.tsx";
import AddProduct from "./components/AddProduct.tsx";

function App() {
    const queryClient = new QueryClient();
    // const [count, setCount] = useState(0);

    return (
        <QueryClientProvider client={queryClient}>
            {/*<div>*/}
            {/*    <a href="https://vitejs.dev" target="_blank">*/}
            {/*        <img src={viteLogo} className="logo" alt="Vite logo"/>*/}
            {/*    </a>*/}
            {/*    <a href="https://react.dev" target="_blank">*/}
            {/*        <img src={reactLogo} className="logo react" alt="React logo"/>*/}
            {/*    </a>*/}
            {/*</div>*/}
            {/*<h1>Vite + React</h1>*/}
            {/*<div className="card">*/}
            {/*    <button onClick={() => setCount((count) => count + 1)}>*/}
            {/*        count is {count}*/}
            {/*    </button>*/}
            {/*    <p>*/}
            {/*        Edit <code>src/App.tsx</code> and save to test HMR*/}
            {/*    </p>*/}
            {/*</div>*/}
            {/*<p className="read-the-docs">*/}
            {/*    Click on the Vite and React logos to learn more*/}
            {/*</p>*/}
            <div>
                <h1>Product List with React Query</h1>
                <ProductList/>
                <AddProduct/>
            </div>
        </QueryClientProvider>
    )
}

export default App
