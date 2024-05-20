# 1. Dajte prijedloge preimenovanja za imena u danom izlistanju koda za koja smatrate da imaju nedostatke
```cs 
class ProductObject
{
    public string name { get; private set; } // prod. name
    public string price { get; private set; } // prod. price
    public bool InStock { get; set; } // flag - is prod. in stock or not?

    public ProductObject(string n, string p)
    {
        this.name = n;
        this.price = p;
        this.InStock = false;
    }
}
class HandlingOfProducts
{
    List<ProductObject> prodsList; // List of prods.,

    public HandlingOfProducts(List<ProductObject> inv) // inventory of prods.
    {
        prodsList = inv;
    }

    public void revive(ProductObject product)
    {
        foreach (ProductObject prod in prodsList)
        { // make prod. available again
            if (product == prod)
                prod.InStock = true;
        }
    }
    public void endAllUnavailable()
    { // expel the sold out products !!!
        prodsList.RemoveAll(product => product.InStock == false);
    }
}
```
Rješenje:
```cs
class Product
{
    public string Name { get; private set; } 
    public string Price { get; private set; }
    public bool IsStocked { get; set; } 

    public Product(string name, string price)
    {
        Name = name;
        Price = price;
        IsStocked = false;
    }
}

class Inventory
{
    List<Product> products;

    public Inventory(List<Product> products) 
    {
        this.products = products;
    }

    public void Restock(Product outOfStockProduct)
    {
        foreach (Product product in products)
        { 
            if (outOfStockProduct == product)
                product.IsStocked = true;
        }
    }

    public void RemoveAllOutOfStockProducts()
    {
        products.RemoveAll(product => product.IsStocked == false);
    }
}
```
# 2. Refaktorirajte kod dan u sljedećem izlistanju
```cs
List<double> Averages(List<double[]> arraysList)
{
    List<double> avgs = new List<double>(); // resulting list of doubles;
    foreach (double[] a in arraysList)
    {
        double s = 0; // reset necessary
        for (int i = 0; i < a.Length; i++)
            s += a[i];
        avgs.Add(s / a.Length);
    }
    return avgs;
}

double CalculateAvereage(double[] array)
{
    double sum = 0;
    for (int i = 0; i < array.Length; i++)
        sum += array[i];
    return sum / array.Length;
}
```
Rješenje:
```cs
List<double> CalculateAverages(List<double[]> arrays)
{
    List<double> averages = new List<double>(); // resulting list of doubles;
    foreach (double[] array in arrays)
    {
        averages.Add(CalculateAverage(array));
    }
    return averages;
}

double CalculateAverage(double[] array)
{
    double average = 0;
    for (int i = 0; i < array.Length; i++)
    {
        average += array[i];
    }
    return average / array.Length;
}
```
# 3. Dajte primjer pseudokoda koji narusava nacelo ocp te objasnite u cemu se to ogleda i zasto je to problem
```cs
public class Bird
{
	private readonly BirdType birdType;

	public Bird(BirdType type)
	{
		birdType = type;
	}
	public List<BirdColor> GetColors()
	{
		switch (birdType)
		{
			case BirdType.Cardinal:
				return new List<BirdColor>() { BirdColor.Black, BirdColor.Red };
			case BirdType.Goldfinch:
				return new List<BirdColor>() { BirdColor.Black, BirdColor.Yellow, BirdColor.White };
			case BirdType.Chickadee:
				return new List<BirdColor>() { BirdColor.Black, BirdColor.White, BirdColor.Tan };
		}
		throw new InvalidBirdTypeException();
	}
}
```
Ovaj kod narušava OCP jer da bi ga nadogradili tj. dodali novu vrstu ptice u sustav moramo mijenjati metodu GetColors. Bolja alternativa je imati apstaktnu klasu Bird koja ima apstraktnu metodu GetColors iz koje izvodime konkretne klase koje predstavljaju konkretne ptice.

# 4. Na sto se odnosi pojam operacije sacmaricom kao miris u kodu? Navedit nekoliko pristupa za refaktoriranje takvog mirisa.
Operacija sačmaricom su promjene koje nastaju kad potrebno izmjeniti dio klase što uzrokuje promjene u nizu drugih klasa. Potrebno je staviti zajedno stvari koje se zajedno mjenjaju

# 5. U cemu se ogleda nacelo single responsilitiy u sklopu oblikovnog obrasca lanac odgovornosti
Svaki članak u lancu ima jednu odgovornost tj. odgovoran je za jednu funkcionalnost.

# 6. Napišite unit test koji provjerava ispravan rad metode dane sljedećim izlistanjem koda
```cs
public class CompoundChecker
{
    private List<string> harmfulCompounds;
    private int allowedHarmfulCompounds;

    public CompoundChecker(List<string> harmfulCompounds,
    int allowedHarmfulCompounds)
    {
        this.harmfulCompounds = harmfulCompounds;
        this.allowedHarmfulCompounds = allowedHarmfulCompounds;
    }

    public bool IsHarmful(string chemicalCompound)
    {
        int harmfulCompoundCount = 0;
        foreach (string harmfulCompound in harmfulCompounds)
        {
            if (chemicalCompound.Contains(harmfulCompound,
                StringComparison.OrdinalIgnoreCase))
            {
                harmfulCompoundCount++;
            }
        }
        return harmfulCompoundCount > allowedHarmfulCompounds;
    }
}
```
Rješenje:
```cs
[TestFixture]
public class CompoundCheckerTests
{
    [Test]
    public void IsHarmful_ReturnsTrue_WhenChemicalCompoundIsHarmful()
    {
        // Arrange
        List<string> harmfulCompounds = new List<string> { "harmful1", "harmful2" };
        int allowedHarmfulCompounds = 1;
        CompoundChecker compoundChecker = new CompoundChecker(harmfulCompounds, allowedHarmfulCompounds);
        // Act
        bool result = compoundChecker.IsHarmful("This is a harmful1 compound.");
        // Assert
        Assert.IsTrue(result);
    }
}
```

# 7. Navedite tri posljedice uporabe oblikovnog obrasca Memento
1. Omogućava zabilježavanje slike stanja objekta bez kršenja enkapsulacije
2. Previše Memenata može trošiti mnogo RAMa
3. Pojednostavljuješ kod originatora time što implementiraš skrbnika koji se brine o povjesti stanja originatora

# 8.Za primjer dan izlistanjem koda odredite obrazac o kojem je riječ i njegovu skupinu. Dopunite kod implementacijom koja nedostaje te napišite klijentski kod za ovaj primjer.
```cs
public interface IAttack
{
    int TotalDamage { get; }
}

public class PhysicalAttack : IAttack
{
    private const int BoostFactor = 2;

    public PhysicalAttack(bool isBoosted, int damage)
    {
        IsBoosted = isBoosted;
        Damage = damage;
    }

    public bool IsBoosted { get; private set; }
    public int Damage { get; private set; }

    public int TotalDamage
    {
        get { return IsBoosted ? BoostFactor * Damage : Damage; }
    }
}

public class ComboAttack : IAttack
{
    private List<IAttack> attacks = new List<IAttack>();

    public void Add(IAttack attack)
    {
        attacks.Add(attack);
    }

    public void Remove(IAttack attack)
    {
        attacks.Remove(attack);
    }

    public int TotalDamage
    {
        get
        {
            int totalDamage = 0;
            foreach (var attack in attacks)
            {
                totalDamage += attack.TotalDamage;
            }
            return totalDamage;
        }
    }
}
```
Rješenje:
```cs
  public interface IAttack
    {
        int TotalDamage { get; }
    }

    public class PhysicalAttack : IAttack
    {
        private const int BoostFactor = 2;

        public PhysicalAttack(bool isBoosted, int damage)
        {
            IsBoosted = isBoosted;
            Damage = damage;
        }

        public bool IsBoosted { get; private set; }
        public int Damage { get; private set; }

        public int TotalDamage
        {
            get { return IsBoosted ? BoostFactor * Damage : Damage; }
        }
    }

    public class ComboAttack : IAttack
    {
        private List<IAttack> attacks = new List<IAttack>();

        public void Add(IAttack attack)
        {
            attacks.Add(attack);
        }

        public void Remove(IAttack attack)
        {
            attacks.Remove(attack);
        }

        public int TotalDamage
        {
            get
            {
                int totalDamage = 0;
                foreach (var attack in attacks)
                {
                    totalDamage += attack.TotalDamage;
                }
                return totalDamage;
            }
        }
    }

    public static class ClientCode
    {
        public static void Run()
        {
            ComboAttack doubleCombo = new ComboAttack();
            doubleCombo.Add(new PhysicalAttack(false, 10));
            doubleCombo.Add(new PhysicalAttack(false, 10));

            ComboAttack tripleCombo = new ComboAttack();
            tripleCombo.Add(new PhysicalAttack(false, 10));
            tripleCombo.Add(new PhysicalAttack(false, 11));
            tripleCombo.Add(new PhysicalAttack(false, 12));

            ComboAttack tripleDouble = new ComboAttack();
            tripleCombo.Add(tripleCombo);
            tripleCombo.Add(doubleCombo);

            int dmg = tripleCombo.TotalDamage;
        }
    }
```
Obrazc je Kompozit

# 9. Povezite klase, metode i sucelja s njihovim ulogama u obrascu. O kojem obrascu je rijec i kojoj skupini pripada? Navedite dva razloga iz kojih ga je prikladnog koristiti.
|Generic                    | Contextual                 |
|:--------------------------|:---------------------------|
|Klijent                    | Promotional message handler|
|Konkretan obrađivač        | Outlook (e-mail app)       |
|Obrađivač                  | Newsletter message handler |
|                           | Inbox handler              |
|                           | Work message handler       |

|Generic                    | Contextual                 |
|:--------------------------|:---------------------------|
|Klijent                    | Outlook (e-mail app)       |
|Konkretan obrađivač        | Inbox handler              |
|Obrađivač                  | Newsletter message handler |
|Obrađivač                  | Promotional message handler|
|Obrađivač                  | Work message handler       |
- Obrazac: Lanac odgovornosti
- Skupina: Ponašajni
- Koristiti kada program ima nekoliko različitih načina za obraditi zahtjev, ali nije unaprijed poznato kakav će se zahtjev pojaviti u sustavu
- Koristiti kada je važno provesti obradu zahtjeva određenim redosljedom

# 10. Koji je oblikovni obrazac prikladan za rjesavanje zadatka danog u nastavku i 
u koju skupinu pripada. Navedite strukturu klasa te pripadajuce metode 
metode/atribute koje biste koristili i njihove uloge.

Radite na sustavu za analizu i praćenje proizvodnje električne energije.
Trebate dizajnirati element sustava koji prati ukupne iznose trenutne 
proizvodnje i trenutne potrošnje. U slučaju da dođe do značajnog rasta 
ili pada (određeno vrijednošću atributa) u proizvodnji ili potrošnji, 
potrebno je odmah poslati informacije različitim zainteresiranim stranama. 
Potrebno je omogućiti raznorodnim komponentama da reagiraju na promjene 
u proizvodnji i potrošnji, da mogu prestati reagirati ako tako odluče te 
osigurati da bude lako dodati nove takve komponente u sustav.
```cs
                                                            +------------------+
                                                            |     Client       |
                                                            +------------------+
                                                                    | uses
  +------------------------------+    implements    +------------------------------+
  |  ElectricitySystem           |<-----------------|  IElectricitySystem          |
  +------------------------------+                  +------------------------------+
  | -observers: Observer[]       |                  | + Detach(observer: IObserver)|
  +------------------------------+                  | + Attach(observer: IObserver)|
  | + Detach(observer: IObserver)|                  | + Notify()                   |   
  | + CurrentProduction: double  |                  +------------------------------+     
  | + Attach(observer: IObserver)|                  
  | + Notify()                   |                
  +------------------------------+                  
                <>
                |
                |  contains
                |
  +-------------------------------------------------+
  |     IObserver                                   |
  +-------------------------------------------------+
  | + Update(electricitySystem: IElectricitySystem) |
  +-------------------------------------------------+
                ^
                |
                |  observes
                |
  +-------------------------------------------------+
  | ElectricityChangeNotifier                       |
  +-------------------------------------------------+
  | + Update(electricitySystem: IElectricitySystem) |
  +-------------------------------------------------+
```