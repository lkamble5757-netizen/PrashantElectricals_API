
using iText.Html2pdf;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using ZXing;
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
        public byte[] GenerateBarcode(string text)
        {

            var barcodeWriter = new BarcodeWriterPixelData
            {
                Format = BarcodeFormat.CODE_128,
                Options = new ZXing.Common.EncodingOptions
                {
                    Height = 50,
                    Width = 300,
                    Margin = 1
                }
            };
            var pixelData = barcodeWriter.Write(text);
            using var bitmap = new Bitmap(pixelData.Width, pixelData.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, pixelData.Width, pixelData.Height),
                System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            try
            {
                System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0, pixelData.Pixels.Length);
            }
            finally
            {
                bitmap.UnlockBits(bitmapData);
            }
            using var ms = new MemoryStream();
            bitmap.Save(ms, ImageFormat.Png); return ms.ToArray();
        }
    }
}


