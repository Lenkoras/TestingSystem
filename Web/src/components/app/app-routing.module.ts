import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
    {
        path: 'home',
        loadChildren: () => import('src/components/home/home.module').then(m => m.HomeModule)
    },
    {
        path: 'auth',
        loadChildren: () => import('src/components/auth/auth.module').then(m => m.AuthModule)
    },
    {
        path: 'tests',
        loadChildren: () => import('src/components/tests/tests.module').then(m => m.TestsModule)
    },
    {
        path: '',
        redirectTo: 'home',
        pathMatch: 'full'
    }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
