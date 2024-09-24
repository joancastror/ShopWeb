using ShopWeb.Data.Base;

namespace ShopWeb.Data.Entities
{
    public sealed class Categories : AuditEntity
    {
        public int categoryid { get; set; }
        public string categoryname { get; set; }
        public string description { get; set; }

    }
}
