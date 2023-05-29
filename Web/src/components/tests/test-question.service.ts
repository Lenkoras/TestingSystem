import { Injectable } from "@angular/core";
import { ApiService } from "src/lib/api.service";
import { TestQuestion } from "./test-question";

@Injectable()
export class TestQuestionService
{
    constructor(private apiService: ApiService)
    {
    }

    get(id: string): Promise<TestQuestion[]>
    {
        // return new Promise((resolve) => resolve([{ id: '1', text: 'text1', answers: [{ id: '1', text: 'answer1' }, { id: '2', text: 'answer2' }] }, { id: '2', text: 'text2', answers: [{ id: '3', text: 'answer3' }, { id: '4', text: 'answer4' }] }]));
        return this.apiService.get<TestQuestion[]>(`/api/test/${id}`);
    }
}
