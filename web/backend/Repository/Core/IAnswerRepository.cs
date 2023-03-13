
using Novatic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.Repository
{
    public interface IAnswerRepository
    {
        Task<List<Answer>> List();

        Task<List<Answer>> Search(string keyword);

        Task<List<Answer>> ListPaging(int pageIndex, int pageSize);

        Task<List<Answer>> Detail(int? postId);

        Task<Answer> Add(Answer Answer);

        Task Update(Answer Answer);

        Task Delete(Answer Answer);

        Task<int> DeletePermanently(int? AnswerId);

        int CountAnswer();
        Task<List<Answer>> ListByQuestionId(int questionId);
        }
}
