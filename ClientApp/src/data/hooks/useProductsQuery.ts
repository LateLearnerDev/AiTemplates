import axios from "axios";
import {IProduct} from "../../models/IProduct.ts";
import {API_URL} from "../../constants/appData.ts";
import {useMutation, useQuery, useQueryClient} from "@tanstack/react-query";
import {IAddProductRequest} from "../../models/IAddProductRequest.ts";

export const productKeys = {
    all: ["products"] as const
};

const fetchProducts = async () => {
    const response = await axios.get<IProduct[]>(`${API_URL}/gyms`);
    return response.data;
};

export const useProductQuery = () => {
    return useQuery({    
        queryKey: productKeys.all, queryFn: fetchProducts
    });
};

const addProduct = async (product: IAddProductRequest) => {
    console.log({product: product});
    return await axios.post<string>(`${API_URL}/api/product`, product);
}

export const useAddProductMutation = () => {
    const queryClient = useQueryClient();
    
    return useMutation({
        mutationFn: addProduct,
        onSuccess: () => {
            queryClient.invalidateQueries({queryKey: productKeys.all});
        },
    });
};

