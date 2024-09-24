using ShopWeb.Data.Base;

namespace ShopWeb.Data.Entities
{
    public sealed class Shippers : AuditEntity
    {
        public int shipperid { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
    }
}
