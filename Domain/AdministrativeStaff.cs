using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class AdministrativeStaff
    {
     //   [Key] me bo lidhjen me user
        public Guid AdministrativeStaffId { get; set; }
        public virtual User User { get; set; }
    }
}
