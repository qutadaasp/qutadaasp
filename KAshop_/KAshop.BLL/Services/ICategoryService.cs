using KAshop.DAL.DTO.Requests;
using KAshop.DAL.DTO.Responces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAshop.BLL.Services
{
    public interface ICategoryService
    {
        int CreateCategory(CategoryRequest request);
        IEnumerable<CategoryResponces> GetAllCategories();

        CategoryResponces ? GetCategoryByid(int id);

        int UpdateCategory (CategoryRequest request, int id);

        int DeleteCategory (int id);

        bool ToggleStatus(int id);
    }
}
