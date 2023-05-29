import { Component } from "@angular/core";
import { UserTokenInfo } from "src/lib/models/user-token-info";
import { TokenInfo } from "src/lib/models/token-info";

@Component({
    selector: 'home',
    templateUrl: './home.html',
    styleUrls: ['./home.scss']
})
export class HomeComponent
{
    private token: TokenInfo;

    constructor()
    {
        this.token = UserTokenInfo.storage.get();
    }

    getGreetingsMessage(): string
    {
        return `Welcome to the TestingSystem${(this.token == null ? '' : `, ${this.token.userName}`)}!`;
    }
}