
using iText.Html2pdf;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace PrashantApi.Application.Services
{
    public enum DocumentType { Challan, Invoice, IOCD }
    public enum PageSize { A4 }
    public class PdfService
    {
        public byte[] GeneratePdf(DocumentType documentType, string htmlContent, string fileName, PageSize pageSize, bool isLandscape, bool includeHeaderFooter)
        {
            using var memoryStream = new MemoryStream();
            HtmlConverter.ConvertToPdf(htmlContent, memoryStream);
            return memoryStream.ToArray();
        }
       
    }
}


