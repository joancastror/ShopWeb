using ShopWeb.Data.Context;
using ShopWeb.Data.Entities;
using ShopWeb.Data.Exceptions;
using ShopWeb.Data.Interfaces;
using ShopWeb.Dtos;
using System.Linq.Expressions;

namespace ShopWeb.Data.Daos
{
    public class DaoCategories : ICategories
    {
        private readonly ShopDbContext CategoriesDb;
        private readonly ILogger<DaoCategories> logger;

        public DaoCategories(ShopDbContext CategoriesDb, ILogger<DaoCategories> logger)
        {
            this.CategoriesDb = CategoriesDb;
            this.logger = logger;
        }
        public List<CategoriesAddDto> GetCategories()
        {
            List<CategoriesAddDto> categories = new List<CategoriesAddDto>();
            try
            {
                var query = (from depto in this.CategoriesDb.Categories where depto.deleted == false select new CategoriesAddDto()
                {
                    categoryid = depto.categoryid,
                    categoryname = depto.categoryname,
                    description = depto.description,
                    creation_date = depto.creation_date,
                    creation_user = depto.creation_user,
                }).ToList();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error obteniendo las tiendas", ex.ToString());
            }
            return categories;
        }

        public CategoriesAddDto GetCategoriesById(int categoryid)
        {
            CategoriesAddDto categoriesresult = new CategoriesAddDto();
            try
            {
                var categories = this.CategoriesDb.Categories.Find(categoryid);
                if (categories is null)
                    throw new CategoriesException("La Categoria no se encuentra registrada");
                categoriesresult.categoryid = categories.categoryid;
                categoriesresult.categoryname = categories.categoryname;
                categoriesresult.description = categories.description;
                categoriesresult.creation_date = categories.creation_date;
                categoriesresult.creation_user = categories.creation_user;

            }
            catch (Exception ex)
            {
                this.logger.LogError("Error obteniendo las categorias", ex.ToString());
            }
            return categoriesresult;
        }

        public void RemoveCategories(CategoriesRemoveDto removeDto)
        {
            try
            {
                if (removeDto is null)
                    throw new CategoriesException("El objeto deparmento no puede ser nulo.");


                var categories = this.CategoriesDb.Categories.Find(removeDto.categoryid);

                if (categories is null)
                    throw new CategoriesException("El deparmento no se encuentra registrado.");

                categories.deleted = true;
                categories.delete_user = removeDto?.delete_user;
                categories.delete_date = removeDto?.delete_date;

            }
            catch (Exception ex)
            {
                this.logger.LogError("Error removiendo el departamento", ex.ToString());

            }
            
        }
        public void SaveCategories(CategoriesAddDto addDto)
        {
            try
            {
                if (addDto is null)
                    throw new CategoriesException("El objeto deparmento no puede ser nulo.");

                if (this.CategoriesDb.Categories.Any(depto => depto.categoryname == addDto.categoryname))
                    throw new CategoriesException("El objeto deparmento no puede ser nulo.");


                Categories categories = new Categories()
                {
                    categoryid = addDto.categoryid,
                    categoryname = addDto.categoryname,
                    description = addDto.description,
                    creation_date = addDto.creation_date,
                    creation_user = addDto.creation_user,


                };
                this.CategoriesDb.Categories.Add(categories);
                this.CategoriesDb.SaveChanges();
            }
            catch (Exception ex)
            {

                this.logger.LogError("Error guardando el departamento", ex.ToString());

            }

        }
        public void UpdateCategories(CategoriesUpdateDto updateDto)
        {
            try
            {
                if (updateDto is null)
                    throw new CategoriesException("El objeto deparmento no puede ser nulo.");


                Categories categories = this.CategoriesDb.Categories.Find(updateDto.categoryid);


                if (categories is null)
                    throw new CategoriesException("El deparmento no se encuentra registrado.");

                categories.categoryid = updateDto.categoryid;
                categories.categoryname = updateDto.categoryname;
                categories.description = updateDto.description;
                categories.creation_date = updateDto.creation_date;
                categories.creation_user = updateDto.creation_user;

                this.CategoriesDb.Categories.Update(categories);
                this.CategoriesDb.SaveChanges();

            }
            catch (Exception ex)
            {

                this.logger.LogError("Error actualizando el departamento", ex.ToString());

            }

        }
    } 
}
