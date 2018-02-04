# Kodiak.Facade.PdfSharp

Opinionated wrapper for the PdfSharpLibrary.  

The example below shows how to use with the .NET MVC framework. This example depends on [Kodiak.Mvc.Actions](https://github.com/jeremylindsayni/Kodiak.Mvc.Actions), and obviously the [PdfSharp](https://github.com/empira/PDFsharp) library.

```C#
public IPdfService PdfService { get; set; }

public HomeController()
{
    this.PdfService = new PdfService();
}

public ActionResult PdfDocumentStream()
{
    PdfService.SetPageTemplate(@"C:\Users\WebApplication\PdfTemplate.pdf");
    PdfService.DrawTextInBlackArialFont("Hello, World", 20, 350, 70);

    return new PdfStreamResult(PdfService.GetMemoryStream(), "report.pdf");
}
```
