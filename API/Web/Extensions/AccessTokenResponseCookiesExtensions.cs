using Auth.Tokens;

namespace Web.Extensions
{
    public static class AccessTokenResponseCookiesExtensions
    {
        public static void DeleteAccessToken(this IResponseCookies cookies)
        {
            ArgumentNullException.ThrowIfNull(cookies);

            cookies.Delete(
                AccessTokenDefaults.AccessTokenKey,
                new CookieOptions()
                {
                    HttpOnly = true,
                    Secure = true
                }
            );
        }
    }
}
