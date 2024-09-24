using ShopWeb.Dtos;
using ShopWeb.Data.Context;
using ShopWeb.Data.Interfaces;

namespace ShopWeb.Data.Interfaces
{
    public interface ICategories
    {
        void SaveCategories(CategoriesAddDto addDto);
        void RemoveCategories(CategoriesRemoveDto removeDto);
        void UpdateCategories(CategoriesUpdateDto updateDto);
        List<CategoriesAddDto> GetCategories();
        CategoriesAddDto GetCategoriesById(int categoryid);
    }
}
