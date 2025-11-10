using Dapper;
using Microsoft.EntityFrameworkCore;
using PrashantApi.Application.Interfaces.InvoiceMaster;
using PrashantApi.Domain.Entities.InvoiceMaster;
using PrashantApi.Domain.Entities.JobEntry;
using PrashantApi.Domain.Entities.RepairWork;
using PrashantApi.Infrastructure.Connection;
using PrashantApi.Infrastructure.Data;
using PrashantEle.API.PrashantEle.Application.Common;
using PrashantEle.API.PrashantEle.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PrashantApi.Infrastructure.Repositories.InvoiceMaster
{
    public class InvoiceMasterRepository : IInvoiceMasterRepository
    {
        private readonly IDbConnectionString _dbConnectionString;

        public InvoiceMasterRepository(IDbConnectionString dbConnectionString)
        {
            _dbConnectionString = dbConnectionString;
        }


        public async Task<CommandResult> AddAsync(InvoiceMasterModel entity)
        {
            using var connection = _dbConnectionString.GetConnection();
            connection.Open();
            using var transaction = connection.BeginTransaction();

            try
            {
            
                var parameters = new DynamicParameters(new
                {
                    entity.Id,
                    entity.InvoiceNo,
                    entity.InvoiceDate,
                    entity.CustomerId,
                    entity.GstPercent,
                    entity.GstAmount,
                    entity.TotalAmount,
                    entity.IsActive,
                    entity.CreatedBy,
                    entity.CreatedOn,
                    entity.TransportCharges,
                    Mode = "INSERT"
                });

                var invoiceId = await connection.ExecuteScalarAsync<int>(
                    SqlConstants.InvoiceMaster.SaveInvoiceMaster,
                    parameters,
                    transaction,
                    commandType: CommandType.StoredProcedure
                );

                var tableJob = new DataTable();

                if (entity.JobDetails != null && entity.JobDetails.Any())
                {
                   
                    tableJob.Columns.Add("Id", typeof(int));
                    tableJob.Columns.Add("InvoiceId", typeof(int));
                    tableJob.Columns.Add("JobId", typeof(int));
                    tableJob.Columns.Add("WorkDone", typeof(string));
                    tableJob.Columns.Add("Total", typeof(decimal));
                    tableJob.Columns.Add("IsActive", typeof(bool));
                    tableJob.Columns.Add("CreatedBy", typeof(int));
                    tableJob.Columns.Add("CreatedOn", typeof(DateTime));

                    foreach (var job in entity.JobDetails)
                    {
                        tableJob.Rows.Add(
                            job.Id,
                            invoiceId,
                            job.JobId,
                            job.WorkDone,
                            job.Total,
                            job.IsActive,
                            entity.CreatedBy,
                            entity.CreatedOn
                        );
                    }

                    var dpJob = new DynamicParameters();
                    dpJob.Add("@InvoiceJobDetails", tableJob.AsTableValuedParameter("dbo.Type_InvoiceJobDetails"));
                    dpJob.Add("@Mode", "INSERT");

                    await connection.ExecuteAsync(
                        SqlConstants.InvoiceMaster.SaveInvoiceJobDetails,
                        dpJob,
                        transaction,
                        commandType: CommandType.StoredProcedure
                    );

                    // ✅ Save item details for each job
                    //foreach (var job in entity.JobDetails)
                    //{
                    //    if (job.ItemDetails != null && job.ItemDetails.Any())
                    //    {
                    //        var tableItem = new DataTable();
                    //        tableItem.Columns.Add("Id", typeof(int));
                    //        tableItem.Columns.Add("InvoiceDetailId", typeof(int)); // FK to Job
                    //        tableItem.Columns.Add("InvoiceId", typeof(int));
                    //        tableItem.Columns.Add("ItemId", typeof(int));
                    //        tableItem.Columns.Add("ItemQty", typeof(string));
                    //        tableItem.Columns.Add("Total", typeof(decimal));
                    //        tableItem.Columns.Add("IsActive", typeof(bool));
                    //        tableItem.Columns.Add("CreatedBy", typeof(int));
                    //        tableItem.Columns.Add("CreatedOn", typeof(DateTime));

                    //        foreach (var item in job.ItemDetails)
                    //        {
                    //            // ✅ ensure InvoiceId and InvoiceDetailId (Job) are linked
                    //            tableItem.Rows.Add(
                    //                0,
                    //                job.Id,             // <-- LINK each item to its JobDetail
                    //                invoiceId,
                    //                item.ItemId,
                    //                item.ItemQty,
                    //                item.Total,
                    //                true,
                    //                entity.CreatedBy,
                    //                entity.CreatedOn
                    //            );
                    //        }

                    //        var dpItem = new DynamicParameters();
                    //        dpItem.Add("@InvoiceItemDetails", tableItem.AsTableValuedParameter("dbo.Type_InvoiceItemDetails"));
                    //        dpItem.Add("@Mode", "INSERT");

                    //        await connection.ExecuteAsync(
                    //            SqlConstants.InvoiceMaster.SaveInvoiceItemDetails,
                    //            dpItem,
                    //            transaction,
                    //            commandType: CommandType.StoredProcedure
                    //        );
                    //    }
                    //}
                }

                transaction.Commit();
                return CommandResult.SuccessWithOutput(invoiceId);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return CommandResult.Fail(ex.Message);
            }
        }

        

        public async Task<CommandResult> UpdateAsync(InvoiceMasterModel entity)
        {
            using var connection = _dbConnectionString.GetConnection();
            connection.Open();

            try
            {
                
                var parameters = new DynamicParameters();
                parameters.Add("@Id", entity.Id);
                parameters.Add("@InvoiceNo", entity.InvoiceNo);
                parameters.Add("@InvoiceDate", entity.InvoiceDate);
                parameters.Add("@CustomerId", entity.CustomerId);
                parameters.Add("@GstPercent", entity.GstPercent);
                parameters.Add("@GstAmount", entity.GstAmount);
                parameters.Add("@TotalAmount", entity.TotalAmount);
                parameters.Add("@IsActive", entity.IsActive);
                parameters.Add("@ModifiedBy", entity.ModifiedBy);
                parameters.Add("@ModifiedOn", entity.ModifiedOn);
                parameters.Add("@TransportCharges", entity.TransportCharges);
                parameters.Add("@Mode", "UPDATE");

                await connection.ExecuteAsync(
                    SqlConstants.InvoiceMaster.SaveInvoiceMaster,
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                
                if (entity.JobDetails != null && entity.JobDetails.Any())
                {
                    var tableJob = new DataTable();
                    tableJob.Columns.Add("Id", typeof(int));
                    tableJob.Columns.Add("InvoiceId", typeof(int));
                    tableJob.Columns.Add("JobId", typeof(int));
                    tableJob.Columns.Add("WorkDone", typeof(string));
                    tableJob.Columns.Add("Total", typeof(decimal));
                    tableJob.Columns.Add("IsActive", typeof(bool));
                    tableJob.Columns.Add("ModifiedBy", typeof(int));
                    tableJob.Columns.Add("ModifiedOn", typeof(DateTime));

                    foreach (var job in entity.JobDetails)

                        tableJob.Rows.Add(
                            job.Id,
                            entity.Id,
                            job.JobId,
                            job.WorkDone,
                            job.Total,
                            job.IsActive,
                            entity.ModifiedBy, 
                            entity.ModifiedOn
                        );

                    var dpJob = new DynamicParameters();
                    dpJob.Add("@InvoiceJobDetails", tableJob.AsTableValuedParameter("dbo.Type_InvoiceJobDetails"));
                    dpJob.Add("@Mode", "UPDATE");

                    await connection.ExecuteAsync(
                        SqlConstants.InvoiceMaster.SaveInvoiceJobDetails,
                        dpJob,
                        commandType: CommandType.StoredProcedure
                    );

                    // ✅ Update Item Details (inside the same job loop)
                    //foreach (var job in entity.JobDetails)
                    //{
                    //    if (job.ItemDetails != null && job.ItemDetails.Any())
                    //    {
                    //        var tableItem = new DataTable();
                    //        tableItem.Columns.Add("Id", typeof(int));
                    //        tableItem.Columns.Add("InvoiceDetailId", typeof(int));
                    //        tableItem.Columns.Add("InvoiceId", typeof(int));
                    //        tableItem.Columns.Add("ItemId", typeof(int));
                    //        tableItem.Columns.Add("ItemQty", typeof(string));
                    //        tableItem.Columns.Add("Total", typeof(decimal));
                    //        tableItem.Columns.Add("IsActive", typeof(bool));
                    //        tableItem.Columns.Add("ModifiedBy", typeof(int));
                    //        tableItem.Columns.Add("ModifiedOn", typeof(DateTime));

                    //        foreach (var item in job.ItemDetails)
                    //        {
                    //            tableItem.Rows.Add(
                    //                item.Id,
                    //                job.Id, // link item to its job
                    //                entity.Id,
                    //                item.ItemId,
                    //                item.ItemQty,
                    //                item.Total,
                    //                item.IsActive,
                    //                entity.ModifiedBy ?? 0,
                    //                DateTime.Now
                    //            );
                    //        }

                    //        var dpItem = new DynamicParameters();
                    //        dpItem.Add("@InvoiceItemDetails", tableItem.AsTableValuedParameter("dbo.Type_InvoiceItemDetails"));
                    //        dpItem.Add("@Mode", "UPDATE");

                    //        await connection.ExecuteAsync(
                    //            SqlConstants.InvoiceMaster.SaveInvoiceItemDetails,
                    //            dpItem,
                    //            commandType: CommandType.StoredProcedure
                    //        );
                    //    }
                    //}
                }

                return CommandResult.Success;
            }
            catch (Exception ex)
            {
                return CommandResult.Fail(ex.Message);
            }
        }



        #region 📋 Get All
      
        public async Task<dynamic> GetAllAsync()
        {
            using var connection = _dbConnectionString.GetConnection();
            var result = await connection.QueryAsync<dynamic>(
                SqlConstants.InvoiceMaster.GetAllInvoiceMaster,
                commandType: CommandType.StoredProcedure
            );
            return result.ToList();
        }
        #endregion



       

        public async Task<dynamic> GetByIdAsync(int id)
        {
            using (var connection = _dbConnectionString.GetConnection())
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                using (var multi = await connection.QueryMultipleAsync(
                    SqlConstants.InvoiceMaster.GetInvoiceMasterById,
                    new { Id = id },
                    commandType: CommandType.StoredProcedure))
                {
                    // 1️⃣ Read master record
                    var master = await multi.ReadFirstOrDefaultAsync<dynamic>();
                    if (master == null)
                        return null;

                    // 2️⃣ Read job details linked by invoiceId
                    var jobs = (await multi.ReadAsync<dynamic>()).ToList();

                    // 3️⃣ Read item details linked by invoiceId
                    var items = (await multi.ReadAsync<dynamic>()).ToList();

                    // 4️⃣ Attach all item details for the same invoiceId
                    foreach (var job in jobs)
                    {
                        job.ItemDetails = items
                            .Where(i => i.InvoiceId == job.InvoiceId)
                            .ToList();
                    }

                    // 5️⃣ Attach all jobs to the master
                    master.JobDetails = jobs;

                    return master;
                }
            }
        }


        public async Task<dynamic> GetCustomerWiseRepairDataAsync(int customerId, int invoiceId)
        {
            using var connection = _dbConnectionString.GetConnection();
            if (connection.State == ConnectionState.Closed)
                connection.Open();

            var parameters = new DynamicParameters();
            SqlMapper.GridReader? multi = null;

            // for on customer change
            if (invoiceId == 0)
            {
                parameters.Add("@CustomerId", customerId, DbType.Int32);

                multi = await connection.QueryMultipleAsync(
                    SqlConstants.InvoiceMaster.GetCustomerWiseRepairData,
                    parameters,
                    commandType: CommandType.StoredProcedure
                );
            }
            else // for edit method
            {
                parameters.Add("@CustomerId", customerId, DbType.Int32);
                parameters.Add("@InvoiceId", invoiceId, DbType.Int32);

                multi = await connection.QueryMultipleAsync(
                    SqlConstants.InvoiceMaster.editInvoiceDetails,
                    parameters,
                    commandType: CommandType.StoredProcedure
                );
            }

            if (multi == null)
                return null;

         
            var jobs = (await multi.ReadAsync<dynamic>()).ToList();
            var repairWorks = (await multi.ReadAsync<dynamic>()).ToList();
            var repairWorkItems = (await multi.ReadAsync<dynamic>()).ToList();

            //  Map Items → RepairWork
            foreach (var rw in repairWorks)
            {
                int rwId = (int)rw.RepairWorkId;
                rw.Items = repairWorkItems
                    .Where(i => (int)i.RepairWorkId == rwId)
                    .ToList();
            }

            //  Map RepairWork → Job
            foreach (var job in jobs)
            {
                int jobId = (int)job.JobId;
                job.RepairWorks = repairWorks
                    .Where(rw => (int)rw.JobId == jobId)
                    .ToList();
            }

            //  Build final object
            var result = new
            {
                CustomerId = customerId,
                Jobs = jobs.Select(j => new
                {
                    j.JobId,
                    j.JobDocumentNo,
                    j.CustomerId,
                    RepairWorks = ((IEnumerable<dynamic>)j.RepairWorks).Select(rw => new
                    {
                        rw.RepairWorkId,
                        rw.RepairWorkNo,
                        rw.JobId,
                        rw.StartDate,
                        rw.CompletionDate,
                        rw.WorkDone,
                        rw.LabourCharges,
                        rw.TotalRepairWork,
                        Items = ((IEnumerable<dynamic>)rw.Items).Select(i => new
                        {
                            i.Id,
                            i.RepairWorkId,
                            i.ItemId,
                            i.ItemName,
                            i.ItemQty,
                            i.PricePerItem,
                            i.Total
                        }).ToList()
                    }).ToList()
                }).ToList()
            };

            return result;
        }

    }
}
