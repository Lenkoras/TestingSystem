import { Component } from "@angular/core";
import { AuthService } from "./services/auth.service";
import { Router } from "@angular/router";

@Component({
    selector: 'auth',
    templateUrl: './auth.html',
    styleUrls: ['./auth.scss']
})
export class AuthComponent
{
    userName: string;
    password: string;
    token: string;
    hidePassword: boolean;
    status: string;
    inProcess: boolean;
    byToken: boolean;

    constructor(private authService: AuthService, private router: Router)
    {
        this.userName = 'lenkoras';
        this.password = 'MySuperSecretKey';
        this.status = '';
        this.hidePassword = true;
        this.inProcess = false;
        this.byToken = false;
    }

    async login()
    {
        this.status = 'Processing..';
        this.inProcess = true;

        if (!this.byToken)
        {
            if (this.userName.length < 2 || this.password.length < 6)
            {
                this.status = '';
                return;
            }


            const loginResult = await this.authService.login(this.userName, this.password);
            if (loginResult.error != null)
            {
                this.inProcess = false;
                this.status = `Authorization error: ${loginResult.error.message}`;
                return;
            }
            this.inProcess = false;

        }
        else
        {
            if (this.token.length < 1)
            {
                this.status = '';
                return;
            }

            const loginResult = await this.authService.auth(this.token);
            this.inProcess = false;
            if (loginResult != null && loginResult.error != null)
            {
                this.status = `Authorization error: ${loginResult.error.message}`;
                return;
            }
        }
        await this.router.navigate(['home']);
    }
}