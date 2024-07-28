﻿namespace BooksManagementAPI.Models
{
    public class BookResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public string ISBN { get; set; }
    }
}
