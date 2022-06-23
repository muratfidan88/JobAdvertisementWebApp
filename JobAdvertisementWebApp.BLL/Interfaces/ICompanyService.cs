using JobAdvertisementWebApp.Common.ResponseObjects;
using JobAdvertisementWebApp.DTOs;
using JobAdvertisementWebApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobAdvertisementWebApp.BLL.Interfaces
{
    public interface ICompanyService : IService<CompanyListDto, CompanyCreateDto, CompanyUpdateDto, Company>
    {
        Task<IResponse> DeleteCompany(int id, int UserId);
    }
}
