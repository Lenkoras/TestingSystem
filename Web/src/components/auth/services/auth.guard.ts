import { Injectable, inject } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, Router, CanActivateFn } from '@angular/router';
import { TokenInfo } from 'src/lib/models/token-info';
import { UserTokenInfo } from 'src/lib/models/user-token-info';

@Injectable({
    providedIn: 'root'
})
class PermissionsService
{

    constructor(private router: Router) { }

    async canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot): Promise<boolean>
    {
        const tokenInfo: TokenInfo = UserTokenInfo.storage.get();
        
        if (tokenInfo != null && new Date() < new Date(tokenInfo.expiresIn))
        {
            return true;
        }
        await this.router.navigate(['/auth']);
        return false;
    }
}

export const AuthGuard: CanActivateFn = (next: ActivatedRouteSnapshot, state: RouterStateSnapshot): Promise<boolean> =>
{
    return inject(PermissionsService).canActivate(next, state);
}