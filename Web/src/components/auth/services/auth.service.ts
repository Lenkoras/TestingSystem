import { Injectable } from '@angular/core';
import { TokenInfo } from 'src/lib/models/token-info';
import { ApiService } from 'src/lib/api.service';
import { UserTokenInfo } from 'src/lib/models/user-token-info';

export interface LoginResult
{
    token?: TokenInfo | null;
    error?: any;
}

@Injectable()
export class AuthService
{
    private tokenInfo: TokenInfo | null;

    public get userToken()
    {
        return this.tokenInfo;
    }

    constructor(private apiService: ApiService)
    {
    }

    async auth(token: string): Promise<LoginResult>
    {
        try
        {
            this.tokenInfo = await this.apiService.post('/api/Token/set', null, { headers: { Authorization: 'Bearer ' + token } });
            
            if (this.tokenInfo == null)
            {
                return { error: { message: 'Access token was null!' } };
            }
            UserTokenInfo.storage.set(this.tokenInfo);
            return { token: this.tokenInfo };
        }
        catch (err)
        {
            console.log(err);
            return { error: err };
        }
    }

    async login(userName: string, password: string): Promise<LoginResult>
    {
        try
        {
            this.tokenInfo = await this.apiService.post<TokenInfo>('/api/Auth/login', { userName, password });
            if (this.tokenInfo == null)
            {
                return { error: { message: 'Access token was null!' } };
            }
            UserTokenInfo.storage.set(this.tokenInfo);
            return { token: this.tokenInfo };
        }
        catch (err)
        {
            console.log(err);
            return { error: err };
        }
    }

    async logout(): Promise<boolean>
    {
        try
        {
            await this.apiService.post('/api/Auth/logout', null);
            UserTokenInfo.storage.remove();
            return true;
        }
        catch (err)
        {
            console.log(err);
        }
        return false;
    }
}