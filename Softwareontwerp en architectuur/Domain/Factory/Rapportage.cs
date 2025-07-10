namespace Softwareontwerp_en_architectuur.Domain.Factory;

public abstract class Rapportage
{
    public string Footer { get; set; }
    public string Header { get; set; }
    public Sprint Sprint { get; set; }

    public Rapportage(string footer, string header, Sprint sprint)
    {
        Footer = footer;
        this.Header = header;
        Sprint = sprint;
    }

    public abstract void CreateRapport();
}