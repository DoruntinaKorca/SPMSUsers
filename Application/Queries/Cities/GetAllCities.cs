using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.Cities
{
    public class GetAllCities
    {
        public class Query : IRequest<List<CityDto>> 
        { 
        }
        public class Handler : IRequestHandler<Query, List<CityDto>>
        {
            public async Task<List<CityDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
