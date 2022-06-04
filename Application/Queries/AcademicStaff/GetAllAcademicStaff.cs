﻿using Application.DTOs;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.AcademicStaff
{
    public class GetAllAcademicStaff
    {
        public class Query : IRequest<List<AcademicStaffDto>>
        { }
        public class Handler : IRequestHandler<Query, List<AcademicStaffDto>>
        {
            private readonly IMapper _mapper;
            private readonly UsersContext _context;

            public Handler(IMapper mapper, UsersContext context)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<List<AcademicStaffDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var academicStaff = await _context.AcademicStaffs
                   .Include(a=>a.AcademicLevel)
                   .Include(a => a.User)
                   .ToListAsync();

                var result = _mapper.Map<List<AcademicStaffDto>>(academicStaff);

                return result;
            }
        }
    }
}