using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Novatic.Models.CRM
{
    public partial class Product
    {
        public Product()
        {
            ProductItem = new HashSet<ProductItem>();
            ProductMeta = new HashSet<ProductMeta>();
        }

        public int Id { get; set; }
        public string GuId { get; set; }
        public int ShopId { get; set; }
        public int ProductTypeId { get; set; }
        public int ProductStatusId { get; set; }
        public int ProductCategoryId { get; set; }
        public int ProductBrandId { get; set; }
        public int ProductDiscountTypeId { get; set; }
        public string Name { get; set; }
        public string Origin { get; set; }
        public string Description { get; set; }
        public int Active { get; set; }
        public string Photo { get; set; }
        public int Price { get; set; }
        public string Info { get; set; }
        public DateTime CreatedTime { get; set; }

        public virtual ProductBrand ProductBrand { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ProductDiscountType ProductDiscountType { get; set; }
        public virtual ProductStatus ProductStatus { get; set; }
        public virtual ProductType ProductType { get; set; }
        public virtual ICollection<ProductItem> ProductItem { get; set; }
        public virtual ICollection<ProductMeta> ProductMeta { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<Cart> Cart { get; set; }
    }
}
