using System.Security.Claims;

namespace Web.Extensions
{
    public static class NameIdentifierClaimsPrincipalExtensions
    {
        public static bool TryGetId(this ClaimsPrincipal claimsPrincipal, out Guid id)
        {
            ArgumentNullException.ThrowIfNull(claimsPrincipal);

            string? textId = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (textId is not null && Guid.TryParse(textId, out id))
            {
                return true;
            }
            id = default;
            return false;
        }
    }
}
