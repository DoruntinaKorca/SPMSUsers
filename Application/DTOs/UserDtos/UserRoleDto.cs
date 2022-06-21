using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.UserDtos
{
    public class UserRoleDto
    {
        public Guid RoleId { get; set; }
        public Guid UserId { get; set; }
    }
}
