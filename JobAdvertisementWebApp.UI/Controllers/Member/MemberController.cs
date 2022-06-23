using JobAdvertisementWebApp.BLL.Interfaces;
using JobAdvertisementWebApp.DTOs;
using JobAdvertisementWebApp.UI.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JobAdvertisementWebApp.UI.Controllers.Member
{
    [Authorize(Roles = "Member")]
    public class MemberController : Controller
    {
        private readonly IMemberCvService _memberCvService;
        private readonly IAdvertisementService _advertisementService;
        private readonly IApplicationService _applicationService;

        public MemberController(IMemberCvService memberCvService, IAdvertisementService advertisementService, IApplicationService applicationService)
        {
            _memberCvService = memberCvService;
            _advertisementService = advertisementService;
            _applicationService = applicationService;
        }

        public async Task<IActionResult> MemberIndex()
        {
            var UserId = Int32.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var result = await _memberCvService.GetByFilterAsync<MemberCvListDto>(x => x.UserId == UserId);
            return View(result.Data);
        }
        public IActionResult CreateCV()
        {
            return View(new MemberCvCreateDto());
        }
        [HttpPost]
        public async Task<IActionResult> CreateCV(MemberCvCreateDto createDto)
        {
            var MemberName = HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            var MemberLastName = HttpContext.User.FindFirst(ClaimTypes.Surname).Value;
            var UserId = Int32.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            createDto.UserId = UserId;
            createDto.Name = MemberName;
            createDto.LastName = MemberLastName;
            var result = await _memberCvService.CreateAsync(createDto);
            return this.ResponseRedirectToAction(result, "MemberIndex");
        }
        public async Task<IActionResult> UpdateCV(int id)
        {
            var UserId = Int32.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var result = await _memberCvService.GetByFilterAsync<MemberCvUpdateDto>(x => x.Id == id&&x.UserId==UserId);
            return this.ResponseView(result);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCV(MemberCvUpdateDto updateDto)
        {
            var result = await _memberCvService.UpdateAsync(updateDto);
            return this.ResponseRedirectToAction(result, "MemberIndex");
        }
        public async Task<IActionResult> DeleteCV(int id)
        {
            var UserId = Int32.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var result = await _memberCvService.DeleteCV(id, UserId);
            return this.ResponseRedirectToAction(result, "MemberIndex");

        }

        public async Task<IActionResult> GetAdvertisement()
        {
            var result = await _advertisementService.GetAllFilterAsync(x => x.IsActive == true);
            return View(result.Data);
        }
        public async Task<IActionResult> CreateApplication(int AdvertisementId)
        {
            int UserId = Int32.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var result = await _applicationService.CreateApplication(AdvertisementId, UserId);
            return this.ResponseRedirectToAction(result, "GetAdvertisement");
        }
        public async Task<IActionResult> GetUserAppliedAdvertisement()
        {
            int UserId = Int32.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var appResult = await _applicationService.GetApplicationAdvertisementIdByUserId(UserId);
            if (appResult.ResponseType == Common.ResponseObjects.ResponseType.Success)
            {
                var result = await _advertisementService.GetAppliedAdvertisementAsync(appResult.Data);
                return View(result.Data);
            }
            return View(new List<AdvertisementListDto>());
        }
        public async Task<IActionResult> DeleteApplication(int AdvertisementId)
        {
            int UserId = Int32.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var checkApplication = await _applicationService.GetByFilterAsync<ApplicationListDto>(x => x.UserId == UserId && x.AdvertisementId == AdvertisementId);
            if (checkApplication.ResponseType == Common.ResponseObjects.ResponseType.Success)
            {
                await _applicationService.DeleteAsync(checkApplication.Data.Id);
                return RedirectToAction("GetUserAppliedAdvertisement");
            }
            return NotFound();
        }

    }
}
