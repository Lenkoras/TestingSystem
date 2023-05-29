import { NgModule } from "@angular/core";
import { TestConfirmComponent } from "./test-confirm.component";
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatButtonModule } from "@angular/material/button";
import { RouterModule } from "@angular/router";
import { NgIf } from "@angular/common";
import { FormsModule } from "@angular/forms";

@NgModule({
    imports: [
        MatCheckboxModule,
        MatButtonModule,
        FormsModule,
        RouterModule,
        NgIf
    ],
    declarations: [TestConfirmComponent],
    exports: [TestConfirmComponent]
})
export class TestConfirmModule { }