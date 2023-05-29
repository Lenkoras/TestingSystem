import { NgModule } from "@angular/core";
import { TestsComponent } from "./tests.component";
import { TestsRoutingModule } from "./tests-routing.module";
import { ApiService } from "src/lib/api.service";
import { CommonModule } from "@angular/common";
import { MatButtonModule } from "@angular/material/button";
import { MatExpansionModule } from '@angular/material/expansion';
import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { TestQuestionService } from "./test-question.service";
import { TestDetailComponent } from "./test-detail/test-detail.component";
import { MatRadioModule } from '@angular/material/radio';
import { FormsModule } from "@angular/forms";
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { TestDialogModule } from "../test-dialog/test-dialog.module";
import { TestConfirmModule } from "../test-confirm/test-confirm.module";

@NgModule({
    imports: [
        TestsRoutingModule,
        MatButtonModule,
        FormsModule,
        MatExpansionModule,
        MatIconModule,
        MatFormFieldModule,
        MatRadioModule,
        MatProgressSpinnerModule,
        TestDialogModule,
        TestConfirmModule,
        CommonModule
    ],
    declarations: [
        TestsComponent,
        TestDetailComponent
    ],
    exports: [
        TestsComponent,
        TestDetailComponent
    ],
    providers: [
        ApiService,
        TestQuestionService
    ]
})
export class TestsModule { }