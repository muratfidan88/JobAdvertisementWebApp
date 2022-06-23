using JobAdvertisementWebApp.BLL.Interfaces;
using JobAdvertisementWebApp.DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JobAdvertisementWebApp.UI.Controllers.Account
{
    public class AccountController : Controller
    {
        private readonly IAppUserService _appUserService;

        public AccountController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public IActionResult SignUpEmployer()
        {
            return View(new AppUserCreateDto());
        }
        [HttpPost]
        public async Task<IActionResult> SignUpEmployer(AppUserCreateDto createDto)
        {
            var result = await _appUserService.CreateEmployerAsync(createDto);
            if (result.ResponseType == Common.ResponseObjects.ResponseType.Success)
            {
                return RedirectToAction("SignIn");
            }
            else if (result.ResponseType == Common.ResponseObjects.ResponseType.Error)
            {
                ModelState.AddModelError("",result.Message);
                return View(createDto);
            }
            else
            {
                foreach (var error in result.ValidationErrors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(createDto);
            }
        }
        public IActionResult SignUpMember()
        {
            return View(new AppUserCreateDto());
        }
        [HttpPost]
        public async Task<IActionResult> SignUpMember(AppUserCreateDto createDto)
        {
            var result = await _appUserService.CreateMemberAsync(createDto);
            if (result.ResponseType == Common.ResponseObjects.ResponseType.Success)
            {
                return RedirectToAction("SignIn");
            }
            else if (result.ResponseType == Common.ResponseObjects.ResponseType.Error)
            {
                ModelState.AddModelError("", result.Message);
                return View(createDto);
            }
            else
            {
                foreach (var error in result.ValidationErrors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(createDto);
            }
        }
        public IActionResult SignIn()
        {
            return View(new AppUserSignInDto());
        }
        [HttpPost]
        public async Task<IActionResult> SignInAsync(AppUserSignInDto dto)
        {
                var result = await _appUserService.CheckUserAsync(dto);
                if (result.ResponseType == Common.ResponseObjects.ResponseType.Success)
                {
                    var claims = new List<Claim>();
                    if (result.Data.RoleId == 1)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, "Employer"));
                    }
                    if (result.Data.RoleId == 2)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, "Member"));
                    }
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, result.Data.Id.ToString()));
                    claims.Add(new Claim(ClaimTypes.Name, result.Data.Name));
                    claims.Add(new Claim(ClaimTypes.Surname, result.Data.LastName));
                var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = dto.RememberMe,
                    };
                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);
                    return RedirectToAction("Direction", "Home");
                }
            ModelState.AddModelError("",result.Message);
            return View(dto);
        }
        public async Task<IActionResult> LogOutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
