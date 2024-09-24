using ShopWeb.Data.Base;

namespace ShopWeb.Data.Entities
{
    public sealed class Suppliers : AuditEntity
    {
        public int supplierid { get; set; }
        public string city { get; set; }
        public string region { get; set; }
    }
}
