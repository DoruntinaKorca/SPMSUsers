﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class AdministrativeStaffDto
    {
        public Guid AdministrativeStaffId { get; set; }
      //  public virtual User User { get; set; }

        public String Name { get; set; }
        public String Surname { get; set; }
    }
}
