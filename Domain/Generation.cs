using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class Generation
    {
        [Key]
        public int GenerationId { get; set; }

        public String Name { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
