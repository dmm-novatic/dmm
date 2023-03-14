using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Novatic.ViewModel
{
    public class PreferentialProductDetailViewModel
    {
        public int Id { get; set; } 
        public int Active { get; set; }
        public string Photo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public string Name2 { get; set; }
        public string Description2 { get; set; }
        public string Text2 { get; set; }
        public DateTime CreatedTime { get; set; }

        //Organization
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationDescription { get; set; }
        public string OrganizationText { get; set; }
        public string OrganizationPhoto { get; set; }

        // Preferential Product
        public int PreferentialProductId { get; set; }
        public string PreferentialProductName { get; set; }

        // Preferential Product
        public int PreferentialTypeId { get; set; }
        public string PreferentialTypeName { get; set; }

    }
}
