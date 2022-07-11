using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.UserDtos
{
    public class DeleteUserPublishedDto
    {
        public Guid Id { get; set; }

        public string Event { get; set; }
    }
}
