import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { TestsComponent } from './tests.component';
import { TestDetailComponent } from './test-detail/test-detail.component';

const routes: Routes = [
    {
        path: '',
        component: TestsComponent
    },
    {
        path: ':id',
        component: TestDetailComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class TestsRoutingModule { }
