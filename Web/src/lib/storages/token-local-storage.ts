import { LocalStorageItemBase } from "./local-storage-item-base";
import { UserTokenInfoParser } from "../parsers/user-token-info-parser";
import { TokenInfo } from "src/lib/models/token-info";

export class TokenLocalStorage extends LocalStorageItemBase<TokenInfo>
{
    public static readonly Key = 'Token-Info';

    constructor()
    {
        super(TokenLocalStorage.Key, new UserTokenInfoParser());
    }
}
