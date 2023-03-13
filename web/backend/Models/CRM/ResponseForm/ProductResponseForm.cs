using System;

namespace Novatic.Models.CRM.ResponseForm
{
    public class ProductResponseForm
    {
        public int Id { get; set; }    
        public int ShopId { get; set; }
        public string ShopName { get; set; }
        public int Quantity { get; set; }
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

        public ProductResponseForm(int id, int shopId, string shopName,int quantity ,int productTypeId, int productStatusId, int productCategoryId, int productBrandId, int productDiscountTypeId, string name, string origin, string description, int active, string photo, int price, string info, DateTime createdTime)
        {
            Id = id;
            ShopId = shopId;
            ShopName = shopName;
            Quantity = quantity;
            ProductTypeId = productTypeId;
            ProductStatusId = productStatusId;
            ProductCategoryId = productCategoryId;
            ProductBrandId = productBrandId;
            ProductDiscountTypeId = productDiscountTypeId;
            Name = name;
            Origin = origin;
            Description = description;
            Active = active;
            Photo = photo;
            Price = price;
            Info = info;
            CreatedTime = createdTime;
        }

        public ProductResponseForm()
        {
        }
    }
}
