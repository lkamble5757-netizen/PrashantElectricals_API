using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrashantApi.Application.DTOs.InvoiceMaster;
using System.Threading.Tasks;


namespace PrashantApi.Application.Interfaces.InvoiceMaster
{
    public interface IReportRepository
    {
        Task<dynamic> GetInvoiceReportAsync(string custId, DateTime fromDate, DateTime toDate);
    }
}


