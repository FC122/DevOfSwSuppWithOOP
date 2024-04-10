# Objektno orjentirano programiranje
U ovom poglavlju biti će objašnjeni osnovni pojmovi i koncepti vezani uz oop. Koncepti objašnjeni ovdje vrijede za skoro sve oop jezike. Primjeri ovdje su programirani u C# programskom jeziku. Cilj ovog poglavlja je ponoviti osnovne koncepte oop-a a ne detaljno ih objašnjavati kako bi bolje razumjeli sljedeća poglavlja (SOLID, Oblikovni obrasci)

## Klasa
Klasa u objektno orijentiranom programiranju predstavlja predložak ili "plavprint" za stvaranje objekata. U njoj se definiraju svojstva (atributi) i ponašanja (metode) objekata određenog tipa.
``` cs
public class Automobil
{
    // Atributi (svojstva) klase Automobil
    public string Marka { get; set; }
    public string Model { get; set; }
    public int GodinaProizvodnje { get; set; }

    // Konstruktor klase Automobil
    public Automobil(string marka, string model, int godinaProizvodnje)
    {
        Marka = marka;
        Model = model;
        GodinaProizvodnje = godinaProizvodnje;
    }

    // Metoda koja ispisuje informacije o automobilu
    public void IspisiInformacije()
    {
        Console.WriteLine($"Automobil: {Marka} {Model}, Godina proizvodnje: {GodinaProizvodnje}");
    }
}
```

## Objekt
Objekt je instanca klase. Objekt posjeduje svojstva definirana u klasi te može izvršavati metode koje su također definirane u klasi. Objekti omogućuju konkretizaciju apstraktnih definicija i reprezentiraju stvarne entitete ili pojave u programu. Sa ključnom riječi new instanciramo objekt tj. stvaramo taj objekt.
``` cs
class Program
{
    static void Main(string[] args)
    {
        // Stvaranje novog objekta klase Automobil
        Automobil automobil1 = new Automobil("Toyota", "Corolla", 2020);

        // Pozivanje metode za ispis informacija o automobilu
        automobil1.IspisiInformacije();
    }
}
```

## Nasljeđivanje
Koncept u oop-u koji nalaže kreiranje novih klasa na temelju postojećih klasa, preuzimajući njihova svojstva i metode čime se olakšava korištenje koda i poboljšava organizacija programa.

### Klasa roditelj
Viša/Roditeljska/Bazna/Osnovna klasa je klasa čiji članovi su naslijeđeni od strane druge klase. Također je poznata kao roditeljska klasa ili nadklasa. Ona definira zajedničke atribute i ponašanja koji se dijele među njenim izvedenim klasama.

### Klasa dijete
Niža/Dijete/Izvedena/Podklasa klasa je klasa koja nasljeđuje od druge klase. Također je poznata kao podklasa ili djetelinska klasa. Može ponovno koristiti članove bazne klase i može imati dodatne članove ili nadjačati postojeće.

``` cs
// Osnovna klasa
public class Vozilo
{
    public string Marka { get; set; }
    public int GodinaProizvodnje { get; set; }

    public void IspisiInformacije()
    {
        Console.WriteLine($"Vozilo: {Marka}, Godina proizvodnje: {GodinaProizvodnje}");
    }
}

// Podklasa Automobil koja nasljeđuje klasu Vozilo
public class Automobil : Vozilo
{
    public string Model { get; set; }

    // Konstruktor koji inicijalizira atribute roditeljske klase i atribut Model
    public Automobil(string marka, string model, int godinaProizvodnje)
    {
        Marka = marka;
        Model = model;
        GodinaProizvodnje = godinaProizvodnje;
    }

    // Metoda koja ispisuje informacije o automobilu
    public void IspisiAutomobilInformacije()
    {
        Console.WriteLine($"Automobil: {Marka} {Model}, Godina proizvodnje: {GodinaProizvodnje}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Stvaranje novog objekta klase Automobil
        Automobil automobil1 = new Automobil("Toyota", "Corolla", 2020);

        // Pozivanje metoda za ispis informacija o automobilu
        automobil1.IspisiInformacije(); // Pozivanje metode iz roditeljske klase
        automobil1.IspisiAutomobilInformacije(); // Pozivanje metode iz podklase
    }
}
```
### Apstrakcija
Apstrakcija je temeljni koncept u objektno orijentiranom programiranju (OOP) koji uključuje pojednostavljivanje kompleksnih sustava modeliranjem razreda na temelju njihovih bitnih značajki i ponašanja. To omogućuje programerima da se usredotoče na relevantne aspekte objekta, zanemarujući nepotrebne pojedinosti. U kontekstu OOP-a, apstrakcija obično poprima dva glavna oblika: Apstraktne klase i metode te sučelja.

#### Apstraktna klasa i metoda
Apstraktna klasa je klasa koja se ne može instancirati samostalno i može sadržavati apstraktne metode (metode bez implementacije). Služi kao predložak za druge klase. Apstraktna klasa može imati i ne apstraktne metode s implementiranom funkcionalnošću.

#### Virtualna metoda
U programskom jeziku C#, ključna riječ "virtual" koristi se za deklariranje metode u baznoj klasi koju mogu nadjačati izvedene klase ali ne moraju. Virtualna metoda sadrži implementaciju. Ovo omogućuje polimorfizam, gdje izvedena klasa može pružiti vlastitu implementaciju metode dok održava zajedničko sučelje s baznom klasom. Ključna riječ "virtual" obično se koristi u kombinaciji s ključnom riječi "override" u izvedenoj klasi, tj. ako u izvedenoj klasi želimo prilagođenu funkcionalnost virtualnu metodu je potrebno prepisati.

``` cs
public abstract class Vozilo
{
    public string Marka { get; set; }
    public int GodinaProizvodnje { get; set; }

    // Apstraktna metoda koja će biti implementirana u podklasama
    public abstract void Pokreni();

    // Virtualna metoda koju podklase mogu prebrisati po potrebi
    public virtual void Zaustavi()
    {
        Console.WriteLine("Vozilo je zaustavljeno.");
    }

    // Obična (konkretna) metoda
    public void IspisiInformacije()
    {
        Console.WriteLine($"Vozilo: {Marka}, Godina proizvodnje: {GodinaProizvodnje}");
    }
}

// Podklasa Automobil koja nasljeđuje apstraktnu klasu Vozilo
public class Automobil : Vozilo
{
    public string Model { get; set; }

    public Automobil(string marka, string model, int godinaProizvodnje)
    {
        Marka = marka;
        Model = model;
        GodinaProizvodnje = godinaProizvodnje;
    }

    // Implementacija apstraktne metode Pokreni iz bazne klase
    public override void Pokreni()
    {
        Console.WriteLine("Automobil je pokrenut.");
    }

    // Prebrisavanje virtualne metode Zaustavi koje je opcionalno
    public override void Zaustavi()
    {
        Console.WriteLine("Automobil je zaustavljen.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Automobil automobil1 = new Automobil("Toyota", "Corolla", 2020);

        automobil1.IspisiInformacije();
        automobil1.Pokreni();
        automobil1.Zaustavi(); // Poziva se prebrisana metoda
    }
}
```

#### Sučelja
Sučelje je ugovor koji definira skup potpisa metoda. Klasa koji implementira sučelje mora pružiti konkretne implementacije svih metoda deklariranih u tom sučelju. Sučelja omogućuju postizanje apstrakcije definiranjem što objekt treba raditi, bez specificiranja kako to treba učiniti.
``` cs
// Sučelje IVozilo
public interface IVozilo
{
    // Potpisi metoda
    void Pokreni();
    void Zaustavi();
}

// Klasa Automobil koja implementira sučelje IVozilo
public class Automobil : IVozilo
{
    public void Pokreni()
    {
        Console.WriteLine("Automobil je pokrenut.");
    }

    public void Zaustavi()
    {
        Console.WriteLine("Automobil je zaustavljen.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Automobil automobil1 = new Automobil();

        automobil1.Pokreni();
        automobil1.Zaustavi();
    }
}
```

## Enkapsulacija
Koncept u oop-u koji nalaže skrivanje internih detalja objekta i izlaganja samo onoga što je nužno. Enkapsulacija pruža nekoliko prednosti, uključujući zaštitu podataka, organizaciju koda i fleksibilnost u dizajnu.

### Pristupni modifikatori
Pristupni modifikatori (private, public, protected, internal) kontroliraju vidljivost članova klase. Označavanjem određenih članova kao privatne, ograničavate izravan pristup tim članovima izvan klase.

- private - entitet (svojstvo, metoda, ...) je dostupan samo unutar klase
- public - entitet je dostupan u bilo kojem djelu programa
- protected - entitet je dostupan unutar iste klase i u izvedenim klasama
- internal - entitet je dostupan unutar istog assemblyja (DLL ili SDK)

``` cs
public class Brojevi
{
    public int JavniBroj { get; set; } // Dostupno izvan klase

    private int PrivatniBroj { get; set; } // Dostupno samo unutar klase

    protected int ZasticeniBroj { get; set; } // Dostupno samo unutar klase i izvedenih klasa

    internal int InterniBroj { get; set; } // Dostupno samo unutar istog projekta ili assemblyja
}

public class IzvedeniBrojevi : Brojevi
{
    public void Metoda()
    {
        // Možemo pristupiti ZasticeniBroj jer je protected i dostupan izvedenoj klasi
        Console.WriteLine(ZasticeniBroj);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Brojevi brojevi = new Brojevi();

        // Možemo pristupiti JavniBroj jer je public
        brojevi.JavniBroj = 10;

        // Ne možemo pristupiti PrivatniBroj jer je private i nije dostupan izvan klase
        // brojevi.PrivatniBroj = 5;

        // Ne možemo pristupiti ZasticeniBroj jer nije dostupan izvan klase ni izvedenih klasa
        // brojevi.ZasticeniBroj = 15;

        // Ne možemo pristupiti InterniBroj jer nije dostupan izvan istog projekta ili assemblyja
        // brojevi.InterniBroj = 20;
    }
}
```
## Polimorfizam
Koncept u oop-u koji nalaže da treba biti moguće imati entitete koji se jednako zovu a drugačije ponašaju.

### Statički polimorfiza
Statički polimorfizam se postiže kroz preopterećenje metoda ili operatora. To znači da isto ime metode ili operatora može imati različite implementacije, ali se razlikuju po broju ili tipu parametara.

```cs
public class Matematika
{
    // Metoda za zbrajanje dva cijela broja
    public int Zbroji(int a, int b)
    {
        return a + b;
    }

    // Metoda za zbrajanje tri cijela broja
    public int Zbroji(int a, int b, int c)
    {
        return a + b + c;
    }

    // Metoda za zbrajanje dva decimalna broja
    public double Zbroji(double a, double b)
    {
        return a + b;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Matematika mat = new Matematika();

        // Poziv metode za zbrajanje dva cijela broja
        int rezultat1 = mat.Zbroji(3, 5);
        Console.WriteLine("Zbroj dva cijela broja: " + rezultat1);

        // Poziv metode za zbrajanje tri cijela broja
        int rezultat2 = mat.Zbroji(3, 5, 7);
        Console.WriteLine("Zbroj tri cijela broja: " + rezultat2);

        // Poziv metode za zbrajanje dva decimalna broja
        double rezultat3 = mat.Zbroji(3.5, 4.7);
        Console.WriteLine("Zbroj dva decimalna broja: " + rezultat3);
    }
}
```

### Dinamički polimorfizam
Dinamički polimorfizam omogućuje različite implementacije metoda prema vrsti objekta koji ga poziva.
Postiže se kroz naslijeđivanje i virtualne metode. Bazna klasa definira virtualne metode koje se mogu prebrisati u izvedenim klasama.

### Parametarski polimorfizam
Parametarski polimorfizam se postiže kroz korištenje generičkih tipova. Generički tipovi omogućuju definiranje klasa, struktura ili metoda koji mogu raditi s različitim tipovima podataka, čime se postiže veća fleksibilnost i ponovno korištenje koda. Korištenjem generičkih tipova, programer može stvoriti komponente koje su neovisne o konkretnim tipovima podataka s kojima će raditi. Parametarski polimorfizam omogućuje pisanje općenitih algoritama i struktura podataka koje mogu biti korisne u različitim kontekstima