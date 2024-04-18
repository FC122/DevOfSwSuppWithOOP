# Objektno orjentirano programiranje
U ovom poglavlju biti će objašnjeni osnovni pojmovi i koncepti vezani uz oop. Koncepti objašnjeni ovdje vrijede za skoro sve oop jezike. Primjeri ovdje su programirani u C# programskom jeziku. Cilj ovog poglavlja je ponoviti osnovne koncepte oop-a a ne detaljno ih objašnjavati kako bi bolje razumjeli sljedeća poglavlja (SOLID, Oblikovni obrasci)

## Klasa
Klasa u objektno orijentiranom programiranju predstavlja predložak ili "plavprint" za stvaranje objekata. U njoj se definiraju svojstva (atributi) i ponašanja (metode) objekata određenog tipa.

### Konstruktor
Konstruktor je posebna vrsta metode u programiranju, koja se koristi za inicijalizaciju objekata u klasi. On se obično koristi za postavljanje početnih vrijednosti svojstava ili izvođenje drugih inicijalizacijskih radnji potrebnih za ispravno funkcioniranje objekta.

### Atribut
Atributi, u kontekstu programiranja, su varijable koje su vezane uz određeni objekt ili klasu. Svaki objekt može imati svoj set atributa koji opisuju njegova svojstva ili stanje.

### Metoda
Metoda u programiranju predstavlja funkciju koja je definirana unutar neke klase. Ove funkcije obično služe za izvođenje određenih operacija nad objektima te klase ili za manipulaciju s njihovim atributima.

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
### Statička klasa, metoda i atribut
Statičke klase ne mogu imati instance i obično se koriste za grupiranje povezanih metoda i atributa koje se mogu koristiti bez potrebe za stvaranjem objekata.

Međutim, unutar statičke klase mogu postojati i nestatički (obični) atributi i metode. Ovi atributi i metode mogu biti korišteni samo ako postoji instanca klase, što nije moguće kod statičkih klasa jer se one ne mogu instancirati.
```cs

public static class StaticClassExample
{
    // Statički atribut
    public static int brojac = 0;

    // Statička metoda
    public static void Pozdrav()
    {
        Console.WriteLine("Pozdrav iz statičke metode!");
    }
}

class Program
{
    static void Main()
    {
        // Pozivanje statičke metode bez stvaranja instance klase
        StaticClassExample.Pozdrav();

        // Pristupanje statičkom atributu
        StaticClassExample.brojac++;

        // Ispisivanje vrijednosti statičkog atributa
        Console.WriteLine("Vrijednost brojaca: " + StaticClassExample.brojac);
    }
}
```
## Objekt
Objekt je instanca klase. Objekt posjeduje svojstva definirana u klasi te može izvršavati metode koje su također definirane u klasi. Objekti omogućuju konkretizaciju apstraktnih definicija i reprezentiraju stvarne entitete ili pojave u programu.

### Instanciranje objekta
Instanciranje objekta je postupak stvaranja instance određene klase. Kada se kreira instanca, rezervira se memorija za objekt, a konstruktor klase se koristi za inicijalizaciju tog objekta. Sa ključnom riječi new instanciramo objekt tj. stvaramo taj objekt.

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

Pogledati video: https://www.youtube.com/watch?v=hxGOiiR9ZKg&t=500s

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

## Ovisnost

### Ubrizgavanje ovisnosti
Pogeldati ovaj video: https://www.youtube.com/watch?v=J1f5b4vcxCQ

Obrazac koji se koristi u oop-u kako bi se riješio problem ovisnosti između klasa ubrizgavanjem tih ovisnosti izvana, umjesto da klasa stvara svoje ovisnosti unutar sebe. Osnovni cilj DI-ja je postizanje labave povezanosti između klasa, čime se sustav čini modularnim, održivijim i stabilnijim.

#### Ubrizgavanje konstruktorom
```cs
// Interface koji definira uslugu
public interface IService
{
    void PerformOperation();
}

// Implementacija IService sučelja
public class Service : IService
{
    public void PerformOperation()
    {
        Console.WriteLine("Operation performed by Service");
    }
}

// Klasa koja ovisi o IService sučelju kroz konstruktor
public class Client
{
    private readonly IService _service;

    // Konstruktor koji prima IService implementaciju
    public Client(IService service)
    {
        _service = service;
    }

    // Metoda koja koristi uslugu IService
    public void ExecuteOperation()
    {
        _service.PerformOperation();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Instanciranje implementacije IService
        IService service = new Service();

        // Stvaranje instance klijenta s proslijeđenom implementacijom IService
        Client client = new Client(service);

        // Izvođenje operacije kroz klijenta
        client.ExecuteOperation();
    }
}
```

#### Ubrizgavanje metodom
```cs
// Interface koji definira uslugu
public interface IService
{
    void PerformOperation();
}

// Implementacija IService sučelja
public class Service : IService
{
    public void PerformOperation()
    {
        Console.WriteLine("Operation performed by Service");
    }
}

// Klasa koja ovisi o IService sučelju kroz metodu
public class Client
{
    // Metoda koja prima IService implementaciju kao argument
    public void ExecuteOperation(IService service)
    {
        service.PerformOperation();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Instanciranje implementacije IService
        IService service = new Service();

        // Stvaranje instance klijenta i poziv metode s proslijeđenom implementacijom IService
        Client client = new Client();
        client.ExecuteOperation(service);
    }
}
```

#### Ubrizgavanje svojstvom
```cs
// Interface koji definira uslugu
public interface IService
{
    void PerformOperation();
}

// Implementacija IService sučelja
public class Service : IService
{
    public void PerformOperation()
    {
        Console.WriteLine("Operation performed by Service");
    }
}

// Klasa koja ovisi o IService sučelju kroz svojstvo
public class Client
{
    // Javno svojstvo za IService implementaciju
    public IService Service { get; set; }

    // Metoda koja koristi IService uslugu
    public void ExecuteOperation()
    {
        Service.PerformOperation();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Instanciranje implementacije IService
        IService service = new Service();

        // Stvaranje instance klijenta i postavljanje svojstva IService
        Client client = new Client();
        client.Service = service;

        // Izvođenje operacije kroz klijenta
        client.ExecuteOperation();
    }
}
```

### Čvrst sprega
Javlja se kada su dvije ili više klasa visoko ovisne jedna o drugoj, te promjene u jednoj klasi mogu zahtijevati promjene u drugoj. Ova vrsta povezanosti može otežati održavanje i proširivanje sustava jer promjene u jednoj klasi često zahtijevaju prilagodbe u drugim klasama s kojima je čvrsto povezana. Osnovni cilj u objektno orijentiranom programiranju je smanjiti čvrstu povezanost kako bi se poboljšala modularnost i fleksibilnost sustava.
```cs
// Klasa koja predstavlja neku funkcionalnost
public class Servis
{
    // Metoda koja obrađuje neki podatak
    public void ObaviPosao()
    {
        Console.WriteLine("Obavlja se neki posao...");
    }
}

// Klasa koja ovisi o funkcionalnosti Servis klase
public class Klijent
{
    private readonly Servis servis;

    // Konstruktor koji stvara čvrstu spregu između Klijent i Servis klase
    public Klijent()
    {
        servis = new Servis();
    }

    // Metoda koja koristi funkcionalnost Servis klase
    public void KoristiServis()
    {
        servis.ObaviPosao();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Klijent klijent = new Klijent();
        klijent.KoristiServis();
    }
}
```
### Labava sprega
Javlja se kada su dvije ili više klasa neovisne jedna o drugoj te promjene u jednoj klasi ne zahtijevaju promjene u drugoj. Ova vrsta povezanosti promiče fleksibilnost i olakšava održavanje sustava, jer promjene u jednoj klasi ne bi trebale zahtijevati prilagodbe u drugim klasama s kojima interagira.
```cs
// Interface koji definira funkcionalnost
public interface IServis
{
    void ObaviPosao();
}

// Implementacija IServis sučelja
public class Servis : IServis
{
    public void ObaviPosao()
    {
        Console.WriteLine("Obavlja se neki posao...");
    }
}

// Klasa koja ovisi o funkcionalnosti Servis klase
public class Klijent
{
    private readonly IServis _servis;

    // Konstruktor koji koristi dependency injection
    public Klijent(IServis servis)
    {
        _servis = servis;
    }

    // Metoda koja koristi funkcionalnost Servis klase
    public void KoristiServis()
    {
        _servis.ObaviPosao();
    }
}

class Program
{
    static void Main(string[] args)
    {
        IServis servis = new Servis();
        Klijent klijent = new Klijent(servis);
        klijent.KoristiServis();
    }
}
```
## Zadaci

### 1. Zadatak
Implementirajte bankovni sustav koristeći se načelima objektno orijentiranog programiranja. Osim osnovnih funkcionalnosti bankovnog sustava, naglasak je na korištenju sučelja, apstraktnih klasa, virtualnih metoda, apstraktnih metoda, labave spregu, ubrizgavanja ovisnosti, polimorfizma, nasljeđivanja i enkapsulacije.


Sučelja koja možete definirati:

- IBankovniRacun: Definira osnovne operacije za upravljanje bankovnim računima.
- ITransakcija: Definira metode za izvršavanje transakcija.


Apstraktne klase koje možete definirati:

- Osoba: Apstraktna klasa koja predstavlja osnovne osobne podatke korisnika.
- Transakcija: Apstraktna klasa koja sadrži zajednička svojstva svih vrsta transakcija.


Klase koje možete definirati:

- Korisnik: Klasa koja implementira sučelje IBankovniRacun i sadrži informacije o korisniku.
- Banka: Klasa koja upravlja korisnicima i omogućuje izvršavanje transakcija. Implementira ubrizgavanje ovisnosti kako bi se postigla labava sprega s korisnicima.
- Konkretne vrste transakcija (npr. Uplata, Isplata) koje nasljeđuju Transakcija.


Virtualne metode i polimorfizam:

- U klasama Osoba, Transakcija i drugim relevantnim klasama, implementirati virtualne metode koje se mogu nadjačati u podklasama za specifične potrebe.


Apstraktne metode:

- ITransakcija definira apstraktnu metodu IzvrsiTransakciju() koju implementiraju konkretne transakcijske klase.

Enkapsulacija:

- Odredi koje vrijable trebaju biti enkapsulirane (odredi gdje je potrebno staviti private, public, protected ili internal) kako bi se osigurala zaštita podataka i održavanje skladnog stanja objekata.

Dodatni uvjeti:

Implementirati mehanizme ubrizgavanja ovisnosti kako bi se omogućila labava sprega i jednostavno testiranje.
Održavati jasnu hijerarhiju klasa kroz nasljeđivanje kako bi se postigla čitljivost i skalabilnost koda.
Koristiti apstraktne klase i sučelja tamo gdje je to primjenjivo radi definiranja zajedničkih karakteristika i funkcionalnosti.
Ovaj zadatak osigurava primjenu naprednih OOP koncepta i tehnika kako bi se postigla visoka razina modularnosti, fleksibilnosti i čitljivosti koda. Sretno!