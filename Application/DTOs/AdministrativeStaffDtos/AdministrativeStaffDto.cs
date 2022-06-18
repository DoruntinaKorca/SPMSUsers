using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.AdministrativeStaffDtos
{
    public class AdministrativeStaffDto
    {
        public Guid AdministrativeStaffId { get; set; }
        //  public virtual User User { get; set; }

        public string FirstName { get; set; }
        public string Surname { get; set; }
    }
}
