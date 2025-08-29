using System.Threading.Tasks;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.Application.Interfaces.Menu
{
    public interface IMenuService
    {
        Task<CommandResult> GetMenuAsync();
    }
}
