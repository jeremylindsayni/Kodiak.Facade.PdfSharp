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
        /// Gets or sets the page template.
        /// </summary>
        /// <value>
        /// The page template.
        /// </value>
        public string PageTemplate { get; set; }

        /// <summary>
        /// Gets or sets the memory stream.
        /// </summary>
        /// <value>
        /// The memory stream.
        /// </value>
        private MemoryStream MemoryStream { get; set; }

        /// <summary>
        /// Draws the text in black arial font.
        /// </summary>
        /// <param name="textToDraw">The text to draw.</param>
        /// <param name="fontSize">Size of the font.</param>
        /// <param name="topLeftXCoordinate">The top left x coordinate.</param>
        /// <param name="topLeftYCoordinate">The top left y coordinate.</param>
        public void DrawTextInBlackArialFont(string textToDraw, int fontSize, int topLeftXCoordinate, int topLeftYCoordinate)
        {
            var inputDocument1 = PdfReader.Open(this.PageTemplate, PdfDocumentOpenMode.Import);
            var document = new PdfDocument();
            var page = document.AddPage(inputDocument1.Pages[0]);
            var graphic = XGraphics.FromPdfPage(page);
            var xfont = new XFont(textToDraw, fontSize, XFontStyle.Regular);

            graphic.DrawString(textToDraw, xfont, XBrushes.Black, topLeftXCoordinate, topLeftYCoordinate);

            document.Save(this.MemoryStream, false);
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