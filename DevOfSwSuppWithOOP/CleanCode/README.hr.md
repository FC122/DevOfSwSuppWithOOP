# Čist kod
U ovom poglavlju biti će navedene i objašnjene smjernice za pisanje čistog koda. Koncepti objašnjeni ovdje vrijede za skoro programske jezike. Primjeri ovdje su programirani u C# programskom jeziku. Cilj poglavlja je detaljno i jasno objasniti kako pisati čisti kod.

Pogledati video: https://www.youtube.com/watch?v=CFRhGnuXG-4

## Sadržaj
- Ime treba otktivati namjeru
- Funkcije trebaju biti jednostavne

## Koristi svrhovita imena
Navedeno vrijedi za sva imenovanja u programiranju: klase, metode, atribute....

Pogledati ovaj video: https://www.youtube.com/watch?v=-J3wNP6u5YU
### Ime treba otkrivati namjeru
Neispravno:
```cs
class C{
    private string m;
    private int y;
    private double p;
}
```

Ispravno
```cs
class Car{
    private string model;
    private int year;
    private double price;
}
```

### Netreba imati nepotrebne i krive informacije
Neispravno:
```cs
class CarClass{
    private string carModelStr;
    private int carYear;
    private double carPrice;
}
```

Ispravno:
```cs
class Car{
    private string model;
    private int year;
    private double price;
}
```

### Ime treba biti što jednostavno, unikatno i lako prepoznatljivo
Neispravno:
```cs
class FourWheeledWheicleWithAnEngine{
    private string modelOfTheCar;
    private int yearsAmount;
    private double carAmount;
}
```
Ispravno:
```cs
class Car{
    private string model;
    private int year;
    private double price;
}
```

### Treba biti izgovorljivo
Neisrpavno:
```cs
class Carawsd{} 
```

Ispravno:
```cs
class CarComputerControls{}
```

### Nesmije biti šaljivo ni dvosmisleno
Neispravno:
```cs
class SnazzleWagon{}
```
Ispravno:
```cs
class Car{}
```

## Funkcije trebaju biti jednostavne

### Funkcije trebaju biti male
- Male funkcije je lakše razumjeti
- Veliku funkciju razlomiti na više djelova ako je moguće
- Višestruko ugnježđivanje nije poželjno
- Više manjih funkcija je lakše razumjeti nego jednu veliku
- Funkcije trebaju imati mali broj parametara, idealno bez parametara
- Sve više od 3 je zabrinjavajuće i treba izbjegavati

### Funkcije trebaju raditi jednu stvar
Funkcija treba raditi jednu i samo jednu stvar i treba ju raditi dobro.
Nebi trebala raditi ništa u pozadini, nikakvo logiranje ili kalkulacije uz stvar koju radi.
Neispravno:
```cs
class Car{
    private string model;
    private int year;
    private double price;
    
    public string LogAndGetOrSetPrice(int price){
        Console.WriteLine(price);
        if(price != null){
            return price;
        }else{
            this.price = price;
            return "";
        }
    }
}
```
Ispravno:
```cs
class Car{
    private string model;
    private int year;
    private double price
    
    public void LogPrice(){
        Console.WriteLine(price);
    }

    public string GetPrice(){
        return price;
    }

    public void SetPrice(int price){
        this.price = price;
    }
}
```
### Exception-i umjesto kodova za greške
Kodovima je potrebno trenutno rukovati. Exceptionima rukovanje izdvajamo u posebne klase.
```cs
class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Call a method that might throw an exception
            DoSomethingDangerous();
        }
        catch (Exception ex)
        {
            // Handle the exception
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
```
### Izbjegavati switch
Metode koje koriste switch i if-else skoro uvijek rade više od jedne stvari i s vremenom rastu no ponekad ali rijetko su korisne i nije ih potrebno mijenjati. Jedna ili dvije switch funkcije kroz codebase su prihvatljive.

## Oprezno koristi komentare
Nikad ne dodavaj komentare u kod. Kod treba biti čitljiv bez komentara. U slučaju da si prisiljen dodavati komentare trebaju biti kratki i precizni

## Primjeri refaktoriranja
Refaktoriraj zadanu klasu:
```cs
    public class DistanceCalculator
    {
        double[] mostDistant(List<double[]> arrays, double[] target)
        {
            double max = 0, dist;
            int idxMax = 0; //index of the farthest in arrays from target
            for (int i = 0; i < arrays.Count; i++)
            {
                dist = 0; // Euclidean distance between target and i-th vector in arrays 
                for (int j = 0; j < arrays[i].Length; j++)
                    dist += (target[j] - arrays[i][j]) * (target[j] - arrays[i][j]);
                dist = Math.Sqrt(dist);

                if (i == 0 || dist > max)
                {
                    max = dist;
                    idxMax = i;
                }
            }
            return arrays[idxMax]; // farthest from target
        }
    }

```
Rješenje:
```cs
    public class DistanceCalculator
    {
        static double[] FindFarthestVector(List<double[]> vectors, double[] targetVector)
        {
            double distance = EuclideanDistance(vectors[0], targetVector);
            double maxDistance = distance;
            int maxIndex = 0;       
            for (int i = 1; i < vectors.Count; i++)
            {
                distance = EuclideanDistance(vectors[i], targetVector);
                if (distance > maxDistance)
                {
                    maxDistance = distance;
                    maxIndex = i;
                }
            }
            return vectors[maxIndex];
        }

        static double EuclideanDistance(double[] vectorA, double[] vectorB )
        {
            double distance = 0;
            for (int j = 0; j < vectorA.Length; j++)
                distance += Math.Pow((vectorB[j] - vectorA[j]), 2);
            return Math.Sqrt(distance);
        }
    }

```
## Načela

### DRY
DRY (Dont Repeat Yourself) princip u programiranju znači ne ponavljati isti kod već ga organizirati tako da se zajednički dijelovi izdvoje u ponovno koristive dijelove. To olakšava održavanje i čitanje koda jer se izbjegava potreba za traženjem i mijenjanjem istog koda na više mjesta. Time se potiče efikasnost u razvoju softvera jer se fokusira na jedinstvene reprezentacije znanja unutar sustava.

### KISS
KISS je skraćenica za "Keep It Simple, Stupid". To je princip u dizajnu koji potiče jednostavnost i izbjegavanje nepotrebnog kompliciranja. Ideja 
je da što je nešto jednostavnije, lakše je razumjeti, održavati i koristiti.

### YAGNI
YAGNI, kratica za "You Ain't Gonna Need It" (Nećeš to trebati), je princip u softverskom razvoju koji potiče na izbjegavanje dodavanja funkcionalnosti ili kodiranja stvari koje trenutno nisu potrebne. Ovaj princip naglašava važnost fokusa na trenutne zahtjeve i izbjegavanje nepotrebnog dodavanja složenosti ili funkcionalnosti unaprijed. Time se smanjuje gubitak vremena na implementaciju i održavanje nepotrebnih dijelova softvera, čime se poboljšava efikasnost i agilnost u razvoju.

## Zadaci

### Preimenovanje
Preimenuj entitete u zadanom kodu

#### Zadatak1
```cs
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
#### Zadatak2
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

#### Zadatak3
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

#### Zadatak4
```cs
  public class NoteObject
    {
        public string title { get; set; }
        public string text { get; set; }
        public DateTime creation { get; private set; }

        public NoteObject(string titleString, string textString)
        {
            title = titleString;
            text = textString;
            creation = DateTime.Now;
        }
    }

    public class CollectionOfNotes
    {
        public string Author { get; private set; }
        public List<NoteObject> groupOfNotes;

        public CollectionOfNotes(string author)
        {
            Author = author;
            groupOfNotes = new List<NoteObject>();
        }

        public void AddNoteToCollection(NoteObject note)
        {
            groupOfNotes.Add(note);
        }
    }
```

#### Zadatak5
```cs
 public class LocationInformationData
    {
        public DateTime DATC { get; private set; } // created at
        public double LatofLoc { get; private set; } // latitude coordinate
        public double Longofloc { get; private set; } // longitude coordinate

        public LocationInformationData(double Lat, double Long)
        {
            // Constructor implementation
        }
    }

    public class PathManaging
    {
        private List<LocationInformationData> LocationsList; // the path location points

        public PathManaging()
        {
            LocationsList = new List<LocationInformationData>();
        }

        public void AddNewLocationForPath(LocationInformationData location)
        {
            LocationsList.Add(location);
        }

        public void RemoveLocationFromPath(LocationInformationData location)
        {
            LocationsList.Remove(location);
        }
    }
```

### Refaktoriranje
Refaktoriraj zadane isječke programa.

#### Zadatak1
```cs
    // scales the vector to unit length
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
#### Zadatak2
```cs
 class Avg
    {
        List<double> averages(List<double[]> arraysList)
        {
            List<double> avgs = new List<double>(); //resulting list
            double s;
            foreach (double[] a in arraysList)
            {
                //compact code formating
                s = 0;
                for (int i = 0; i < a.Length; i++) s += a[i];
                avgs.Add(s / a.Length);
            }
            return avgs;
        }
    }
```
#### Zadatak3
```cs
    class DistinctClass
    {
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

    }
```
#### Zadatak4
```cs
    class DrugiZadatak
    {
        public static List<char> uniqueChars(string text)
        {
            List<char> chars = new List<char>();
            for (int i = 0; i < text.Length; i++)
            {
                int occurrenceCount = 0;
                for (int j = 0; j < text.Length; j++)
                {
                    if (text[i] == text[j])
                    {
                        occurrenceCount++;
                    }
                }
                if (occurrenceCount == 1)
                {
                    chars.Add(text[i]);
                }
            }
            return chars;
        }
    }
```
#### Zadatak5
```cs
    class DrugiZadatak
    {
        public List<string> palindromes(List<string> strings)
        {
            List<string> res = new List<string>();
            if (strings == null) return res;
            foreach (string str in strings)
            {
                string temp1 = str.Replace(" ", "").ToLower();
                string temp2 = new string(temp1.Reverse().ToArray());
                //Palindrome
                if (temp1.Equals(temp2))
                {
                    res.Add(str);
                }
            }
            return res;
        }
    }
```