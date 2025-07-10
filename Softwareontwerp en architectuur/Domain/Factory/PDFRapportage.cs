namespace Softwareontwerp_en_architectuur.Domain.Factory;

public class PdfRapportage : Rapportage
{
    public PdfRapportage(string footer, string header, Sprint sprint) : base(footer, header, sprint)
    {
    }


    public override void CreateRapport()
    {
        Console.Write("PDF Rapport made");
    }
}