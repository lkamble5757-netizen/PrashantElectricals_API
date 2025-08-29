using System.Threading.Tasks;
using PrashantApi.Application.Interfaces.Menu;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Infrastructure.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _repo;

        public MenuService(IMenuRepository repo)
        {
            _repo = repo;
        }

        public Task<CommandResult> GetMenuAsync()
        {
            return _repo.GetMenuListByLoginIdAsync();
        }
    }
}
