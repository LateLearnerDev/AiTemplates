import {FC, useState} from "react";
import {useAddProductMutation} from "../data/hooks/useProductsQuery.ts";

const AddProduct: FC = () => {
    const [name, setName] = useState('');
    const [price, setPrice] = useState<number>(0);

    const addProductMutation = useAddProductMutation();

    const handleAddProduct = () => {
        addProductMutation.mutate({ Name: name, Price: price });
        setName('');
        setPrice(0);
    };

    return (
        <div>
            <h2>Add Product</h2>
            <input
                type="text"
                placeholder="Name"
                value={name}
                onChange={(e) => setName(e.target.value)}
            />
            <input
                type="number"
                placeholder="Price"
                value={price}
                onChange={(e) => setPrice(parseFloat(e.target.value))}
            />
            <button onClick={handleAddProduct} disabled={addProductMutation.isPending}>
                Add Product
            </button>
            {addProductMutation.isError && <p>Error adding product: {addProductMutation.error?.message}</p>}
        </div>
    );
};

export default AddProduct;