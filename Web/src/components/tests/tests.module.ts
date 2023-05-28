import { NgModule } from "@angular/core";
import { TestsComponent } from "./tests.component";
import { TestsRoutingModule } from "./tests-routing.module";

@NgModule({
    imports: [
        TestsRoutingModule
    ],
    declarations: [TestsComponent],
    exports: [TestsComponent]
})
export class TestsModule { }