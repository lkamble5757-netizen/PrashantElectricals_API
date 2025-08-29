using System.Data;
using Dapper;
using Microsoft.Data.SqlClient; 
using PrashantApi.Application.Interfaces.Menu;
using PrashantEle.API.PrashantEle.Application.Common;
using PrashantEle.API.PrashantEle.Infrastructure.Connection;
using PrashantEle.API.PrashantEle.Infrastructure.Constants;
using PrashantApi.Application.Interfaces.Logging;
using PrashantEle.API.PrashantEle.Domain.DTO.MenuDetail;
using PrashantApi.Infrastructure.Common;
using Azure.Core;
using System.Security.Claims;
using System.Threading;
using PrashantApi.Infrastructure.Data;
//using ClaimTypes = PrashantEle.API.PrashantEle.Infrastructure.Constants.ClaimTypes;
//using ClaimTypes = PrashantEle.API.PrashantEle.Infrastructure.Constants.ClaimTypes;

namespace PrashantApi.Infrastructure.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly IDbConnectionString _dbConnectionString;
        private readonly ILog _log;
        private readonly IExecutionContext _context;
        private readonly ISqlServerDataAccess sqlServerDataAccess;


        public MenuRepository(IDbConnectionString dbConnectionString, ILog log,IExecutionContext context,ISqlServerDataAccess _sqlServerDataAccess)
        {
            _dbConnectionString = dbConnectionString;
            _log = log;
            _context = context;
            this.sqlServerDataAccess = _sqlServerDataAccess;

        }
        public async Task<CommandResult> GetMenuListByLoginIdAsync()
        {
            try
            {
                using var connection = _dbConnectionString.GetConnection();

                var menuDetails = (await connection.QueryAsync<MenuDetailDTO>(
                        SqlConstants.MenuDetails.usp_GetUserMenuDetail,
                        new { roleId = _context?.User?.FindFirst("RoleIds")?.Value },
                        commandType: CommandType.StoredProcedure)).ToList();



                // Parent -> Child (SubMenu)
                var mainMenu = menuDetails
                    .Where(x => x.ParentMenuId == 0 && x.IsActive) // root menus (no parent)
                    .OrderBy(x => x.Id) // or use Sequence column if added
                    .Select(c => new MenuList
                    {
                        Id = c.Id,
                        Title = c.MenuName,
                        Url = c.Url,
                        Icon = c.Icon,
                        CssClass = !string.IsNullOrEmpty(c.HCssClass) ? c.HCssClass : c.VCssClass,
                        ParentMenuId = c.ParentMenuId,
                        IsFinYearWiseMenuLock = c.IsFinYearWiseMenuLock,
                        IsActive = c.IsActive,
                        Sequence = c.Id, // or use Sequence column if added
                        SubMenu = BuildSubMenu(menuDetails, c.Id)
                    })
                    .ToList();

                return CommandResult.SuccessWithOutput(mainMenu);
            }
            catch (SqlException sqlEx)
            {
                _log.LogException(sqlEx);
                return CommandResult.Fail(sqlEx.Message);
            }
            catch (Exception ex)
            {
                _log.LogException(ex);
                return CommandResult.Fail("Failed to fetch menu.");
            }
        }

        private IEnumerable<MenuList> BuildSubMenu(IEnumerable<MenuDetailDTO> allMenus, int parentId)
        {
            return allMenus
                .Where(x => x.ParentMenuId == parentId && x.IsActive)
                .OrderBy(x => x.Id) // or Sequence if available
                .Select(s => new MenuList
                {
                    Id = s.Id,
                    Title = s.MenuName,
                    Url = s.Url,
                    Icon = s.Icon,
                    CssClass = !string.IsNullOrEmpty(s.HCssClass) ? s.HCssClass : s.VCssClass,
                    ParentMenuId = s.ParentMenuId,
                    IsFinYearWiseMenuLock = s.IsFinYearWiseMenuLock,
                    IsActive = s.IsActive,
                    Sequence = s.Id, // or Sequence
                    SubMenu = BuildSubMenu(allMenus, s.Id) // recursion for deeper levels
                })
                .ToList();
        }


    }
}
