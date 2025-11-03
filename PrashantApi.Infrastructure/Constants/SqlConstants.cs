namespace PrashantEle.API.PrashantEle.Infrastructure.Constants
{
    public static class SqlConstants
    {
        public static class ItemMaster
        {
            public const string ItemMasterr = "dbo.usp_SaveItem";
            public const string GetAllItemMaster = "dbo.usp_GetAllItemMaster";
            public const string GetItemMasterById = "dbo.usp_GetItemMasterById";
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

        public static class CustomerMaster
        {
            public const string CustomerMasterr = "dbo.usp_SaveCustomerMaster";
            public const string GetAllCustomerMaster = "dbo.usp_GetAllCustomerMaster";
            public const string GetCustomerMasterById = "dbo.usp_GetCustomerMasterById";
        }


        public static class RoleMaster
        {
            public const string RoleMasterr = "dbo.usp_SaveRoleMaster";
            public const string GetAllRoles = "dbo.usp_GetAllRoles";
            public const string GetRoleById = "dbo.usp_GetRoleById";
        }

        public static class RoleWiseMenuMaster
        {
            public const string RoleWiseMenuMasterr = "dbo.usp_SaveRoleWiseMenuMaster";
            public const string GetAllRoleWiseMenuMasters = "dbo.usp_GetAllRoleWiseMenuMasters";
            public const string GetRoleWiseMenuMasterById = "dbo.usp_GetRoleWiseMenuMasterById";
        }

        public static class MachineMaster
        {
            public const string MachineMasterr = "dbo.usp_SaveMachineMaster";
            public const string GetAllMachineMaster = "dbo.usp_GetAllMachines";
            public const string GetMachineMasterById = "dbo.usp_GetMachineById";
        }


        public static class UserRoleAssignMaster
        {
            public const string UserRoleAssignMasterr = "dbo.usp_SaveUserRoleAssignMaster";
            public const string GetAllUserRoleAssignMasters = "dbo.usp_GetAllUserRoleAssignMasters";
            public const string GetUserRoleAssignMasterById = "dbo.usp_GetUserRoleAssignMasterById";
        }

        public static class JobEntry
        {
            public const string JobEntryMaster = "dbo.usp_JobEntry";
            public const string GetAllJobEntries = "dbo.usp_GetAllJobEntries";
            public const string GetJobEntryById = "dbo.usp_GetJobEntryById";
        }

        public static class Estimate
        {
            public const string EstimateMaster = "dbo.usp_Estimate";
            public const string EstimatedPartDetails = "dbo.usp_EstimatedPartDetails";
            public const string GetAllEstimateMaster = "dbo.usp_GetAllEstimates";
            public const string GetEstimatedCustomer = "dbo.usp_GetEstimatedCustomer";
            public const string GetEstimateMasterById = "dbo.usp_GetEstimateById";
            public const string GetJobNoByCustomerID = "dbo.usp_GetJobNoByCustomerID";
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
            public const string editInvoiceDetails = "usp_editInvoiceDetails";

        }
    }
}
