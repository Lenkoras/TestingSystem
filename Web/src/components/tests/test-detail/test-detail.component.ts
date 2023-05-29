import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, ParamMap } from "@angular/router";
import { TestQuestion } from "../test-question";
import { TestQuestionService } from "../test-question.service";
import { CollectionEnumerator } from "src/lib/collections/collection-enumerator";
import { ArrayEnumerator } from "src/lib/collections/array-enumerator";
import { ApiService } from "src/lib/api.service";
import { TestCheckResult } from "./test-check-result";
import { MatDialog } from "@angular/material/dialog";
import { TestDialogComponent } from "src/components/test-dialog/test-dialog.component";

@Component({
    selector: 'test-detail',
    templateUrl: './test-detail.html',
    styleUrls: ['./test-detail.scss']
})
export class TestDetailComponent implements OnInit
{
    id: string;
    enumerator: CollectionEnumerator<TestQuestion>;
    questions: TestQuestion[];
    answerIdArray: string[];
    isSending: boolean;

    constructor(private testService: TestQuestionService, private route: ActivatedRoute, public dialog: MatDialog, private apiService: ApiService)
    {
        this.enumerator = new ArrayEnumerator([]);
        this.questions = [];
        this.answerIdArray = [];
        this.isSending = false;
    }

    ngOnInit(): void
    {
        
        this.route.paramMap.subscribe(async (params: ParamMap) =>
        {
            this.id = params.get('id');
            if (this.id == null)
            {
                return;
            }
            const questions = await this.testService.get(this.id);
            if (questions != null)
            {
                this.questions = questions;
                this.answerIdArray = new Array(this.questions.length).fill('', 0, this.questions.length);
                this.enumerator = new ArrayEnumerator(questions);
                this.enumerator.moveNext();
            }
        });
    }

    isCanFinish()
    {
        return !this.isSending && this.enumerator.currentIndex == this.enumerator.count - 1 && this.answerIdArray.every(value => this.isValidStr(value));
    }

    private isValidStr(value: string)
    {
        return value != null && this.isString(value) && value.length > 0;
    }

    isValidAnswer(): boolean
    {
        return this.isValidStr(this.answerIdArray[this.enumerator.currentIndex]);
    }

    async sendResults()
    {
        if (this.isSending)
        {
            return;
        }
        this.isSending = true;
        try {
            var result = await this.apiService.post<TestCheckResult>('/api/test/check',
            {
                id: this.id,
                questions: this.questions.map((q, index) =>
                ({
                    id: q.id,
                    answerId: this.answerIdArray[index]
                }))
            });
            this.openDialog(result);
        }
        catch (err) {
            console.log(err);
        }
        this.isSending = false;
    }

    private isString(value)
    {
        return typeof value === 'string' || value instanceof String;
    }

    createRange(count: number): Array<number>
    {
        return new Array(count);
    }

    openDialog(result: TestCheckResult) {
        const dialogRef = this.dialog.open(TestDialogComponent, {
            data: result,
        });
    }
}

