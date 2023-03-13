using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Novatic.Models.CRM
{
    public partial class WarehouseMeta
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public int Active { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }

        public virtual Warehouse Warehouse { get; set; }
    }
}
