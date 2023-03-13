  
    using Novatic.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public interface ILanguageConfigRepository
        {
            Task<List<LanguageConfig>> List();

            Task<List<LanguageConfig>> Search(string keyword);

            Task<List<LanguageConfig>> ListPaging(int pageIndex, int pageSize);

            Task<List<LanguageConfig>> Detail(int? postId);

            Task<LanguageConfig> Add(LanguageConfig LanguageConfig);

            Task Update(LanguageConfig LanguageConfig);

            Task Delete(LanguageConfig LanguageConfig);

            Task<int> DeletePermanently(int? LanguageConfigId);
        }
    }
    