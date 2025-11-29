using CoreLayer.DTOs.Posts;
using CoreLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Services.Posts
{
    public interface IPostServices
    {
        OperationResult CreatePost(CreatePostDto postDto);
        OperationResult EditPost(EditPostDto postDto);
        PostDto GetPostById(int postId);
        bool IsSlugExsit(string slug);

    }
}
