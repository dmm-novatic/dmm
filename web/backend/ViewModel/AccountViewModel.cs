using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.ViewModel
{
    public class AccountViewModel
    {
        public int Id { get; set; }
        public int AccountTypeID { get; set; }
        public string AccountTypeName { get; set; }
        public int Active { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Info { get; set; }
        public DateTime CreatedTime { get; set; }
        public int IsActivated { get; set; }
        public string IdCardNumber { get; set; }
        public string CompanyNumber { get; set; }
        public string CompanyName { get; set; }
        public string CompanyInfo { get; set; }
        public string GoogleId { get; set; }
        public string FacebookId { get; set; }
        public string IDCardNumberPhoto1 { get; set; }
        public string IDCardNumberPhoto2 { get; set; }
        public DateTime? DoB { get; set; }
        public string Zipcode { get; set; }
        public string AddressCity { get; set; }
        public string AddressDistrict { get; set; }
        public string AddressWard { get; set; }
    }
}
