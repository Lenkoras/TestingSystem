import { NgModule } from "@angular/core";
import { TestDialogComponent } from "./test-dialog.component";
import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { RouterModule } from "@angular/router";

@NgModule({
    imports: [
        MatFormFieldModule,
        MatInputModule,
        FormsModule,
        MatButtonModule,
        MatDialogModule,
        RouterModule
    ],
    declarations: [
        TestDialogComponent
    ],
    exports: [
        TestDialogComponent
    ]
})
export class TestDialogModule { }