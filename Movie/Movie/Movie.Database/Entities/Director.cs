using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Database.Entities
{
    public class Director:BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<Film> Films { get; set; } = new List<Film>();
    }
}
