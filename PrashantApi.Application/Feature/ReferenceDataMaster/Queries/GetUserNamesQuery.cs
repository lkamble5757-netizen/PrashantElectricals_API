using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using MediatR;
using PrashantApi.Application.DTOs.ReferenceDataMaster;

namespace PrashantApi.Application.Feature.ReferenceDataMaster.Queries
{
    public class GetUserNamesQuery : IRequest<List<UserDto>> { }
}
