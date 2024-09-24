using ShopWeb.Data.Base;

namespace ShopWeb.Data.Entities
{
    public sealed class Customers : AuditEntity
    {
        public int custid { get; set; }
        public string companyname { get; set; }
        public string contactname { get; set; }
        public string contacttitle { get; set; }
    }
}
