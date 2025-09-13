using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PrashantApi.Application.DTOs.ItemMaster;

namespace PrashantApi.Application.Feature.ItemMaster.Queries
{
    public class GetByIdItemMasterQuery : IRequest<ItemMasterDto>
    {
        public int Id { get; set; }
    }
}

