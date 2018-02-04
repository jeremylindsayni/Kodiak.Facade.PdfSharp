using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System.IO;

namespace Kodiak.Facade.PdfSharp
{
    public class PdfService : IPdfService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PdfService"/> class.
        /// </summary>
        public PdfService()
        {
            this.MemoryStream = new MemoryStream();
        }

        /// <summary>
        /// Sets the page template.
        /// </summary>
        /// <param name="pageTemplatePath">The page template path.</param>
        /// <exception cref="System.Exception">Pdf templates may only be a single page.</exception>
        public void SetPageTemplate(string pageTemplatePath)
        {
            this.PdfDocument = PdfReader.Open(pageTemplatePath, PdfDocumentOpenMode.Import);
            var document = new PdfDocument();

            if (this.PdfDocument.PageCount != 1)
            {
                throw new System.Exception("Pdf templates may only be a single page.");
            }

            this.PdfPage = document.AddPage(PdfDocument.Pages[0]);
            this.PdfDocument = document;
        }

        /// <summary>
        /// Gets or sets the PDF document.
        /// </summary>
        /// <value>
        /// The PDF document.
        /// </value>
        private PdfDocument PdfDocument { get; set; }

        /// <summary>
        /// Gets or sets the memory stream.
        /// </summary>
        /// <value>
        /// The memory stream.
        /// </value>
        private MemoryStream MemoryStream { get; set; }

        /// <summary>
        /// Gets or sets the PDF page.
        /// </summary>
        /// <value>
        /// The PDF page.
        /// </value>
        private PdfPage PdfPage { get; set; }

        /// <summary>
        /// Draws the text in black arial font.
        /// </summary>
        /// <param name="textToDraw">The text to draw.</param>
        /// <param name="fontSize">Size of the font.</param>
        /// <param name="topLeftXCoordinate">The top left x coordinate.</param>
        /// <param name="topLeftYCoordinate">The top left y coordinate.</param>
        public void DrawTextInBlackArialFont(string textToDraw, int fontSize, int topLeftXCoordinate, int topLeftYCoordinate)
        {
            var graphic = XGraphics.FromPdfPage(this.PdfPage);
            var xfont = new XFont(textToDraw, fontSize, XFontStyle.Regular);

            graphic.DrawString(textToDraw, xfont, XBrushes.Black, topLeftXCoordinate, topLeftYCoordinate);

            this.PdfDocument.Save(this.MemoryStream, false);
        }

        /// <summary>
        /// Gets the memory stream.
        /// </summary>
        /// <returns></returns>
        public MemoryStream GetMemoryStream()
        {
            return this.MemoryStream;
        }
    }
}