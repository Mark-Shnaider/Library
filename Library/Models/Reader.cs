using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Reader
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public ICollection<Copy> Copies { get; set; }

    }
}
