using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2F.Models
{
    public class ResponseDataDetailPostViewModel
    {
        public ReSultItemDetail result { get; set; }
    }

    public class ReSultItemDetail
    {
        public List<Translations> translations { get; set; }
        public int id { get; set; }
    }
    public class Translations
    {
        public string content { get; set; }

        public int id { get; set; }

        public string slug { get; set; }

        public string summary { get; set; }

        public string title { get; set; }
    }
}
