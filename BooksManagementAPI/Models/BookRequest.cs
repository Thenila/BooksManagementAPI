namespace BooksManagementAPI.Models
{
    public class BookRequest
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public string ISBN { get; set; }
    }
}
