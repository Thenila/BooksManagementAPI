using FastEndpoints;
using BookManagementAPI.Data;
using BookManagementAPI.Models;
using System.Threading.Tasks;
using System.Threading;

namespace BookManagementAPI.Endpoints
{
    public class UpdateBookRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public string ISBN { get; set; }  // Add ISBN property
    }

    public class UpdateBookEndpoint : Endpoint<UpdateBookRequest>
    {
        private readonly ApplicationDbContext _context;

        public UpdateBookEndpoint(ApplicationDbContext context)
        {
            _context = context;
        }

        public override void Configure()
        {
            Put("/books");
            AllowAnonymous();
        }

        public override async Task HandleAsync(UpdateBookRequest req, CancellationToken ct)
        {
            var book = await _context.Books.FindAsync(new object[] { req.Id }, ct);
            if (book != null)
            {
                book.Title = req.Title;
                book.Author = req.Author;
                book.PublicationYear = req.PublicationYear;
                book.ISBN = req.ISBN;  // Update ISBN property

                await _context.SaveChangesAsync(ct);
                await SendOkAsync(ct);
            }
            else
            {
                await SendNotFoundAsync(ct);
            }
        }
    }
}
