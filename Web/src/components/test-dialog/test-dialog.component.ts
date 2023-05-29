import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { TestCheckResult } from '../tests/test-detail/test-check-result';

@Component({
    selector: 'test-dialog',
    templateUrl: './test-dialog.html',
    styleUrls: ['./test-dialog.scss']
})
export class TestDialogComponent
{
    constructor(
        public dialogRef: MatDialogRef<TestDialogComponent>,
        @Inject(MAT_DIALOG_DATA) public data: TestCheckResult,
    ) { }

    onNoClick(): void
    {
        this.dialogRef.close();
    }
}