using CoreLayer.DTOs.Posts;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Mappers
{
    public class PostMapper
    {
        public static Post MapCreateDtoToPost(CreatePostDto dto)
        {
            return new Post()
            {
                Description = dto.Description,
                CategoryId = dto.CategoryId,
                Slug = dto.Slug,
                Title = dto.Slug,
                UserId = dto.UserId,
                Visit = 0,
                IsDelete = false
            };
        }

        public static Post MapEditDtoToPost(EditPostDto dto,Post post)
        {
            post.Description = dto.Description;
            post.Title = dto.Title;
            post.Slug = dto.Slug;
            post.CategoryId = dto.CategoryId;
            return post;
              
           
        }

        public static PostDto MapToPostDto(Post post)
        {
            return new PostDto()
            {
                Description = post.Description,
                CategoryId = post.CategoryId,
                Slug = post.Slug,
                Title = post.Slug,
                UserId = post.UserId,
                Visit = post.Visit,
                CreationDate = post.CreationDate,
                Category = CategoryMapper.Map(post.Category),
                ImageName = post.ImageName,
                PostId = post.Id,
            };
        }
    }
}
