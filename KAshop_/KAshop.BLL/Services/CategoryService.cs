using KAshop.DAL.CategoryRepository;
using KAshop.DAL.DTO.Requests;
using KAshop.DAL.DTO.Responces;
using KAshop.DAL.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAshop.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository )
        {
            this.categoryRepository = categoryRepository;
        }
        public int CreateCategory(CategoryRequest request)
        {
            var category = request.Adapt<Category>();

            return categoryRepository.Add(category);
        }

        public int DeleteCategory(int id)
        {
            var category = categoryRepository.GetById(id);
            if (category is null) return 0;

            return categoryRepository.Remove(category);
            
        }

        public IEnumerable<CategoryResponces> GetAllCategories()
        {
           var categories = categoryRepository.GetAll();
            return categories.Adapt<IEnumerable<CategoryResponces>>();
        }

        public CategoryResponces? GetCategoryByid(int id)
        {
            var categories = categoryRepository.GetById(id);
            return categories is null ? null : categories.Adapt<CategoryResponces>();
        }

        public int UpdateCategory(CategoryRequest request, int id)
        {
            var category = categoryRepository.GetById(id);

            if (category is null) return 0;

            return categoryRepository.Update(category);
        }

        public bool ToggleStatus(int id)
        {
            var category = categoryRepository.GetById(id);
            if(category is null) return false;

            category.status = category.status == Status.Active ? Status.Inactive : Status.Active;
            categoryRepository.Update(category);
            return true;
        }
    }
}
