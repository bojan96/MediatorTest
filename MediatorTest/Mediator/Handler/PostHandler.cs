using System;
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
    public class PostHandler : IRequestHandler<PostRequest, Post>
    {
        private readonly HttpClient _httpClient;

        public PostHandler(IHttpClientFactory factory)
            => _httpClient = factory.CreateClient("Post");

        public async Task<Post> Handle(PostRequest request, CancellationToken cancellationToken)
        {
            HttpResponseMessage msg = await _httpClient.GetAsync($"{request.Id}");
            string response = await msg.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Post>(Encoding.UTF8.GetBytes(response), 
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true});
        }
    }
}
