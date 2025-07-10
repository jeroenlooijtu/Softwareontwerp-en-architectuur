namespace Softwareontwerp_en_architectuur.Domain.Factory;

public class RapportageFactory
{
    public RapportageFactory()
    {
        
    }

    public PngRapportage CreatePngRapportage(Sprint sprint, string header, string footer)
    {
        return new PngRapportage(footer, header, sprint);
    }
    
    public PdfRapportage CreatePdfRapportage(Sprint sprint, string header, string footer)
    {
        return new PdfRapportage(footer, header, sprint);
    }
}