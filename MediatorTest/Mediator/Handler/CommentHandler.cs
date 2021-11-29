using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MediatorTest.Mediator.Request;
using MediatorTest.Mediator.Response;
using MediatR;

namespace MediatorTest.Mediator.Handler
{
    public class CommentHandler : IRequestHandler<CommentRequest, Comment>
    {
        private readonly HttpClient _httpClient;

        public CommentHandler(IHttpClientFactory factory)
            => _httpClient = factory.CreateClient("Comment");
        public async Task<Comment> Handle(CommentRequest request, CancellationToken cancellationToken)
        {
            HttpResponseMessage msg = await _httpClient.GetAsync($"{request.Id}");
            string response = await msg.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Comment>(Encoding.UTF8.GetBytes(response),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
