using MediatorTest.Mediator.Response;
using MediatR;

namespace MediatorTest.Mediator.Request
{
    public class CommentRequest : IRequest<Comment>
    {
        public int Id { get; set; }
    }
}
