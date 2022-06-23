using JobAdvertisementWebApp.BLL.Interfaces;
using JobAdvertisementWebApp.DTOs;
using JobAdvertisementWebApp.UI.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JobAdvertisementWebApp.UI.Controllers.Employer
{
    [Authorize(Roles = "Employer")]
    public class EmployerController : Controller
    {
        private readonly ICompanyService _companyService;
        private readonly IAdvertisementService _advertisementService;
        private readonly IApplicationService _applicationService;
        private readonly IMemberCvService _memberCvService;
        

        public EmployerController(ICompanyService companyService, IAdvertisementService advertisementService, IApplicationService applicationService, IMemberCvService memberCvService)
        {
            _companyService = companyService;
            _advertisementService = advertisementService;
            _applicationService = applicationService;
            _memberCvService = memberCvService;
        }

        public async Task<IActionResult> EmployerIndex()
        {
            var UserId = Int32.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var result = await _companyService.GetAllFilterAsync(x => x.UserId == UserId);
            return View(result.Data);
        }
        public IActionResult CreateCompany()
        {
            return View(new CompanyCreateDto());
        }
        [HttpPost]
        public async Task<IActionResult> CreateCompany(CompanyCreateDto createDto)
        {
            var UserId = Int32.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            createDto.UserId = UserId;
            var result = await _companyService.CreateAsync(createDto);
            return this.ResponseRedirectToAction(result, "EmployerIndex");
        }
        
        public async Task<IActionResult> UpdateCompany(int id)
        {
            var UserId = Int32.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var result = await _companyService.GetByFilterAsync<CompanyUpdateDto>(x => x.Id == id&&x.UserId==UserId);
            return this.ResponseView(result);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCompany(CompanyUpdateDto updateDto)
        {
            var result = await _companyService.UpdateAsync(updateDto);
            return this.ResponseRedirectToAction(result, "EmployerIndex");
        }
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var UserId = Int32.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var deleteResult = await _companyService.DeleteCompany(id, UserId);
            return this.ResponseRedirectToAction(deleteResult, "EmployerIndex");
        }
       
        public async Task<IActionResult> GetAdvertisement(int id)
        {
            var UserId = Int32.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var checkCompany = await _companyService.GetByFilterAsync<CompanyUpdateDto>(x => x.Id == id && x.UserId == UserId);
            if (checkCompany.ResponseType == Common.ResponseObjects.ResponseType.Success)
            {
                var result = await _advertisementService.GetAllFilterAsync(x => x.CompanyId == id&&x.IsActive==true);
                ViewBag.CompanyId = id;
                return View(result.Data);
            }
            return NotFound();
        }
        public async Task<IActionResult> GetAdvertisementDisable(int id)
        {
            var UserId = Int32.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var checkCompany = await _companyService.GetByFilterAsync<CompanyUpdateDto>(x => x.Id == id && x.UserId == UserId);
            if (checkCompany.ResponseType == Common.ResponseObjects.ResponseType.Success)
            {
                var result = await _advertisementService.GetAllFilterAsync(x => x.CompanyId == id && x.IsActive == false);
                ViewBag.CompanyId = id;
                return View(result.Data);
            }
            return NotFound();
        }
        public async Task<IActionResult> CreateAdvertisement(int companyId)
        {
            var UserId = Int32.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var result = await _advertisementService.CheckCreateAdvertisement(companyId, UserId);
            return this.ResponseView(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAdvertisement(AdvertisementCreateDto dto)
        {
            var result = await _advertisementService.CreateAsync(dto);
            var id = result.Data.CompanyId;
            return this.ResponseRedirectToActionRoute(result, "GetAdvertisement", id);
        }
        public async Task<IActionResult> UpdateAdvertisement(int id)
        {
            var UserId = Int32.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var result = await _advertisementService.CheckUpdateAdvertisement(id, UserId);
            return this.ResponseView(result);

        }
        [HttpPost]
        public async Task<IActionResult> UpdateAdvertisement(AdvertisementUpdateDto updateDto)
        {
            var result = await _advertisementService.UpdateAsync(updateDto);
            var id = result.Data.CompanyId;
            return this.ResponseRedirectToActionRoute(result, "GetAdvertisement", id);
        }
        public async Task<IActionResult> DeleteAdvertisement(int id)
        {
            var UserId = Int32.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var result = await _advertisementService.DeleteAdvertisement(id, UserId);
            return this.ResponseRedirectToAction(result, "EmployerIndex");
        }
        public async Task<IActionResult> DisableAdvertisement(int id)
        {
            var UserId = Int32.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var result = await _advertisementService.DisableAdvertisement(id, UserId);
            return this.ResponseRedirectToAction(result, "EmployerIndex");
        }
        public async Task<IActionResult> EnableAdvertisement(int id)
        {
            var UserId = Int32.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var result = await _advertisementService.EnableAdvertisement(id, UserId);
            return this.ResponseRedirectToAction(result, "EmployerIndex");
        }
        public async Task<IActionResult> GetApplication(int AdvertisementId)
        {
            var result = await _advertisementService.GetByFilterAsync<AdvertisementUpdateDto>(x => x.Id == AdvertisementId);
            if (result.ResponseType == Common.ResponseObjects.ResponseType.Success)
            {
                var companyResult = await _companyService.GetByFilterAsync<CompanyUpdateDto>(x => x.Id == result.Data.CompanyId);
                var UserId = Int32.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
                if (UserId == companyResult.Data.UserId)
                {
                    var appResult = await _applicationService.GetApplicationUserIdByAdvertisementId(AdvertisementId);
                    if (appResult.ResponseType == Common.ResponseObjects.ResponseType.Success)
                    {
                        var memberResult = await _memberCvService.GetMemberCVListAsync(appResult.Data);
                        return View(memberResult.Data);
                    }
                }
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> GetMemberCv(int id)
        {
            var result = await _memberCvService.GetByFilterAsync<MemberCvListDto>(x => x.Id == id);
            return this.ResponseView(result);
        }
    }
}
