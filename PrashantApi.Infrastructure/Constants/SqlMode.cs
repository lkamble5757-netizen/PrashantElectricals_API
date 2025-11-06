using System.ComponentModel;

namespace PrashantEle.API.PrashantEle.Infrastructure.Constants
{
    public enum SqlMode
    {
        [Description("insert")]
        Insert,
        [Description("update")]
        Update,
        [Description("delete")]
        Delete,
        [Description("select")]
        Select,
        [Description("all")]
        All,
        [Description("statusUpdate")]
        StatusUpdate
    }
    public enum PasswordMode
    {
        [Description("reset")]
        Reset,

    }

    //public partial class ClaimTypes
    //{
    //    public const string Id = "Id";
    //    public const string FirstName = "firstName";
    //    public const string LastName = "lastName";
    //    public const string Name = "name";
    //    public const string LoginId = "loginId";
    //    public const string Email = "email";
    //    public const string UserType = "userType";
    //    public const string AreaId = "areaId";
    //    public const string ReportingAuthorityId = "reportingAuthorityId";
    //    public const string Role = "role";
    //    public const string EmployeeCode = "employeeCode";
    //    public const string RoleIds = "roleIds";
    //    public const string Gender = "gender";
    //    public const string IsPasswordChanged = "isPasswordChanged";
    //    public const string PasswordChangedDate = "passwordChangedDate";
    //    public const string Identifier = "identifier";
    //    public const string Budget = "budget";
    //    public const string CurrentDate = "currentDate";
    //    public const string BranchCode = "BranchCode";
    //}
}
