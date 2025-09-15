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
            public const string usp_GetRoleWiseMenuDetails = "dbo.usp_GetRoleWiseMenuDetail";
        }        
        public static class UserRegistration
        {
            //public const string usp_ItemMaster = "dbo.usp_ItemMaster";
            public const string usp_UserRegister = "dbo.usp_UserRegister";
        }
    }
}
