import { Component, OnInit, ViewChild } from "@angular/core";
import { MatAccordion } from "@angular/material/expansion";
import { ApiService } from "src/lib/api.service";
import { TokenInfo } from "src/lib/models/token-info";
import { UserTokenInfo } from "src/lib/models/user-token-info";
import { UserTestShort } from "./user-test-short";
import { MatDialog } from '@angular/material/dialog';
import { TestDialogComponent } from "../test-dialog/test-dialog.component";
import { TestCheckResult } from "./test-detail/test-check-result";


@Component({
    selector: 'tests',
    templateUrl: './tests.html',
    styleUrls: ['./tests.scss']
})
export class TestsComponent implements OnInit
{
    @ViewChild(MatAccordion) accordion: MatAccordion;

    token: TokenInfo;
    tests: UserTestShort[];
    current: UserTestShort;

    constructor(private apiService: ApiService)
    {
        this.token = UserTokenInfo.storage.get();
        this.tests = [];
    }

    ngOnInit(): void
    {
        this.loadTests();
    }

    private async loadTests(): Promise<void>
    {
        try
        {
            this.tests = await this.apiService.get<UserTestShort[]>("/api/user/tests");
        }
        catch (err)
        {
            console.log(err);
        }
    }
}

