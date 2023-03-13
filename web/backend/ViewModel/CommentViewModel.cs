using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.ViewModel
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string AccountName { get; set; }

        public int PostId { get; set; }
        public string PostName { get; set; }
        public int PostCategoryId { get; set; }
        public string PostCategoryName { get; set; }
        public int Active { get; set; }
        public int Approve { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Text { get; set; }
        public string Website { get; set; }
        public DateTime CreatedTime { get; set; }
        public int IsChecked { get; set; }


        public string Username { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public string Info { get; set; }

    }
}
