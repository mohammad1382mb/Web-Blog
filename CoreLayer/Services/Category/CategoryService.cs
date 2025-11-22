using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.DTOs.Category;
using CoreLayer.Services;
using DataLayer.Context;
using DataLayer.Entities;
using CoreLayer.Utilities;
using CoreLayer.Mappers;

namespace CoreLayer.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly BlogContext _context;

        public CategoryService(BlogContext context)
        {
            _context = context;
        }

        public OperationResult CreateCategory(CreateCategoryDto categoryDto)
        {
            if (IsSlugExsit(categoryDto.Slug))
            {
                return OperationResult.Error("متن وارد شده از قبل موجود است");
            }
            var category = new DataLayer.Entities.Category()
            {
                Title = categoryDto.Title,
                IsDelete = false,
                ParentId = categoryDto.ParentId,
                Slug = categoryDto.Slug.ToSlug(),
                MetaTag = categoryDto.MetaTag,
                MetaDescription = categoryDto.MetaDescription,
                CreationDate = DateTime.Now,
                
                
            };
            _context.Category.Add(category);
            _context.SaveChanges();
            return OperationResult.Success();
        }

        public OperationResult EditeCategory(EditeCategoryDto categoryDto)
        {
            var catrgory = _context.Category.FirstOrDefault(i => i.Id == categoryDto.Id);
            if (catrgory == null)
            {
                return OperationResult.NotFound();
            }
            if (categoryDto.Slug.ToSlug() != catrgory.Slug)
            {
                if (IsSlugExsit(categoryDto.Slug))
                {
                    return OperationResult.Error("متن وارد شده از قبل موجود است");
                }
            }
            catrgory.MetaDescription = categoryDto.MetaDescription;
            catrgory.MetaTag = categoryDto.MetaTag;
            catrgory.Slug = categoryDto.Slug.ToSlug();
            catrgory.Title = categoryDto.Title;
            _context.SaveChanges();
            return OperationResult.Success();
        }

        public List<CategoryDto> GetAllCategory()
        {
            return _context.Category.Select(category => CategoryMapper.Map(category)).ToList();
        }

        public CategoryDto GetCategoryById(int id)
        {
            var category =  _context.Category.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return null;
            }
            return CategoryMapper.Map(category);
        }

        public CategoryDto GetCategoryBySlug(string slug)
        {
            var category = _context.Category.FirstOrDefault(c => c.Slug == slug);
            if (category == null)
            {
                return null;
            }
            return CategoryMapper.Map(category);
        }

        public bool IsSlugExsit(string slug)
        {
            return _context.Category.Any(c => c.Slug == slug.ToSlug());
        }
    }
}
