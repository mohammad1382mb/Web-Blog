using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.DTOs.Category;
using CoreLayer.Utilities;

namespace CoreLayer.Services.Category
{
    public interface ICategoryService
    {
        public OperationResult CreateCategory(CreateCategoryDto categoryDto);
        public OperationResult EditeCategory(EditeCategoryDto categoryDto);
        public List<CategoryDto> GetAllCategory();
        public CategoryDto GetCategoryById(int id);
        public CategoryDto GetCategoryBySlug(string slug);
        public bool IsSlugExsit(string slug);
       
    }

}
