using System.Collections.Generic;
using System;

namespace Library.Models
{
    public class Reader
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<Copy> Copies { get; set; }

    }
}
