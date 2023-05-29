import { LocalStorageItem } from "src/lib/storages/local-storage-item";
import { TokenLocalStorage } from "src/lib/storages/token-local-storage";
import { TokenInfo } from "./token-info";

export class UserTokenInfo implements TokenInfo
{
    public static readonly storage: LocalStorageItem<TokenInfo> = new TokenLocalStorage();

    userName: string;
    expiresIn: number;

    constructor(userName: string, expiresIn: number)
    {
        this.userName = userName;
        this.expiresIn = expiresIn;
    }

    
    public static copy(otherToken: TokenInfo): UserTokenInfo
    {
        return new UserTokenInfo(otherToken.userName, Number(otherToken.expiresIn));
    }
}