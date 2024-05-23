# 1. Dajte prijedloge preimenovanja za imena u danom izlistanju koda za koja smatrate da imaju nedostatke
```cs
class Rndgen
{
    private static Rndgen inst;
    private Random PRNG; //pseudo random number generator 

    // Private constructor
    private Rndgen()
    {
        this.PRNG = new Random();
    }

    // Singleton instance creation method
    public static Rndgen Instance()
    {
        if (inst == null)
        {
            inst = new Rndgen();
        }
        return inst;
    }

    public int Int1()
    {
        return this.PRNG.Next();
    }

    public int Int2(int a, int b)
    {
        return this.PRNG.Next() % (b - a + 1);
    }

    public double Double(double a, double b)
    {
        return a + (this.PRNG.NextDouble() * (b - a));
    }
}
```
Rješenje:
```cs
class RandomDataGenerator
{
    private static RandomDataGenerator randomDataGenerator;
    private Random random;

    private RandomDataGenerator()
    {
        this.random = new Random();
    }
    public static RandomDataGenerator Instance()
    {
        if (randomDataGenerator == null)
        {
            randomDataGenerator = new RandomDataGenerator();
        }
        return randomDataGenerator;
    }

    public int GenerateInteger()
    {
        return this.random.Next();
    }

    public int GenerateInteger(int a, int b)
    {
        return this.random.Next() % (b - a + 1);
    }

    public double GenerateDouble(double a, double b)
    {
        return a + (this.random.NextDouble() * (b - a));
    }
}
```

# 2. Refaktorirajte kod dan u sljedećem izlistanju
```cs
 //static method that returns an integer and takes an array of integers as input
public static int Distinct(List<int> intList)
{
    int res = 0;//final result
    for (int i = 0; i < intList.Count; i++)
    {
        int flag = 0; // flag for counting
        for (int j = 0; j < intList.Count; j++)
        {
            if (intList[i] == intList[j])
            {
                flag++; // occurrence counting
            }
        }
        if (flag == 1)
        {
            res++; // distinct count
        }
    }
    return res; // the result of counting
}
```
```cs
public static int CountDistinctNumbers(List<int> array)
{
    int counter = 0;
    for (int i = 0; i < array.Count; i++)
    {
        if (CountOccurrences(array, array[i]) == 1)
        {
            counter++;
        }
    }
    return counter;
}

public static int CountOccurrences(List<int> array, int number)
{
    int occurrence = 0;
    for (int j = 0; j < array.Count; j++)
    {
        if (number == array[j])
        {
            occurrence++;
        }
    }
    return occurrence;
}
```

# 3. Dajte primjer pseudokoda koji narusava načelo SRP te objasnite u čemu se to ogleda i zašto je to problem
```cs
class User{
    int id;
    string Name{get; private set;}
    string Surname{get; private set;}
}

class Bank{
    List<User> users;
    public Bank(){
        users = new Users();
    }

    public void AddUser(User user){
        users.Add(user);
    }

    public void RemoveUser(User user){
        users.Remove(user)
    }

    //pripada li ova funkcionalnost ovdje?
    public void LogUserData(User user){
        Console.WriteLine($"{user.Name}, {user.Surname}")
    }

    //pripada li ova funkcionalnost ovdje?
    public JSONFile ExportToJSON(){
        Console.WriteLine($"Export to JSON")
    }
}
```
Primjer iznad krši SRP jer klasa Bank ima dodatne odgovornosti nevezane za nju u obliku LogUserData i ExportToJSON metoda. To je problem jer klasa Bank onda sadrži odgovornost za više funkcionalnosti.

# 4. Na sto se odnosi pojam privremeni atributi kao miris u kodu? Navedit nekoliko pristupa za refaktoriranje takvog mirisa
Atributi koji su povremeno ili rjetko korišteni, zbog njih je kod teže razumjeti. Takvi atributi nisu nužni i može ih se izdvojiti u drugu klasu.

# 5. U cemu se ogleda nacelo OCP u sklopu oblikovnog obrasca lanac odgovornosti
U sklopu oblikovnog obrasca lanac odgovornosti OCP se očituje u tome što je moguće dodavati nove konkretne karike u lanac bez potrebe da se klijentski kod previše mijenja.

# 6. Napisite unit test koji provjerava ispravan rad metode dane sljedecim izlistanjem koda koda
```cs
class EntryValidator
{
    private int threshold;

    public EntryValidator(int threshold)
    {
        this.threshold = threshold;
    }

    public bool ObservedEnoughSquares(List<int> entries, List<int> observations)
    {
        if (entries == null || observations == null)
        {
            return false;
        }

        int squares = 0;
        foreach (int entry in entries)
        {
            foreach (int observation in observations)
            {
                if (entry == observation)
                {
                    squares++;
                }
            }
        }

        return squares >= threshold;
    }
}
```

Rješenje:
```cs
[TestFixture]
public class EntryValidatorTests
{
    [Test]
    public void ObservedEnoughSquares_ReturnsTrue_WhenEnoughObservations()
    {
        // Arrange
        EntryValidator validator = new EntryValidator(3);
        List<int> entries = new List<int> { 1, 2, 3, 4, 5 };
        List<int> observations = new List<int> { 1, 2, 3 };

        // Act
        bool result = validator.ObservedEnoughSquares(entries, observations);

        // Assert
        Assert.IsTrue(result);
    }
}
```

# 7. Navedite tri posljedice uporabe oblikovnog obrasca Memento
- Moguće proizvesti slike stanja objekta bez kršenja enkapsulacija
- Moguće pojednostaviti kod izvornika tako sto dopuštaš skrbniku da održava povijest stanja originatora
- Aplikacija može trošiti mnogo RAMa ako su Mementi često stvarani

# 8. Za primjer da izlistanjem koda odredite obrazac o kojem je rjec i njegovu skupinu. Dopunite kod implementacijom koja nedostaje te napisite klijentski kod za ovaj primjer
```cs
// Detector interface
public interface IDetector
{
    void Notify();
    void StartWatching(IWatcher watcher);
    void StopWatching(IWatcher watcher);
}

// Watcher interface
public interface IWatcher
{
    void OnDetection(double value);
}

// Concrete class EarthquakeDetector implementing IDetector
public class EarthquakeDetector : IDetector
{
    private double sensorValue = 0;
    private List<IWatcher> watchers = new List<IWatcher>();

    public void MeasurePeriodically(int period)
    {
        // Triggers every period milliseconds
        double measured = Measure();
        bool shouldNotify = measured > sensorValue;
        sensorValue = measured;
        if (shouldNotify)
        {
            Notify();
        }
    }

    private double Measure()
    {
        // Measurement logic
        return 0; // Placeholder for actual measurement
    }

    public void StartWatching(IWatcher watcher)
    {
        watchers.Add(watcher);
    }

    public void StopWatching(IWatcher watcher)
    {
        watchers.Remove(watcher);
    }

    public void Notify()
    {
        foreach (IWatcher watcher in watchers)
        {
            watcher.OnDetection(sensorValue);
        }
    }
}
```
Rješenje:
```cs
// Detector interface
public interface IDetector
{
    void Notify();
    void StartWatching(IWatcher watcher);
    void StopWatching(IWatcher watcher);
}

public class LogDatabase
{
    private static LogDatabase instance;

    private LogDatabase() { }

    public static LogDatabase Create()
    {
        if (instance == null)
        {
            instance = new LogDatabase();
        }
        return instance;
    }

    public void Insert(DateTime timestamp, double value)
    {
        Console.WriteLine($"Logged: {timestamp} - Value: {value}");
    }
}

// Watcher interface
public interface IWatcher
{
    void OnDetection(double value);
}

// Concrete class EarthquakeDetector implementing IDetector
public class EarthquakeDetector : IDetector
{
    private double sensorValue = 0;
    private List<IWatcher> watchers = new List<IWatcher>();

    public void MeasurePeriodically(int period)
    {
        // Triggers every period milliseconds
        double measured = Measure();
        bool shouldNotify = measured > sensorValue;
        sensorValue = measured;
        if (shouldNotify)
        {
            Notify();
        }
    }

    private double Measure()
    {
        // Measurement logic
        return 0; // Placeholder for actual measurement
    }

    public void StartWatching(IWatcher watcher)
    {
        watchers.Add(watcher);
    }

    public void StopWatching(IWatcher watcher)
    {
        watchers.Remove(watcher);
    }

    public void Notify()
    {
        foreach (IWatcher watcher in watchers)
        {
            watcher.OnDetection(sensorValue);
        }
    }
}

// Concrete class Logger implementing IWatcher
public class Logger : IWatcher
{
    private LogDatabase logDatabase;

    public Logger()
    {
        logDatabase = LogDatabase.Create();
    }

    public void OnDetection(double value)
    {
        logDatabase.Insert(DateTime.Now, value);
    }
}

public static class ClientCode
{
    static void Run()
    {
        EarthquakeDetector detector = new EarthquakeDetector();
        Logger logger = new Logger();

        detector.StartWatching(logger);
        detector.MeasurePeriodically(1000); 
    }
}
```
# 9. Povezite klase, metode i sucelja s njihovim ulogama u obrascu. O kojem obrascu je rijec i kojoj skupini pripada? Navedite dva razloga iz kojih ga je prikladnog koristiti.

|Generic                    | Contextual                    |
|:--------------------------|:------------------------------|
|Composite                  |IToDoItem                      |
|Component                  |Task                           |
|Leaf                       |Project                        |
|Operation                  |Calculate time estimate handler|

|Generic                    | Contextual                    |
|:--------------------------|:------------------------------|
|Component                  |IToDoItem                      |
|Leaf                       |Task                           |
|Composite                  |Project                        |
|Operation                  |Calculate time estimate handler|

# 10. Koji je oblikovni obrazac prikladan za rjesavanje zadatka danog u nastavku i u koju skupinu pripada. Navedite strukturu klasa te pripadajuce metode metode/atribute koje biste koristili i njihove uloge.
Radite na sustavu u kojem je potrebno slati tekstualne poruke, 
ali je iz sigurnosnih razloga potrebno podržati kriptografske 
hash funkcije (algoritme). Riječ je o jednosmjernim funkcijama 
(ireverzibilne) koje iz podataka proizvoljne veličine generiraju 
niz bitova fiksne veličine. Potrebno je podržati različite inačice 
hash funkcija, a u budućnosti je vrlo vjerojatno da će, iz sigurnosnih
razloga, biti potrebno dodati i nove. Ove funkcije moraju biti 
izmjenjive tijekom izvodenja programa bez potrebe za ponovnim prevođenjem.
```cs
    +-------------------------------------+     uses      +-------------------------------+
    |            IHashFunction            |<------------<>|      HashFunctionContext      |
    +-------------------------------------+               +-------------------------------+
    | + ComputeHash(input: string): string|               | - hashFunction: IHashFunction | 
    +-------------------------------------+               +-------------------------------+
              ^                                           | +DoTask()                     |
              |                                           +-------------------------------+
              |                                                 ^
              | implements                                      |
              |                                                 |
    +--------------------------------------+            +-----------------+
    |            MD5HashFunction           |<-----------|     Client      |
    +--------------------------------------+            +-----------------+
    | + ComputeHash(input: string): string |
    +--------------------------------------+
```