using CoreLayer.DTOs.Posts;
using CoreLayer.Mappers;
using CoreLayer.Utilities;
using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Services.Posts
{
    public class PostServices : IPostServices
    {
        private readonly BlogContext _context;

        public PostServices(BlogContext context)
        {
            _context = context;
        }

        public OperationResult CreatePost(CreatePostDto postDto)
        {
            var post = PostMapper.MapCreateDtoToPost(postDto);
            _context.Post.Add(post);
            _context.SaveChanges();
            return OperationResult.Success();
        }

        public OperationResult EditPost(EditPostDto postDto)
        {
            var post = _context.Post.FirstOrDefault(i => i.Id == postDto.PostId);
            if (post == null)
            {
                return OperationResult.NotFound();
            }
            post = PostMapper.MapEditDtoToPost(postDto,post);
            _context.Post.Update(post);
            _context.SaveChanges();
            return OperationResult.Success();

        }

        public PostDto GetPostById(int postId)
        {

            var post = _context.Post.FirstOrDefault(i => i.Id == postId);
            return PostMapper.MapToPostDto(post);
        }

        public bool IsSlugExsit(string slug)
        {
            return _context.Post.Any(p => p.Slug == slug.ToSlug());
        }
    }
}
