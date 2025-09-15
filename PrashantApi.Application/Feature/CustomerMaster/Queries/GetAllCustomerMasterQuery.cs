using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PrashantApi.Application.DTOs.CustomerMaster;

namespace PrashantApi.Application.Feature.CustomerMaster.Queries
{
    public class GetAllCustomerMasterQuery : IRequest<List<CustomerMasterDto>>
    {
    }
}
