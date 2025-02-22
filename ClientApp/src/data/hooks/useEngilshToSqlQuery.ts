import axios from "axios";
import {API_URL} from "../../constants/appData.ts";
import {useMutation, useQueryClient} from "@tanstack/react-query";
import {ISubmitEnglishToSqlRequest} from "../../models/ISubmitEnglishToSqlRequest.ts";
import {IEnglishToSqlDto} from "../../models/IEnglishToSqlDto.ts";

export const englishToSqlKeys = {
    all: ["englishToSql"] as const
};

const submitEnglishToSql = async (request: ISubmitEnglishToSqlRequest) => {
    return await axios.post<IEnglishToSqlDto>(`${API_URL}/AiTemplates`, request);
}

export const useEnglishToSqlMutation = () => {
    const queryClient = useQueryClient();

    return useMutation({
        mutationFn: submitEnglishToSql,
        onSuccess: async () => {
            await queryClient.invalidateQueries({queryKey: englishToSqlKeys.all});
        },
    });
};