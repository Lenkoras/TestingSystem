import { NgModule } from "@angular/core";
import { UserComponent } from "./user.component";
import { UserRoutingModule } from "./user-routing.module";
import { MatButtonModule } from "@angular/material/button";
import { ApiService } from "src/lib/api.service";
import { AuthService } from "../auth/services/auth.service";

@NgModule({
    imports: [
        UserRoutingModule,
        MatButtonModule
    ],
    declarations: [UserComponent],
    exports: [UserComponent],
    providers: [
        AuthService,
        ApiService
    ]
})
export class UserModule { }