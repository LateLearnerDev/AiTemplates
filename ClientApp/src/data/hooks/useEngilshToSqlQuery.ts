import axios from "axios";
import {API_URL} from "../../constants/appData.ts";
import {useMutation, useQueryClient} from "@tanstack/react-query";
import {ISubmitEnglishToSqlRequest} from "../../models/ISubmitEnglishToSqlRequest.ts";

export const englishToSqlKeys = {
    all: ["englishToSql"] as const
};

const submitEnglishToSql = async (request: ISubmitEnglishToSqlRequest) => {
    return await axios.post<string>(`${API_URL}/AiTemplates`, request);
}

export const useEnglishToSqlMutation = () => {
    const queryClient = useQueryClient();

    return useMutation({
        mutationFn: submitEnglishToSql,
        onSuccess: () => {
            queryClient.invalidateQueries({queryKey: englishToSqlKeys.all});
        },
    });
};