//using System;
//using System.IO;
//using System.Text;
//using Syncfusion.Drawing;
//using Syncfusion.Pdf;
//using Syncfusion.Pdf.Graphics;
//using Syncfusion.Pdf.Grid;
//using iText.Signatures.Validation.Report;
//using Microsoft.AspNetCore.Hosting;


//namespace AdministradorAmet.Models
//{
//    public class ExportService
//    {
//        private readonly IWebHostEnvironment _hostingEnvironment;

//        public ExportService(IWebHostEnvironment hostingEnvironment)
//        {
//            _hostingEnvironment = hostingEnvironment;
//        }

//        public MemoryStream CrearPDF(List<ReporteItem> items)
//        {
//            PdfDocument document = new PdfDocument();
//            PdfPage currentPage = document.Pages.Add();
//            PdfGraphics graphics = currentPage.Graphics;
//            SizeF clientSize = currentPage.GetClientSize();

//            // Logo
//            var logoPath = Path.Combine(_hostingEnvironment.WebRootPath, "logo.png");
//            if (File.Exists(logoPath))
//            {
//                using var imageStream = new FileStream(logoPath, FileMode.Open, FileAccess.Read);
//                PdfImage logo = new PdfBitmap(imageStream);
//                graphics.DrawImage(logo, new PointF(14, 13), new SizeF(40, 40));
//            }

//            // Encabezado
//            PdfFont fontBold20 = new PdfStandardFont(PdfFontFamily.Helvetica, 20, PdfFontStyle.Bold);
//            PdfFont font10 = new PdfStandardFont(PdfFontFamily.Helvetica, 10);
//            PdfFont fontBold10 = new PdfStandardFont(PdfFontFamily.Helvetica, 10, PdfFontStyle.Bold);

//            var headerText = new PdfTextElement("Reporte de Multas", fontBold20, new PdfSolidBrush(Color.FromArgb(0, 0, 0)));
//            headerText.StringFormat = new PdfStringFormat(PdfTextAlignment.Right);
//            var result = headerText.Draw(currentPage, new PointF(clientSize.Width - 25, 20));

//            // Tabla
//            PdfGrid grid = new PdfGrid();
//            grid.Columns.Add(4);
//            grid.Headers.Add(1);
//            PdfGridRow header = grid.Headers[0];
//            header.Cells[0].Value = "Descripción";
//            header.Cells[1].Value = "Cantidad";
//            header.Cells[2].Value = "Precio Unitario";
//            header.Cells[3].Value = "Total";

//            PdfStringFormat rightAlign = new PdfStringFormat(PdfTextAlignment.Right);
//            PdfFont fontTable = new PdfStandardFont(PdfFontFamily.Helvetica, 10);
//            grid.Style.Font = fontTable;

//            decimal totalGeneral = 0;
//            foreach (var item in items)
//            {
//                var row = grid.Rows.Add();
//                row.Cells[0].Value = item.Descripcion;
//                row.Cells[1].Value = item.Cantidad.ToString();
//                row.Cells[2].Value = item.PrecioUnitario.ToString("C");
//                decimal total = item.Cantidad * item.PrecioUnitario;
//                row.Cells[3].Value = total.ToString("C");
//                totalGeneral += total;
//            }

//            result = grid.Draw(currentPage, new PointF(14, result.Bounds.Bottom + 30));

//            // Total general
//            var totalText = new PdfTextElement($"Total General: {totalGeneral:C}", fontBold10);
//            totalText.Draw(currentPage, new PointF(14, result.Bounds.Bottom + 10));

//            // Finalizar documento
//            MemoryStream stream = new MemoryStream();
//            document.Save(stream);
//            document.Close(true);
//            stream.Position = 0;
//            return stream;
//        }
//    }

//    public class ReporteItem
//    {
//        public string Descripcion { get; set; }
//        public int Cantidad { get; set; }
//        public decimal PrecioUnitario { get; set; }
//    }

//}
