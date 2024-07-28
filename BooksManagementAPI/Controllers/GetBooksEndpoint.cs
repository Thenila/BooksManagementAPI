using FastEndpoints;
using BookManagementAPI.Data;
using BookManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookManagementAPI.Endpoints
{
    public class GetBooksEndpoint : EndpointWithoutRequest<List<Book>>
    {
        private readonly ApplicationDbContext _context;

        public GetBooksEndpoint(ApplicationDbContext context)
        {
            _context = context;
        }

        public override void Configure()
        {
            Get("/books");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var query = _context.Books.AsQueryable();

            // Retrieve query parameters from HttpContext
            var author = HttpContext.Request.Query["author"].ToString();
            var year = HttpContext.Request.Query["year"].ToString();

            if (!string.IsNullOrEmpty(author))
            {
                query = query.Where(b => b.Author.Contains(author));
            }

            if (!string.IsNullOrEmpty(year) && int.TryParse(year, out var publicationYear))
            {
                query = query.Where(b => b.PublicationYear == publicationYear);
            }

            var books = await query.ToListAsync(ct);
            await SendAsync(books, cancellation: ct);
        }
    }
}
