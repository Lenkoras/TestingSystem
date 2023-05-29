import { Component, Input } from "@angular/core";
import { UserTestShort } from "../tests/user-test-short";

@Component({
    selector: 'test-confirm',
    templateUrl: './test-confirm.html',
    styleUrls: ['./test-confirm.scss']
})
export class TestConfirmComponent
{
    isConfirmed: boolean;
    isProceeded: boolean;
    @Input() test: UserTestShort;

    constructor() {
        this.isConfirmed = false;
        this.isProceeded = false;
    }
}