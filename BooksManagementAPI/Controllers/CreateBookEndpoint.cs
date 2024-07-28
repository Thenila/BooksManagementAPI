using FastEndpoints;
using BookManagementAPI.Data;
using BookManagementAPI.Models;
using System.Threading.Tasks;
using System.Threading;

namespace BookManagementAPI.Endpoints
{
    public class CreateBookRequest
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public string ISBN { get; set; }  // Add ISBN property
    }

    public class CreateBookEndpoint : Endpoint<CreateBookRequest, Book>
    {
        private readonly ApplicationDbContext _context;

        public CreateBookEndpoint(ApplicationDbContext context)
        {
            _context = context;
        }

        public override void Configure()
        {
            Post("/books");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CreateBookRequest req, CancellationToken ct)
        {
            var newBook = new Book
            {
                Title = req.Title,
                Author = req.Author,
                PublicationYear = req.PublicationYear,
                ISBN = req.ISBN  // Set ISBN property
            };

            _context.Books.Add(newBook);
            await _context.SaveChangesAsync(ct);

            await SendAsync(newBook, cancellation: ct);
        }
    }
}
