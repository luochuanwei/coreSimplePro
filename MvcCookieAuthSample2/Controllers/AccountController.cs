using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcCookieAuthSample.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using MvcCookieAuthSample.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace MvcCookieAuthSample.Controllers
{
    
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        /// 内部跳转
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                //如果是本地
                return Redirect(returnUrl);
            }

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        /// <summary>
        /// 添加验证错误
        /// </summary>
        /// <param name="result"></param>
        private void AddError(IdentityResult result)
        {
            //遍历所有的验证错误
            foreach (var error in result.Errors)
            {
                //返回error到model
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }


        public IActionResult Register(string returnUrl = null)
        {
            ViewData["returnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            ViewData["returnUrl"] = returnUrl;

            var identityUser = new ApplicationUser()
            {
                Email = registerViewModel.Email,
                UserName = registerViewModel.Email,
                NormalizedEmail = registerViewModel.Email
            };

            var identityResult = await _userManager.CreateAsync(identityUser, registerViewModel.Password);
            if (identityResult.Succeeded)
            {
                //注册完成生产cookie信息
                await _signInManager.SignInAsync(identityUser, new AuthenticationProperties { IsPersistent = true });
                //跳转到注册之前的页面
                return RedirectToLocal(returnUrl);
            }
            else
            {
                AddError(identityResult);
            }

            return View();
        }

        public IActionResult Login(string returnUrl = null)
        {
            ViewData["returnUrl"] = returnUrl;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            ViewData["returnUrl"] = returnUrl;

            var identityUser = await _userManager.FindByEmailAsync(loginViewModel.Email);

            if(identityUser == null)
            {
                //登录账户异常
            }

            //登录验证 无...

            await _signInManager.SignInAsync(identityUser, new AuthenticationProperties { IsPersistent = true });
            return RedirectToLocal(returnUrl);
        }

        public IActionResult MakeLogin()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "Luo"),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return Ok();
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Ok();
        }
    }
}
