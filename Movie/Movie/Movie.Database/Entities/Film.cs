using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Database.Entities
{
    public class Film:BaseEntity
    {
        public string Title { get; set; } = null!;
        public int Year { get; set; }

        public int DirectorId { get; set; }
        public Director Director { get; set; } = null!;
    }
}
