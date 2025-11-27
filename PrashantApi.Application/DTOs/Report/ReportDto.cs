using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrashantApi.Application.DTOs.CommonDTO;

namespace PrashantApi.Application.DTOs.InvoiceMaster
{
    public class ReportFilterDto 
    {
        public string CustId { get; set; } = "0";
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}


