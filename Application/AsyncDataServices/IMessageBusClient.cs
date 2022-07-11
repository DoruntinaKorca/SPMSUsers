using Application.DTOs.AcademicStaffDtos;
using Application.DTOs.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AsyncDataServices
{
    public interface IMessageBusClient
    {
        void PublishNewAcademicStaff(AcademicStaffPublishedDto academicStaffPublishedDto);


        void PublishNewUser(UserPublishedDto userPublishedDto);

        void DeletUser(DeleteUserPublishedDto deleteUserPublishedDto);
    }
}
