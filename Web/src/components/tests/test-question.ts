import { QuestionAnswer } from "./question-answer";


export interface TestQuestion
{
    id: string;
    text: string;
    answers: QuestionAnswer[];
}
