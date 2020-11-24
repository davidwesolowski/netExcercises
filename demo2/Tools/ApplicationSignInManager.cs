using System.Threading.Tasks;
using demo2.Persistance.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace demo2.Tools
{
	public class ApplicationSignInManager : SignInManager<MyUserAccount>
	{
		public ApplicationSignInManager(UserManager<MyUserAccount> userManager, IHttpContextAccessor contextAccessor, IUserClaimsPrincipalFactory<MyUserAccount> claimsFactory, IOptions<IdentityOptions> optionsAccessor, ILogger<SignInManager<MyUserAccount>> logger, IAuthenticationSchemeProvider schemes, IUserConfirmation<MyUserAccount> confirmation) : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes, confirmation)
		{
		}

		public override async Task<bool> CanSignInAsync(MyUserAccount user)
		{
			return user.Nickname != null && !user.Nickname.Contains("Reksio") && (await base.CanSignInAsync(user));
		}
	}
}