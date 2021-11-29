using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MediatorTest.Mediator.Response;
using MediatR;

namespace MediatorTest.Mediator.Request
{
    public class PostRequest : IRequest<Post>
    {
        public int Id { get; set; }
    }
}
