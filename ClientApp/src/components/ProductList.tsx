import {FC, useEffect} from "react";
import {useProductQuery} from "../data/hooks/useProductsQuery.ts";

const ProductList: FC = () => {
    const {data: products, isLoading, error} = useProductQuery();
    
    useEffect(() => {
        console.log(import.meta.env.VITE_REACT_APP_API_URL);
    }, []);

    useEffect(() => {
        console.log({data: products})
    }, [products]);
    
    if (isLoading) return <p>Loading...</p>;
    if (error) return <p>Error loading products: {error.message}</p>;

    return (
        <ul>
            {products?.map(product => (
                <li key={product.Id}>
                    {product.Name} - ${product.Price}
                </li>
            ))}
        </ul>
    );
};

export default ProductList;