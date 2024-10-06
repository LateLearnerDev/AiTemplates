import axios from 'axios';
import {useQuery} from "@tanstack/react-query";
import {IProduct} from "../models/IProduct.ts";
import {useEffect} from "react";

// Trying to access environment variables 
const apiBaseUrl = import.meta.env.VITE_REACT_APP_API_URL;

const fetchProducts = async () => {
    const response = await axios.get<IProduct[]>(`${apiBaseUrl}/api/product`);
    return response.data;
};

const ProductList = () => {
    const { data: products, error, isLoading } = useQuery({queryKey: ["products"], queryFn: fetchProducts});

    useEffect(() => {
        console.log(import.meta.env.VITE_REACT_APP_API_URL);
    }, []);
    
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