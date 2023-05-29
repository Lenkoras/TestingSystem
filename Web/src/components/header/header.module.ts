import { NgModule } from "@angular/core";
import { HeaderComponent } from "./header.component";
import { MatButtonModule } from "@angular/material/button";
import { MatRippleModule } from "@angular/material/core";
import { MatToolbarModule } from "@angular/material/toolbar";
import { RouterModule } from "@angular/router";
import { NgIf } from "@angular/common";

@NgModule({
    imports: [
        MatToolbarModule,
        MatButtonModule,
        MatRippleModule,
        RouterModule,
        NgIf
    ],
    declarations: [HeaderComponent],
    exports: [HeaderComponent]
})
export class HeaderModule { }