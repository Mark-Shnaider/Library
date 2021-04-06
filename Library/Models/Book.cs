using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Vendor { get; set; }

        [Range(1600, 2021, ErrorMessage ="Недопустимая дата")]
        public int PublishDate { get; set; }

        [Range(1,1000,ErrorMessage = "Недопустимое количество")]
        public int Count { get; set; }
        public ICollection<Copy> Copies { get; set; }
    }
}
