using CoreLayer.DTOs.Category;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Mappers
{
    public class CategoryMapper
    {
        public static CategoryDto Map(Category category)
        {
            return new CategoryDto()
            {
                MetaDescription = category.MetaDescription,
                MetaTag = category.MetaTag,
                Slug = category.Slug,
                ParentId = category.ParentId,
                Id = category.Id,
                Title = category.Title,
            };
        }
    }
}
