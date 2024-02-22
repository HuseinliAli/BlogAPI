using Application.Features.BlogPosts.Commands;
using Application.Features.BlogPosts.Queries;
using Application.Features.Blogs.Commands;
using Application.RequestShapers;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace WebApi.Controllers
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
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateBlogPostCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteBlogPostCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateBlogPostCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
