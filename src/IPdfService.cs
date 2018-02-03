using System.IO;

namespace Kodiak.Facade.PdfSharp
{
    public interface IPdfService
    {
        /// <summary>
        /// Gets or sets the page template.
        /// </summary>
        /// <value>
        /// The page template.
        /// </value>
        string PageTemplate { get; set; }

        /// <summary>
        /// Draws the text in black arial font.
        /// </summary>
        /// <param name="textToDraw">The text to draw.</param>
        /// <param name="fontSize">Size of the font.</param>
        /// <param name="topLeftXCoordinate">The top left x coordinate.</param>
        /// <param name="topLeftYCoordinate">The top left y coordinate.</param>
        void DrawTextInBlackArialFont(string textToDraw, int fontSize, int topLeftXCoordinate, int topLeftYCoordinate);

        /// <summary>
        /// Gets the memory stream.
        /// </summary>
        /// <returns></returns>
        MemoryStream GetMemoryStream();
    }
}