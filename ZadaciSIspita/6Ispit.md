# 1. Dajte prijedloge preimenovanja za imena u danom izlistanju koda za koja smatrate da imaju nedostatke
Zadatak:
```c#
public class TicketObjectClass{
    public string SerialNumber { get; private set; }// serial num.
    public int AccLv1 { get; private set; } // level of access granted to ticket holder
    public bool Vip { get; private set; }     // vip ticket?
    public TicketObjectClass(string sn, int acclvl, bool vip) { /* implementation */ }
}

public class TicketMachine
{
    public int MaximumAccessLevel { get; private set; } // level of access granted
    public TicketMachine(int maximumAccessLevel) { /* implementation */ }
    public TicketObjectClass TicketCreation(bool isVIP) { /* implementation */ }
    public void TicketTermination(string serialNumber) { /* implementation */ }
}
```
Rješenje:
```c#
public class Ticket{

    public string SerialNumber { get; private set; }
    public int AccessLevel { get; private set; }
    public bool IsVip { get; private set; }
    public Ticket(string serialNumber, int accessLevel, bool isVip) { /* implementation */ }
}

public class TicketMachine
{
    public int MaximumAccessLevel { get; private set; }
    public TicketMachine(int maximumAccessLevel) { /* implementation */ }
    public Ticket CreateTicket(bool isVip) { /* implementation */ }
    public void TerminateTicket(string serialNumber) { /* implementation */ }
}
```

# 2. Refaktorirajte kod dan u sljedećem izlistanju
Zadatak:
```c#
List<int> JustPerfect(List<int> ints)
{
    List<int> results = new List<int>();
    foreach (int x in ints)
    {
        if (x > 0)
        {
            int sum = 6;
            for (int i = 1; i < x; i++)
            {
                if (x % i == 0)
                    sum += i;
            }
            if (sum == x)
                results.Add(x);
        }
    }
    return results;
}
```
Rješenje:
```c#
List <int> FindPerfectNumbers(List<int> numbers){
    List<int> perfectNumbers = new List<int>();
    foreach(int number in numbers){
        if(IsPerfect(number)) perfectNumbers.Add(number);
    }
    return perfectNumbers;
}
// https://www.youtube.com/watch?v=CFRhGnuXG-4
bool IsPerfect(int number){
    if (number < 0) return false;
    int sum = 0;
    for (int i = 1; i < number; i++)
    {
        if (number % i == 0)
            sum += i;
    }
    if (sum == number) return true;
    return false;
}
```

# 3. Dajte primjer pseudokoda koji narušava interface segregation te objasnite u čemu se to ogleda te zašto je to problem.
Rješenje:
```cs
interface ILogger{
    void LogToFile();
    void LogToConsole();
}

class FileLogger:ILogger{
    void LogToFile(){
        //implementation
    }
    void LogToConsole(){
        throw new NotImplementedException();
    }
}
```
Ovaj kod narušava ISP jer forsira implementaciju LogToConsole metode ILogger sučelja u FileLogger klasu. To se očituje u bacanju NotImplementedException-a u LogToConsole metodi.

# 4. Na što se odnosi pojam lijene klase kao miris u kodu? Navedite nekoliko pristupa za refaktoriranje takvog mirisa.

Pojam lijene klase kao mirisa u kodu odnosi se na male klase koje su često nepotrebne i potrebno ih je ukloniti ili spojiti sa roditeljskom klasom.

# 5. U čemu se ogleda načelo open/closed u sklopu oblikovnog obrasca promatrač. 
Promatrač je otvoren za dodavanje dodatnih konkretnih promatrača bez potrebe za mijenjanjem konkretnog subjekta. Također moguće je dodati novu implementaciju konkretnog subjekta bez potrebe za promjenom stare ili promjene konkretnih promatrača zbog apstrakcija koje obrazac nalaže

# 6. Napišite unit test koji provjerava ispravan rad metode dane sljedećim izlistanjem koda
```c#
class TextParser
{
    public string ExtractDigits(List<string> words)
    {
        string digits = string.Empty;
        
        if (words == null || words.Count == 0)
            return digits;
        
        foreach (string word in words)
        {
            foreach (char letter in word)
            {
                if (char.IsDigit(letter))
                    digits += letter;
            }
        }
        
        return digits;
    }
}
```
Rješenje:
```c#
[TestFixture]
public class TextParserTests
{
    [Test]
    public void ExtractDigits_WhenWordsContainDigits_ReturnsDigits()
    {
        // Arrange
        TextParser parser = new TextParser();
        List<string> words = new List<string> { "abc", "123", "def", "456" };
        
        // Act
        string result = parser.ExtractDigits(words);
        
        // Assert
        Assert.AreEqual("123456", result);
    }
}
```

# 7. Navedite tri posljedice uporabe oblikovnog obrasca Proxy
1. Omogućava kontrolu nad servisnim objektom
2. OCP
3. Omogućava kontrolu životnog tijeka servisnog objekta

# 8. Za primjer dan izlistanjem koda odredite obrazac o kojem je riječ i njegovu skupinu. Dopunite kod implementacijom koja nedostaje te napišite klijentski kod za ovaj primjer.
Zadatak:
```c#
public class VacationConfigurator
{
    public string Destination { get; private set; }
    private List<Activity> additionalActivities = new List<Activity>();

    public decimal CalculateTotal()
    {
        return additionalActivities.Sum(it => it.Price);
    }

    public void AddExtra(Activity activity)
    {
        additionalActivities.Add(activity);
    }

    public void Remove(Activity activity)
    {
        additionalActivities.Remove(activity);
    }

    public void LoadPrevious(VacationConfiguration configuration)
    {
        Destination = configuration.GetDestination();
        additionalActivities.Clear();
        additionalActivities.AddRange(configuration.GetAdditionalActivities());
    }

    public VacationConfiguration Store()
    {
        return new VacationConfiguration(Destination, additionalActivities);
    }
}

public class VacationConfiguration
{
    private string destination;
    private List<Activity> additionalActivities;
}

public class ConfigurationManager
{
    private List<VacationConfiguration> configurations = new List<VacationConfiguration>();

    public void AddConfiguration(VacationConfiguration configuration)
    {
        configurations.Add(configuration);
    }

    public void DeleteConfiguration(VacationConfiguration configuration)
    {
        configurations.Remove(configuration);
    }

    public VacationConfiguration GetConfiguration(int index)
    {
        return configurations[index];
    }
}
```

Rješenje:
```c#
public class Activity{
    public int Price {get; set;}
    public string Name{get; set;}
    public Activity(string name){
        Name = name;
    }
}
public class VacationConfigurator
{
    public string Destination { get; private set; }
    private List<Activity> additionalActivities = new List<Activity>();

    public decimal CalculateTotal()
    {
        return additionalActivities.Sum(it => it.Price);
    }

    public void AddExtra(Activity activity)
    {
        additionalActivities.Add(activity);
    }

    public void Remove(Activity activity)
    {
        additionalActivities.Remove(activity);
    }

    public void LoadPrevious(VacationConfiguration configuration)
    {
        Destination = configuration.GetDestination();
        additionalActivities.Clear();
        additionalActivities.AddRange(configuration.GetAdditionalActivities());
    }

    public VacationConfiguration Store()
    {
        return new VacationConfiguration(Destination, additionalActivities);
    }
}

public class VacationConfiguration
{
    private string destination;
    private List<Activity> additionalActivities;
    public VacationConfiguration(string destination, List<Activity> additionalActivities){
        this.destination = destination;
        this.additionalActivities = additionalActivities;
    }
    public string GetDestination(){
        return destination;
    }

    public List<Activity> GetAdditionalActivities(){
        return additionalActivities;
    }
}

public class ConfigurationManager
{
    private List<VacationConfiguration> configurations = new List<VacationConfiguration>();

    public void AddConfiguration(VacationConfiguration configuration)
    {
        configurations.Add(configuration);
    }

    public void DeleteConfiguration(VacationConfiguration configuration)
    {
        configurations.Remove(configuration);
    }

    public VacationConfiguration GetConfiguration(int index)
    {
        return configurations[index];
    }
}

public static class Program{
    public static void Main(){
        VacationConfigurator vacationConfigurator = new VacationConfigurator();
        
        VacationConfiguration vacationConfiguration = vacationConfigurator.Store();

        ConfigurationManager configManager = new ConfigurationManager();

        configManager.AddConfiguration(vacationConfiguration);

        vacationConfigurator.AddExtra(new Activity("Walking"));

        vacationConfigurator.LoadPrevious(configManager.GetConfiguration(0));
    }
}   
```
Obrazac je Memento.

# 9. Povežite klase, metode i sučelja s njihovim ulogama u obrascu. O kojem obrascu je rječ i kojoj skupini pripada? Navedite dva razloga iz kojih ga je prikladno koristiti.

|Generic                    | Contextual                |
|:--------------------------|:--------------------------|
|IStreamable                | Leaf                      |
|Song                       | Composite                 |
|Playlist                   | Component                 |
|play()                     | Operation                 |

Rješenje:
|Generic                    | Contextual                |
|:--------------------------|:--------------------------|
|IStreamable                | Component                 |
|Song                       | Leaf                      |
|Playlist                   | Composite                 |
|play()                     | Operation                 |

- Obrazac: Kompozit
- Skupina: Strukturni
- Koristiti kad imamo stablastu strukturu
- Koristiti kad klijentski kod treba tretirati kompleksne i jednostavne objekte jednako

# 10. Koji je oblikovni obrazac prikladan za rješavanje zadatka danog u nastavku i u koju skupinu pripada? Navedite strukturu klasa te pripadajuće metode/atribute koje biste koristili i njihove uloge

Radite na izradi informacijskog sustava za potrebe objave sudskih odluka, gdje može postojati više različitih konkretnih izvora koji objavljuju odluke. Mehanizam objave jednak je za sve konkretne izvore. Trebate podržati objavljivanje različitih objava i odluka namijenjenih javnosti na način da se bilo koja institucija, organizacija ili osoba mogu prijaviti na praćenje navedenih objava ili ih prestati pratiti, pri čemu svaka od njih ima vlastiti konkretan način postupanja po primljenoj odluci.