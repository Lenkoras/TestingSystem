import { NgModule } from "@angular/core";
import { AuthComponent } from "./auth.component";
import { AuthRoutingModule } from "./auth-routing.module";

@NgModule({
    imports: [
        AuthRoutingModule
    ],
    declarations: [AuthComponent],
    exports: [AuthComponent]
})
export class AuthModule { }