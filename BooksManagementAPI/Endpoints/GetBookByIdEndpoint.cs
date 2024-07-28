using FastEndpoints;
using BookManagementAPI.Data;
using BookManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BookManagementAPI.Endpoints
{
    public class GetBookByIdEndpoint : EndpointWithoutRequest<Book>
    {
        private readonly ApplicationDbContext _context;

        public GetBookByIdEndpoint(ApplicationDbContext context)
        {
            _context = context;
        }

        public override void Configure()
        {
            Get("/books/{id:int}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var id = Route<int>("id");
            var book = await _context.Books.FindAsync(new object[] { id }, ct);
            if (book != null)
            {
                await SendAsync(book, cancellation: ct);
            }
            else
            {
                await SendNotFoundAsync(ct);
            }
        }
    }
}
