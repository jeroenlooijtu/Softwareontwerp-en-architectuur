namespace Softwareontwerp_en_architectuur.Domain.Factory;

public class PngRapportage : Rapportage
{
    public PngRapportage(string footer, string header, Sprint sprint) : base(footer, header, sprint)
    {
    }

    public override void CreateRapport()
    {
        Console.Write("Create PNG Rapport");
    }
}