
using Novatic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.Repository
{
    public interface ISystemConfigRepository
    {
        Task<List<SystemConfig>> List();
        Task<List<SystemConfig>> ListSotay();
        Task<List<SystemConfig>> List9Category();
        Task<List<SystemConfig>> ListLogo();

        Task<List<SystemConfig>> Search(string keyword);

        Task<List<SystemConfig>> ListPaging(int pageIndex, int pageSize);

        Task<List<SystemConfig>> Detail(int? postId);
        Task<List<SystemConfig>> DetailByCode(string Code);

        Task<SystemConfig> Add(SystemConfig SystemConfig);

        Task Update(SystemConfig SystemConfig);

        Task Delete(SystemConfig SystemConfig);

        Task<int> DeletePermanently(int? SystemConfigId);
        Task<List<SystemConfig>> ListLogoAndBackgroundImage();
        Task<List<SystemConfig>> ListSocial();
        Task<List<SystemConfig>> ListSlide();
    }
}
