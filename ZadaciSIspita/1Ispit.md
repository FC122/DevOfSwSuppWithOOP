# 1. Dajte prijedloge preimenovanja za imena u danom izlistanju koda za koja smatrate da imaju nedostatke
Zadatak:
```c#
 enum ShapesOptions { Circle, Square }
class CakeClass
{
    public int cakeLayersCount { get; private set; }
    public ShapesOptions cakeShapeDescription { get; private set; }
    public bool frostedCake { get; private set; }
    public CakeClass(int layers, ShapesOptions shape, bool frostedOrNot)
    {
        cakeLayersCount = layers;
        cakeShapeDescription = shape;
        frostedCake = frostedOrNot;
    }
}

class SimpleCakeObjectFactory
{
    public static CakeClass CreateCake(string cakeType)
    {
        switch (cakeType)
        {
            case "standard":
                return new CakeClass(2,
                ShapesOptions.Square, false);
            case "fancy":
                return new CakeClass(4,
                ShapesOptions.Circle, false);
            case "wedding":
                return new CakeClass(6,
                ShapesOptions.Circle, true);
            default: return null;
        }
    }
}
```
Rješenje:
```c#
 enum Shape { Circle, Square }
    class Cake
    {
        public int Layers { get; private set; }
        public Shape Shape { get; private set; }
        public bool HasFrosting { get; private set; }
        public Cake(int layers, Shapes shape, bool hasFrosting)
        {
            Layers = layers;
            Shape = shape;
            HasFrosting = hasFrosting;
        }
    }

    class CakeFactory
    {
        public static Cake CreateCake(string type)
        {
            switch (type)
            {
                case "standard": return new Cake(2, Shapes.Square, false);
                case "fancy": return new Cake(4, Shapes.Circle, false);
                case "wedding": return new Cake(6, Shapes.Circle, true);
                default: return null;
            }
        }
    }
```

# 2. Refaktorirajte kod dan u sljedećem izlistanju
```cs
public class LengthManager
{
    public LengthManager()
    {
        double[] array = { 1, 2, 3 };
        unitLengthScaler(array);
    }
    //Refaktorirajte kod dan u sljedecem izlistanju
    void unitLengthScaler(double[] array)
    {
        double L2 = 0;
        // Euclidean distance of the vector to the origin
        // also called the L2 norm (or Euclidean norm) of the vector
        for (int i = 0; i < array.Length; i++)
            L2 += array[i] * array[i];
        L2 = Math.Sqrt(L2);
        // just divide each vector component by its L2 norm
        for (int i = 0; i < array.Length; i++)
            array[i] /= L2;
    }
}
```

Rješenje:
```c#
public class VectorScaler
{
    public void ScaleVectorByEuclideanNorm(double[] vector)
    {
        double vectorNorm = CalculateEuclideanNorm(vector);
        for (int i = 0; i < vector.Length; i++)
            vector[i] /= vectorNorm;
    }

    double CalculateEuclideanNorm(double[] vector)
    {
        double sumOfPowers = 0;
        for (int i = 0; i < vector.Length; i++)
            sumOfPowers += Math.Pow(vector[i], 2);
        return Math.Sqrt(sumOfPowers);
    }
}
```
# 3. Dajte primjer pseudokoda koji narušava dependency inversion te objasnite u čemu se to ogleda te zašto je to problem.
```c#
class Square
{
    public int Length { get; private set; }
}

class AreaCalculator
{
    double CalculateArea(Square square)
    {
        return square.Length * square.Length;
    }
}
```
Primjer iznad krši DIP jer klasa AreCalculator ovisi o klasi Square umjesto da obije ovise o apstrakciji. To je problem kad želimo da AreaCalculator može raditi sa različitim oblicima.

# 4. Na sto se odnosi pojam nakupine podataka kao miris u kodu. Navedite nekoliko pristupa za refaktoriranje takvog mirisa

Nakupina podataka kao miris u kodu odnosi se na klase koje sadrže veliki broj atributa i/ili parametara. Potrebno je razmotriti ima li smisla razbiti klasu na više manjih klasa. U slučaju metode vrijedi isto potrebno razmotriti ima li smisla razbiti metodu na više manjih metoda.

# 5. U cemu se ogleda nacelo single responsibility u sklopu oblikovnog obrasca strategije

Kod oblikovnog obrasca strategija SRP se ogleda u tome što obrazac nalaže da svaka strategija bude implementirana u posebnu klasu s time da sve strategije implementiraju isto sučelje i time svaka klasa ima samo jednu odgovornost tj. odgovornost za jednu funkcionalnost.

# 6. Napišite unit test koji provjerava ispravan rad metode dane sljedećim izlistanjem koda
```c#
class Statistics
{
    public static double FindLargestRange(
        List<List<Double>> measurements)
    {
        double largestRange = 0;
        for (int i = 0; i < measurements.Count(); i++)
        {
            double range = measurements[i].Max()
                - measurements[i].Min();
            if (i == 0 || range > largestRange)
            {
                largestRange = range;
            }
        }
        return largestRange;
    }
}
```

Rješenje:
```c#
[TestFixture]
class StatisticsTests
{
    [Test]
    public void FindLargestRange_Returns_CorrectValue()
    {
        // Arrange
        List<List<double>> measurements = new List<List<double>> {
            new List<double> { 1, 3, 5, 7, 9 }};
        // Act
        double result = Statistics.FindLargestRange(measurements);
        // Assert
        Assert.AreEqual(8, result);
    }
}
```
# 7. Navedite tri posljedice uporabe oblikovnog obrasca Graditelja
1. Omogucava stvaranje objekata korak po korak
2. Broj klasa se povecava a time i komplexnost
3. SRP - kod sklapanja se odvaja od poslovne logike

# 8. Za primjer dan izlistanjem koda odredite obrazac o kojem je riječ i njegovu skupinu. Dopunite kod implementacijom koja nedostaje te napišite klijentski kod za ovaj primjer.
```cs
interface ILiveWeatherForecast
{
    void Register(IWeatherProcessor processor);
    void Unregister(IWeatherProcessor processor);
    void Notify();
}

interface IWeatherProcessor
{
    void OnWeatherChanged(Weather weather);
}

class WeatherForecastProvider : ILiveWeatherForecast
{
    private DateTime lastUpdate = DateTime.Now;
    private Weather currentWeather = WeatherService.GetWeatherForecast();
    private List<IWeatherProcessor> processors = new List<IWeatherProcessor>();

    public void Register(IWeatherProcessor processor)
    {
        processors.Add(processor);
    }

    public void Unregister(IWeatherProcessor processor)
    {
        processors.Remove(processor);
    }

    public void Notify()
    {
        foreach (var processor in processors)
        {
            processor.OnWeatherChanged(currentWeather);
        }
    }

    public void PeriodicUpdate()
    {
        if (DateTime.Now >= lastUpdate.AddHours(1))
        {
            currentWeather = WeatherService.GetWeatherForecast();
            Notify();
        }
    }
}

class WeatherStatistics : IWeatherProcessor
{
    public void OnWeatherChanged(Weather weather)
    {
        // Track weather statistics. Ignore implementation.
    }
}

class WeatherDisplay : IWeatherProcessor
{
    public void OnWeatherChanged(Weather weather)
    {
        // Display weather data. Ignore implementation.
    }
}
```
Rješenje:
```cs
 class Weather { }
class WeatherService
{
    public static Weather GetWeatherForecast()
    {
        return new Weather();
    }
}

interface ILiveWeatherForecast
{
    void Register(IWeatherProcessor processor);
    void Unregister(IWeatherProcessor processor);
    void Notify();
}

interface IWeatherProcessor
{
    void OnWeatherChanged(Weather weather);
}

class WeatherForecastProvider : ILiveWeatherForecast
{
    private DateTime lastUpdate = DateTime.Now;
    private Weather currentWeather = WeatherService.GetWeatherForecast();
    private List<IWeatherProcessor> processors = new List<IWeatherProcessor>();

    public void Register(IWeatherProcessor processor)
    {
        processors.Add(processor);
    }

    public void PeriodicUpdate()
    {
        if (DateTime.Now >= lastUpdate.AddHours(1))
        {
            currentWeather = WeatherService.GetWeatherForecast();
            Notify();
        }
    }

    public void Unregister(IWeatherProcessor processor)
    {
        processors.Add(processor);
    }

    public void Notify()
    {
        processors.ForEach(processor =>
        {
            processor.OnWeatherChanged(currentWeather);
        });
    }
}

class WeatherStatistics : IWeatherProcessor
{
    public void OnWeatherChanged(Weather weather)
    {
        // Track weather statistics. Ignore implementation.
    }
}

class WeatherDisplay : IWeatherProcessor
{
    public void OnWeatherChanged(Weather weather)
    {
        // Display weather data. Ignore implementation.
    }
}

public static class ClientCode
{
    public static void Run()
    {
        WeatherForecastProvider weatherForecastProvider = new WeatherForecastProvider();
        weatherForecastProvider.Register(new WeatherStatistics());
        weatherForecastProvider.Register(new WeatherDisplay());
        while (true)
        {
            weatherForecastProvider.PeriodicUpdate();
        }
    }
}
```
Obrazac je Promatrač.

# 9. Povežite klase, metode i sučelja s njihovim ulogama u obrascu. O kojem obrascu je rječ i kojoj skupini pripada? Navedite dva razloga iz kojih ga je prikladno koristiti.

|Generic                    | Contextual                |
|:--------------------------|:--------------------------|
|Proxy                      | VirtualModel              |
|Subjekt                    | I3dModel                  |
|Konkretan subjekt          | 3dModel                   |
|                           | LoggingModel              |

Rješenje:
|Generic                    | Contextual                |
|:--------------------------|:--------------------------|
|Proxy                      | VirtualModel, LoggingModel|
|Konkretan subjekt          | I3dModel                  |
|Subjekt                    | 3dModel                   |
- Obrazac: Proxy
- Skupina: Strukturni
- Koristiti ga kad je Subjekt tezak na racunalne resurse
- Korisitit ga kad zelimo imati povjest zahtjeva na servis

# 10. Koji je oblikovni obrazac prikladan za rješavanje zadatka danog u nastavku i u koju skupinu pripada? Navedite strukturu klasa te pripadajuće metode/atribute koje biste koristili i njihove uloge
Radite na postojećem sustavu za dohvaćanje izvješća o greškama (engl. bug) s udaljenog poslužitelja 
i njihov prikaz. Klijentska klasa koja predstavlja repozitorij izvješća dobiva ih upora- bom sučelja
IBugReport Provider i njegove metode List<BugReport> GetBugReports (Severity severity). 
Do sada je korištena konkretna klasa BugApi Service koja implementira dano sučelje. Pojavila se 
potreba da sustav podrži novu klasu za pružanje ovih informacija, imena BugsBuster, koja dolazi 
kao dio vanjske biblioteke, a ne ugrađuje niti može ugraditi dano sučelje. Prototip me- tode koju 
pruža BugsBuster je List<BugInfo> RetrieveAll(). Klijentski kod ne treba biti svjestan promjene 
konkretne klase.

```
   +-------------------+
    |    Client         |
    +-------------------+
    | ...               |-----------+ uses
    +-------------------+           |
            |uses                   |
            |                       |    
  +-------------------+          +-----------------------+
  | IBugReportProvider|<---------|  BugApiService        |
  +-------------------+          +-----------------------+
  | + GetBugReports() |          | + GetBugReports()     |
  +-------------------+          +-----------------------+
            ^
            |
            | implements
            |
+--------------------------+
|   BugsBusterAdapter      |
+--------------------------+
| - bugsBuster: BugsBuster |
+--------------------------+
| + GetBugReports()        |
+--------------------------+
            ^
            |
            | depends on
            |
+-------------------+
|    BugsBuster     |
+-------------------+
| + RetrieveAll()   |
+-------------------+
```