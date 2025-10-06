namespace PrashantEle.API.PrashantEle.Infrastructure.Constants
{
    public static class SqlConstants
    {
        public static class ItemMaster
        {
            //public const string usp_ItemMaster = "dbo.usp_ItemMaster";
            public const string usp_ItemMaster = "dbo.usp_AreaMaster";
            public const string usp_SaveItem = "dbo.usp_SaveItem";
        }    
        public static class UserMaster
        {
            //public const string usp_ItemMaster = "dbo.usp_ItemMaster";
            public const string usp_GetLoginInfo = "dbo.usp_GetLoginInfo";
        }
        public static class MenuDetails
        {
            //public const string usp_ItemMaster = "dbo.usp_ItemMaster";
            public const string usp_GetUserMenuDetail = "dbo.usp_GetUserMenuDetail";
            public const string usp_GetRoleWiseMenuDetails = "dbo.usp_GetRoleWiseMenuDetails";
        }        
        public static class UserRegistration
        {
            //public const string usp_ItemMaster = "dbo.usp_ItemMaster";
            public const string usp_UserRegister = "dbo.usp_UserRegister";
        }

        public static class RoleWiseMenuMaster
        {
            public const string usp_SaveRoleWiseMenuMaster = "dbo.usp_SaveRoleWiseMenuMaster";
            public const string usp_GetAllRoleWiseMenuMasters = "dbo.usp_GetAllRoleWiseMenuMasters";
            public const string usp_GetRoleWiseMenuMasterById = "dbo.usp_GetRoleWiseMenuMasterById";
        }

        public static class UserRoleAssignMaster
        {
            public const string usp_SaveUserRoleAssignMaster = "dbo.usp_SaveUserRoleAssignMaster";
            public const string usp_GetAllUserRoleAssignMasters = "dbo.usp_GetAllUserRoleAssignMasters";
            public const string usp_GetUserRoleAssignMasterById = "dbo.usp_GetUserRoleAssignMasterById";
        }

        public static class JobEntry
        {
            public const string usp_JobEntry = "dbo.usp_JobEntry";
            public const string usp_GetAllJobEntries = "dbo.usp_GetAllJobEntries";
            public const string usp_GetJobEntryById = "dbo.usp_GetJobEntryById";
        }

    }
}
