import { NgModule } from "@angular/core";
import { AuthComponent } from "./auth.component";
import { AuthRoutingModule } from "./auth-routing.module";
import { FormsModule } from '@angular/forms';
import { AuthService } from "./services/auth.service";
import { ApiService } from "../../lib/api.service";
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatCheckboxModule } from "@angular/material/checkbox";

import { NgIf } from "@angular/common";

@NgModule({
    imports: [
        MatCheckboxModule,
        NgIf,
        AuthRoutingModule,
        FormsModule,
        MatButtonModule,
        MatIconModule,
        MatInputModule,
        MatFormFieldModule,
        MatProgressSpinnerModule
    ],
    declarations: [AuthComponent],
    exports: [AuthComponent],
    providers: [
        AuthService,
        ApiService
    ]
})
export class AuthModule { }