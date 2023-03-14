using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2F.ViewModel
{
    public class SystemConfigViewModel
    {
        public int Id { get; set; }
        public int Active { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Category { get; set; }
        public string Category2 { get; set; }

        public string NameSlideTitle { get; set; }
        public string NameSlideTitle2 { get; set; }

        public string NameSlideContent { get; set; }
        public string NameSlideContent2 { get; set; }

        public string SlidePhoto { get; set; }
        public string CoverPhoto { get; set; }
        public string Color { get; set; }
        public int ButtonTypeId { get; set; }
        public List<SlideListButton> ListSlideButton { get; set; }
    }
}
