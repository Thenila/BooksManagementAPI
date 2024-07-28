using FastEndpoints;
using BookManagementAPI.Data;
using BookManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BookManagementAPI.Endpoints
{
    public class DeleteBookEndpoint : EndpointWithoutRequest
    {
        private readonly ApplicationDbContext _context;

        public DeleteBookEndpoint(ApplicationDbContext context)
        {
            _context = context;
        }

        public override void Configure()
        {
            Delete("/books/{id:int}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var id = Route<int>("id");
            var book = await _context.Books.FindAsync(new object[] { id }, ct);
            if (book == null)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync(ct);
            await SendNoContentAsync(ct);
        }
    }
}
