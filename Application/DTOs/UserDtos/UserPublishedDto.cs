using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.UserDtos
{
    public class UserPublishedDto
    {
        public Guid Id { get; set; }

        public String Email { get; set; }

        public String Password { get; set; }

        public String Event { get; set; }

    }
}
