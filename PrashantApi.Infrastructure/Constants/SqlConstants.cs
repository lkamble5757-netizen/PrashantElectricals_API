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

        public static class Estimate
        {
            public const string usp_Estimate = "dbo.usp_Estimate";
            public const string usp_EstimatedPartDetails = "dbo.usp_EstimatedPartDetails";
            public const string usp_GetAllEstimates = "dbo.usp_GetAllEstimates";
            public const string usp_GetEstimateById = "dbo.usp_GetEstimateById";
            public const string usp_GetJobNoByCustomerID = "dbo.usp_GetJobNoByCustomerID";
        }
        public static class RepairWork
        {
            // ✅ Existing stored procedures for main RepairWork table
            public const string SaveRepairWork = "dbo.usp_RepairWork";
            public const string GetAllRepairWork = "dbo.usp_GetAllRepairWork";
            public const string GetRepairWorkById = "dbo.usp_GetRepairWorkById";

            // ✅ New stored procedures for child RepairWorkItem table
            public const string SaveRepairWorkItem = "dbo.usp_SaveRepairWorkDetails";
           // public const string SaveRepairWorkDetails = "dbo.usp_SaveRepairWorkDetails";
           // public const string usp_GetRepairWorkItemsByRepairWorkId = "dbo.usp_GetRepairWorkDetailsById";
        }


public static class InvoiceMaster
        {
            // ✅ Stored procedure for main InvoiceMaster table
            public const string SaveInvoiceMaster = "dbo.usp_SaveInvoiceMaster";
            public const string GetAllInvoiceMaster = "dbo.usp_GetAllInvoiceMaster";
            public const string GetInvoiceMasterById = "dbo.usp_GetInvoiceMasterById";

            // ✅ Stored procedures for child InvoiceJobDetails
            public const string SaveInvoiceJobDetails = "dbo.usp_SaveInvoiceJobDetails";
          
            // ✅ Stored procedures for child InvoiceItemDetails
            public const string SaveInvoiceItemDetails = "dbo.usp_SaveInvoiceItemDetails";

            public const string GetCustomerWiseRepairData = "usp_GetCustomerWiseRepairData";


        }
    }
}
