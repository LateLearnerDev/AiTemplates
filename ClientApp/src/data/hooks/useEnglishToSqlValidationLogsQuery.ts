import axios from "axios";
import {IEnglishToSqlDto} from "../../models/IEnglishToSqlDto.ts";
import {API_URL} from "../../constants/appData.ts";
import {useMutation, useQueryClient} from "@tanstack/react-query";
import {ILogEnglishToSqlValidationRequest} from "../../models/ILogEnglishToSqlValidationRequest.ts";

export const englishToSqlValidationLogKeys = {
    all: ["englishToSqlValidationLog"] as const
};

const submitEnglishToSqlValidationLog = async (request: ILogEnglishToSqlValidationRequest) => {
    return await axios.post<IEnglishToSqlDto>(`${API_URL}/EnglishToSqlValidationLogs`, request);
}

export const useValidateEnglishToSqlMutation = () => {
    const queryClient = useQueryClient();

    return useMutation({
        mutationFn: submitEnglishToSqlValidationLog,
        onSuccess: async () => {
            await queryClient.invalidateQueries({queryKey: englishToSqlValidationLogKeys.all});
        },
    });
};