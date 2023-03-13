
using A2F.ViewModel;
using Novatic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.Repository
{
    public interface IQuestionRepository
    {
        Task<List<Question>> List();

        Task<List<Question>> Search(string keyword);

        Task<List<Question>> ListPaging(int pageIndex, int pageSize);

        Task<List<Question>> Detail(int? postId);

        Task<Question> Add(Question Question);

        Task Update(Question Question);

        Task Delete(Question Question);

        Task<int> DeletePermanently(int? QuestionId);

        int CountQuestion();
        Task<List<SurveySectionViewModel>> ListQuestionViewModelBySurveySectionId(int surveySectionId);

    }
}
