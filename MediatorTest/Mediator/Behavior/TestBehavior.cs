using System;
using System.Threading;
using System.Threading.Tasks;
using MediatorTest.Mediator.Request;
using MediatorTest.Mediator.Response;
using MediatR;

namespace MediatorTest.Mediator.Behavior
{
    public class TestBehavior : IPipelineBehavior<PostRequest, Post>
    {
        public async Task<Post> Handle(PostRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<Post> next)
        {
            Post post =  await next();
            post.Body += "BAbaba";
            return post;
        }
    }
}
