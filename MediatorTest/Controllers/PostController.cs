using System.Threading.Tasks;
using MediatorTest.Mediator.Request;
using MediatorTest.Mediator.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostController(IMediator mediator)
            => _mediator = mediator;


        [HttpGet("{id}")]
        public async Task<Post> GetPost(int id)
        {
            return await _mediator.Send(new PostRequest { Id = id });
        }
    }
}
