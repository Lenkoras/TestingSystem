import { Component } from "@angular/core";
import { TokenInfo } from "src/lib/models/token-info";
import { UserTokenInfo } from "src/lib/models/user-token-info";
import { AuthService } from "../auth/services/auth.service";
import { Router } from "@angular/router";

@Component({
    selector: 'user',
    templateUrl: './user.html',
    styleUrls: ['./user.scss']
})
export class UserComponent
{
    token: TokenInfo;

    constructor(private authService: AuthService, private router: Router)
    {
        this.token = UserTokenInfo.storage.get();

        if (this.token == null) {
            throw new Error('User must be logged in to view user page.');
        }
    }

    async logout() {
        if (await this.authService.logout()) {
            await this.router.navigate(['home']);
        }
    }
}