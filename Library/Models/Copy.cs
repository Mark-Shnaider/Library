using System;

namespace Library.Models
{
    public class Copy
    {
        public int Id { get; set; }
        public DateTime Issue_Date { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int ReaderId { get; set; }
        public Reader Reader { get; set; }
    }
}
