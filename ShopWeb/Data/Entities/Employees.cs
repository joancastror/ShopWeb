using ShopWeb.Data.Base;

namespace ShopWeb.Data.Entities
{
    public sealed class Employees : AuditEntity
    {
        public int empid { get; set; }
        public string lastname { get; set; }
        public string firstname { get; set; }
        public string title { get; set; }

    }
}
