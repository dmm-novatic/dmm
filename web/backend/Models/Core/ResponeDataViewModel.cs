using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2F.Models
{
    public class ResponeDataViewModel
    {
        public ReSultItem result { get; set; }
    }
    public class ReSultItem
    {
        public List<Item> items { get; set; }
        public int totalCount { get; set; }

    }
    public class Item
    {
        public string content { get; set; }

        public Core core { get; set; }

        public int id { get; set; }

        public string slug { get; set; }

        public string summary { get; set; }

        public string title { get; set; }
    }
    public class Core
    {
        public List<FileVaults> fileVaults { get; set; }
        public List<CmsPostCategories> cmsPostCategories { get; set; }
        public int id { get; set; }
        public DateTime publishedTime { get; set; }
    }
    public class CmsPostCategories
    {
        public int categoryId { get; set; }
    }
    public class FileVaults
    {
        public string fileName { get; set; }
        public string filePath { get; set; }
    }
}
