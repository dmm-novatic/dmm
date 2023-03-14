 
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Novatic.ViewModel 
{
    public class FinancialProductDetailViewModel
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



        // EnterpriseType 
        public int? EnterpriseTypeId { get; set; }
        public string EnterpriseTypeName { get; set; }


        //FinancialProduct 

        public int? FinancialProductId { get; set; }
        public string FinancialProductName { get; set; }

        //OrganizationType
        public int? OrganizationTypeId { get; set; }
        public string OrganizationTypeName { get; set; }

        // FinancialProductType
        public int? FinancialProductTypeId { get; set; }
        public string FinancialProductTypeName { get; set; }
    }

}
