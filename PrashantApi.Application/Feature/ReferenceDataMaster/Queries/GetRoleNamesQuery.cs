using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PrashantApi.Application.DTOs.ReferenceDataMaster;

namespace PrashantApi.Application.Feature.ReferenceDataMaster.Queries
{
    public class GetRoleNamesQuery : IRequest<List<RoleDto>> { }
}
