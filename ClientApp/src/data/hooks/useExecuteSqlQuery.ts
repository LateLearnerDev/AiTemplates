import axios from "axios";
import {API_URL} from "../../constants/appData.ts";
import {useMutation, useQueryClient} from "@tanstack/react-query";
import {IExecuteSqlRequest} from "../../models/IExecuteSqlRequest.ts";

export const executeSqlKeys = {
    all: ["executeSql"] as const
};

export type DynamicRow = {
    [key: string]: any;
}

const executeSql = async (request: IExecuteSqlRequest) => {
    return await axios.post<DynamicRow[]>(`${API_URL}/AiTemplates/ExecuteSql`, request);
}

export const useExecuteSqlMutation = () => {
    const queryClient = useQueryClient();

    return useMutation({
        mutationFn: executeSql,
        onSuccess: async () => {
            await queryClient.invalidateQueries({queryKey: executeSqlKeys.all});
        },
    });
};