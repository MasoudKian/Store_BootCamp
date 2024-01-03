using System.Security.Claims;

namespace Store_BootCamp.Web.Extentions
{
    public static class IdentityExtentions
    {
        public static int GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal !=null)
            {
                var data = claimsPrincipal.Claims.SingleOrDefault(s=>s.Type == ClaimTypes.NameIdentifier);

                if (data != null) return Convert.ToInt32(data.Value);
            }
            return default(int);
        }
    }
}
