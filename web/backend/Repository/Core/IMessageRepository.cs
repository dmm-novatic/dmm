  
    using Novatic.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public interface IMessageRepository
        {
            Task<List<Message>> List();

            Task<List<Message>> Search(string keyword);

            Task<List<Message>> ListPaging(int pageIndex, int pageSize);

            Task<List<Message>> Detail(int? postId);

            Task<Message> Add(Message Message);

            Task Update(Message Message);

            Task Delete(Message Message);

            Task<int> DeletePermanently(int? MessageId);
            Task<List<Message>> ListMessage();
        }
    }
    