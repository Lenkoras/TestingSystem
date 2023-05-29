import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PageNotFoundComponent } from '../page-not-found/page-not-found.component';
import { AuthGuard } from '../auth/services/auth.guard';

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
        loadChildren: () => import('src/components/tests/tests.module').then(m => m.TestsModule),
        canActivate: [AuthGuard]
    },
    {
        path: 'user',
        loadChildren: () => import('src/components/user/user.module').then(m => m.UserModule),
        canActivate: [AuthGuard]
    },
    {
        path: '',
        redirectTo: 'home',
        pathMatch: 'full'
    },
    {
        path: '**',
        component: PageNotFoundComponent
    }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
