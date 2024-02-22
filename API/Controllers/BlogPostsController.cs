using Application.Features.BlogPosts.Queries;
using Application.Features.Blogs.Commands;
using Application.RequestShapers;
using Application.Utils.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace API.Controllers
{
    public class BlogPostsController : BaseApiController
    {
        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdBlogPostQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateBlogPostCommand command)
        {
            var id = await Mediator.Send(command);
            return Ok(id);
        }

        [HttpGet]
        public async Task<IActionResult> GetByPaginate([FromRoute] RequestParameters requestParameters)
        {
            var result = await Mediator.Send(new GetListBlogPostQuery() { PageSize=requestParameters.PageSize, PageNumber=requestParameters.PageNumber});
            Response.Headers.Add("blog-pagination",JsonSerializer.Serialize(result.MetaData));
            return Ok(result);
        }

    }
}
