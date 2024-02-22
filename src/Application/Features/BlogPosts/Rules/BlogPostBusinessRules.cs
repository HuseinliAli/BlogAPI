using Application.Repositories;
using Domain.Entities;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BlogPosts.Rules
{
    public class BlogPostBusinessRules(IBlogPostRepository blogPostRepository)
    {
        public async Task CheckBlogExists(int id)
        {
            BlogPost blogPost = await blogPostRepository.GetFirst(bp => bp.Id == id,false);
            if (blogPost is null)
                throw new NotFoundByIdException<int>(id);
        }

        public async Task InCreaseView(int id)
        {
            BlogPost blogPost = await blogPostRepository.GetFirst(bp => bp.Id == id, true);
            blogPost.ViewCount++;
            await blogPostRepository.SaveChangesAsync();
        }
    }
}
