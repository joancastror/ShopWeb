﻿namespace ShopWeb.Dtos
{
    public class CategoriesRemoveDto
    {
        public int categoryid { get; set; }
        public int? delete_user { get; set; }
        public DateTime? delete_date { get; set; }
        public bool deleted { get; set; }
    }
}
