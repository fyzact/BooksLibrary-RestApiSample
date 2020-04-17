using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiSample.Models.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual Author Author { get; set; }
        public virtual Guid AuthorId { get; set; }
    }
}
