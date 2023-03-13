  
    using Novatic.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public interface IQuestionTypeRepository
        {
            Task<List<QuestionType>> List();

            Task<List<QuestionType>> Search(string keyword);

            Task<List<QuestionType>> ListPaging(int pageIndex, int pageSize);

            Task<List<QuestionType>> Detail(int? postId);

            Task<QuestionType> Add(QuestionType QuestionType);

            Task Update(QuestionType QuestionType);

            Task Delete(QuestionType QuestionType);

            Task<int> DeletePermanently(int? QuestionTypeId);

            int CountQuestionType();
        }
    }
    