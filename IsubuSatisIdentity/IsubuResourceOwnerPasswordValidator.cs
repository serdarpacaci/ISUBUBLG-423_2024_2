using IdentityModel;
using IdentityServer4.Validation;
using IsubuSatisIdentity.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace IsubuSatisIdentity
{

    public class IsubuResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IsubuResourceOwnerPasswordValidator(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var user = await _userManager.FindByEmailAsync(context.UserName);

            if (user is null)
            {
                AddError(context);

                return;
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, context.Password);

            if (!isPasswordValid)
            {
                AddError(context);

                return;
            }
            context.Result =
                new GrantValidationResult(user.Id.ToString(),
                OidcConstants.AuthenticationMethods.Password);
        }

        private static void AddError(ResourceOwnerPasswordValidationContext context)
        {
            context.Result.CustomResponse = new System.Collections.Generic.Dictionary<string, object>
                {
                    {"error", "E-posta veya şifre bilgisi hatalı" }
                };
        }
    }
}
