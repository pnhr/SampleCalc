using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PS.Calc.Api.Auth;
using PS.Calc.Api.Services.Interfaces;
using PS.Calc.Data.AppExceptions;
using PS.Calc.Data.Constants;

namespace PS.Calc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : AppBaseController
    {
        private readonly IAuthService _userService;

        public AuthController(IAuthService userService, IConfiguration config, ILogger<AuthController> logger) : base(config, logger)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("login")]
        [Authorize(Policy = PolicyNames.Windows)]
        public async Task<IActionResult> Login()
        {
            await _userService.Login(HttpContext);
            return OkWrapper();
        }

        [HttpPost]
        [Route("istokenexpired")]
        [Authorize(Policy = PolicyNames.AppPolicyName)]
        public async Task<IActionResult> IsTokenExpired()
        {
            bool isTokenExpired = true;
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                isTokenExpired = await _userService.IsTokenExpired(HttpContext);
                string msg = isTokenExpired ? AppConstants.TOKEN_EXPIRED : AppConstants.TOKEN_NOT_EXPIRED;
                return OkWrapper(isTokenExpired, msg);
            }
            return OkWrapper(isTokenExpired, AppConstants.TOKEN_EXPIRED);
        }

        [HttpPost]
        [Route("getuserbyjwt")]
        [Authorize(Policy = PolicyNames.AppPolicyName)]
        public async Task<IActionResult> GetUserByToken()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                IdentityVM data = await _userService.GetUserByToken(HttpContext);
                return OkWrapper(data);
            }
            else
                throw new UnauthorizedException(ErrorMessages.UNAUTHORIZED);
        }

        [HttpGet]
        [Route("logout")]
        public async Task<ActionResult> Logout()
        {
            HttpContext.Response.Cookies.Delete("access_token");
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return OkWrapper();
        }
    }
}
