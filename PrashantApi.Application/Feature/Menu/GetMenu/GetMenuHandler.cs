using MediatR;
using PrashantApi.Application.Interfaces.Menu;
using PrashantEle.API.PrashantEle.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Application.Feature.Menu.GetMenu
{
    public class GetMenuHandler : IRequestHandler<GetMenuQuery, CommandResult>
    {
        private readonly IMenuService _service;

        public GetMenuHandler(IMenuService service)
        {
            _service = service;
        }

        public Task<CommandResult> Handle(GetMenuQuery request, CancellationToken cancellationToken)
        {
            return _service.GetMenuAsync();
        }
    }
}
