using Application.Features.BlogPosts.Commands;
using Application.Features.BlogPosts.Queries;
using Application.Features.Blogs.Commands;
using Application.RequestShapers;
using Application.Utils.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace API.Controllers
{
    public class BlogPostsController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetByPaginate([FromRoute] RequestParameters requestParameters)
        {
            var result = await Mediator.Send(new GetListBlogPostQuery() { PageSize=requestParameters.PageSize, PageNumber=requestParameters.PageNumber });
            Response.Headers.Add("blog-pagination", JsonSerializer.Serialize(result.MetaData));
            return Ok(result);
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdBlogPostQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }
        [HttpPost("like")]
        public async Task<IActionResult> Like(LikeBlogPostCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
        [HttpPost("dislike")]
        public async Task<IActionResult> Dislike(DislikeBlogPostCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
       // [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateBlogPostCommand command)
        {
            var id = await Mediator.Send(command);
            return Ok(id);
        }
 
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteBlogPostCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }

      //  [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update([FromForm]UpdateBlogPostCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
    }
}
