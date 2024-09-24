using ShopWeb.Data.Base;

namespace ShopWeb.Data.Entities
{
    public sealed class Products : AuditEntity
    {
        public int productid { get; set; }
        public string productname { get; set; }
    }
}
