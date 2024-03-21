namespace zajecia2;

public class Kontener
{
    private double masaLadunku;
    private double wysokosc;
    private double wagaWlasnaKontenera;
    private double glebokosc;
    private string numerSeryjny;
    private double maskymalnaLadownosc;

    public Kontener(double masaLadunku, double wysokosc, double wagaWlasnaKontenera,
        double glebokosc, string numerSeryjny, double maskymalnaLadownosc)
    {
        this.masaLadunku = masaLadunku;
        this.wysokosc = wysokosc;
        this.wagaWlasnaKontenera = wagaWlasnaKontenera;
        this.glebokosc = glebokosc;
        this.numerSeryjny = numerSeryjny;
        this.maskymalnaLadownosc = maskymalnaLadownosc;
    }

    public void OproznienieLadunku()
    {
        Console.WriteLine("Oproznianie ladunku...");
    }
    
}