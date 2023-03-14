using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2F.ViewModel
{
    public class SlideViewModdel
    {
        public string Category { get; set; }
        public string Category2 { get; set; }

        public string NameSlideTitle { get; set; }
        public string NameSlideTitle2 { get; set; }

        public string NameSlideContent { get; set; }
        public string NameSlideContent2 { get; set; }

        public string SlidePhoto { get; set; }
        public string CoverPhoto { get; set; }

        public List<SlideListButton> ListSlideButton { get; set; }
    }
    public class SlideListButton
    {
        public int Id { get; set; }
        public int ButtonTypeId { get; set; }
        public string Name { get; set; }
        public string Name2 { get; set; }

        public string Color { get; set; }
        public string Url { get; set; }
    }
}
