import { StringParser } from "./string-parser";
import { TokenInfo } from "src/lib/models/token-info";
import { UserTokenInfo } from "src/lib/models/user-token-info";

export class UserTokenInfoParser implements StringParser<UserTokenInfo>
{
    public parse(value: string): UserTokenInfo | null
    {
        if (value == null)
        {
            return null;
        }
        let tokenInfo: TokenInfo;

        try
        {
            tokenInfo = <TokenInfo>JSON.parse(value);
        }
        catch {
            return null;
        }

        if (tokenInfo != null &&
            Number.isInteger(tokenInfo.expiresIn) &&
            tokenInfo.userName != null &&
            tokenInfo.userName.length > 1)
        {
            return UserTokenInfo.copy(tokenInfo);
        }

        return null;
    }
}
