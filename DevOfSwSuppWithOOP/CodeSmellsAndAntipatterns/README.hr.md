# Mirisi u kodu i antiobrasci
U ovom poglavlju biti će navedeni i objašnjeni Mirisi u kodu i Antiobrasci te će biti objašnjena razlika između dvoje. Konepti objašnjeni ovdje vrijede za skoro programske jezike. Primjeri ovdje su programirani u C# programskom jeziku. Cilj poglavlja je objasniti kako prepoznati i kako popraviti mirise i antiobrazce u kodu.

## Koja je razlika?
Mirisi u kodu su indikatori da sustav pati od znatnih problema. Antiobrasci su rješenja, pristupi ili metodologije koji nisu učinkoviti tj. loši su i imaju negativne posljedice na sustav.

Ukratko:

- Mirisi su indikatori lošeg koda. Tj. "A vidi, ovdje je ista metoda copy-pasteana triput"
- Antiobrasci su loša rješenja. Tj. "Zast je ovaj lik koristio QuickSort za sortiranje 10 brojeva?"

## Mirisi u kodu
Ako neki kod sadrži nekoliko instanci mirisa u kodu, nije nužno da je kod loš niti je nužno da problemi postoje ali je potrebno razmotriti do čega taj miris može dovesti u budućnosti te ima li smisla popravljati miris i ako ima kako, kakav će to utjecaj imati na sistem te koliko će trajati uz razne druge faktore koji ovise o specifičnoj situaciji.

### Duplicirani kod
Miris koji nastaje kad se isti komadić koda pojavljuje kroz program, klasu ili metodu.
#### Komadić koda koji se ponavlja kroz druge metode i klase
U ovom slučaju ako je moguće i ima smisla taj komadić koda treba staviti u metodu i pozivati ju svagdje gdje se taj kod ponavlja. 
#### Može biti cijela metoda koja je prisutna u više klasa
Potrebno je izbrisati jednu od metode i svagdje koristiti jednu ili prebaciti metodu u novu ili klasu gdje bolje pripada.
#### Mogu biti različite metode koje rješavaju isti problem
U rijetkim slučajevima ovaj pristup je u redu. U slučajevima kad nije potrebno je odabrati bolje rješenje po određenim parametrima i koristit ga svagdje
#### Može biti nepotrebno instanciranje objekta više puta
Ako je objekt instanciran isponova u više metoda klase potrebno ga je referencirati na razini klase i instancirati ga u konstruktoru. Nema smisla u slučajevima kad se ista klasa instancira sa razlicitim parametrima u različitim metodama.

Neispravno:
```cs
class Player{
    Bulets bulets;
    Location location
    public Player(){
        bulets = new Bulets(100)
        location = new Location(0,0);
    }
    public void Shoot(){
        AnimationControler animationControler = new AnimationControler();
        ShootingAnimation shootingAnimation = new ShootingAnimation()
        animationControler.LoadAnimation(shootingAnimation);
        animationControler.ExecuteAnimation();
        animationControler.FinishAnimtion();
        bulets.Pop();
    }
    public void Walk(Direction direction){
        AnimationControler animationControler = new AnimationControler();
        WalkingAnimation walkingAnimation = new WalkingAnimation()
        animationControler.LoadAnimation(walkingAnimation);
        animationControler.ExecuteAnimation();
        animationControler.FinishAnimtion();
        location.Update(direction);  
    }
}
```
Ispravno:
```cs
class Player{
    AnimationControler animationControler;
    Bulets bulets;
    Location location
    public Player(){
        animationControler = new AnimationControler();
        bulets = new Bulets(100)
        location = new Location(0,0);
    }
    public void Shoot(){
        RunAnimation(new ShootingAnimation())
        bulets.Pop();
    }
    public void Walk(Direction direction){
        RunAnimation(new WalkingAnimation())
        location.Update(direction);  
    }
    public void RunAnimation(Animation animation){
        animationControler.LoadAnimation(animation);
        animationControler.ExecuteAnimation();
        animationControler.FinishAnimtion();
    }
}
```
### Velike metode
Metoda sa previše parametara i previše linija koda. Velike metode je potrebno rasjeći na više malih smislenih metoda koje pomažu razumljivosti velike metode.

#### Metoda s velikim brojem linija
Podjeliti metodu na smislene dijelove. Svaki smisleni dio staviti u novu metodu te nove metode referencirati u velikoj metodi umjesto komadića koda.

Neispravno:
```cs
class UserControler{
    public void Register(string name, string password){
        if(name< 3 || name > 20){
            throw new ParameterNotValidException(name);
        }
        if(password<3 || password> 20){
            throw new ParameterNotValidException(surname);
        }
        DatabaseService.Insert(new User(name, password));
    }
}
```
Ispravno:
```cs
class UserControler{
    public void Register(string name, string password){
        ValidateInput(name);
        ValidateInput(surname);
        DatabaseService.Insert(new User(name, password));
    }

    void ValidateInput(string input){
         if(input< 3 || input > 20){
            throw new ParameterNotValidException(input);
        }
    }
}
```


#### Metoda s velikom brojem parametara
Potrebno razmotriti mogućnost spajanja nekih parametara u novi objekt i referencirati objekt umjesto parametara

Neispravno:
```cs
public void CreateCustomer(string firstName, string lastName, int age, string email, string address, string city, string postalCode)
{
    //Neka logika
}
```
Ispravno:
```cs
public class Customer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
}

public void CreateCustomer(Customer customer)
{
    //Neka logika
}

```
#### Ne razumljiva metoda
Ako je metoda glomazna i tesko razumljiva potrebno je komadiće logike enkapsulirati u manje metode koje imenom otkrivaju sto rade sto na kraju veliku metodu čini razumljivijom
Neispravno:
```cs
public class DistanceCalculator
{
    public static double? CalculateDistance(double?[] point1, double?[] point2, DistanceMetric metric = DistanceMetric.Euclidean)
    {
        if (point1 == null || point2 == null)
            throw new ArgumentNullException("Points cannot be null.");

        if (point1.Length != point2.Length)
            throw new ArgumentException("Points must have the same dimensionality.");

        double sum = 0.0;

        for (int i = 0; i < point1.Length; i++)
        {
            if (!point1[i].HasValue || !point2[i].HasValue)
                return null; // If any coordinate is missing, return null

            double difference = Math.Abs(point1[i].Value - point2[i].Value);

            switch (metric)
            {
                case DistanceMetric.Euclidean:
                    sum += difference * difference;
                    break;
                case DistanceMetric.Manhattan:
                    sum += difference;
                    break;
                default:
                    throw new ArgumentException("Unsupported distance metric.");
            }
        }

        switch (metric)
        {
            case DistanceMetric.Euclidean:
                return Math.Sqrt(sum);
            case DistanceMetric.Manhattan:
                return sum;
            default:
                throw new ArgumentException("Unsupported distance metric.");
        }
    }
}
```
Ispravno:
```cs
public class DistanceCalculator
{
    public static double? CalculateDistance(double?[] point1, double?[] point2, DistanceMetric metric = DistanceMetric.Euclidean)
    {
        ValidatePoints(point1, point2);

        double sum = CalculateDistanceSum(point1, point2, metric);

        return CalculateFinalDistance(sum, metric);
    }

    private static void ValidatePoints(double?[] point1, double?[] point2)
    {
        if (point1 == null || point2 == null)
            throw new ArgumentNullException("Points cannot be null.");

        if (point1.Length != point2.Length)
            throw new ArgumentException("Points must have the same dimensionality.");
    }

    private static double CalculateDistanceSum(double?[] point1, double?[] point2, DistanceMetric metric)
    {
        double sum = 0.0;

        for (int i = 0; i < point1.Length; i++)
        {
            if (!point1[i].HasValue || !point2[i].HasValue)
                return double.NaN; // If any coordinate is missing, return NaN

            double difference = Math.Abs(point1[i].Value - point2[i].Value);

            switch (metric)
            {
                case DistanceMetric.Euclidean:
                    sum += difference * difference;
                    break;
                case DistanceMetric.Manhattan:
                    sum += difference;
                    break;
                default:
                    throw new ArgumentException("Unsupported distance metric.");
            }
        }

        return sum;
    }

    private static double? CalculateFinalDistance(double sum, DistanceMetric metric)
    {
        if (double.IsNaN(sum))
            return null;

        switch (metric)
        {
            case DistanceMetric.Euclidean:
                return Math.Sqrt(sum);
            case DistanceMetric.Manhattan:
                return sum;
            default:
                throw new ArgumentException("Unsupported distance metric.");
        }
    }
}
```

#### Veliki broj komentara
Na svakom mjestu gdje je prisutan komentar razmotriti potrebu dodavanja nove metode umjesto koda koji je komentiran. Nova metoda bi se zvala slicno kao i komentar u većini slučajeva.
Neispravno:
```cs
void FindLongestWord(List<double[]> words){
    int maxLength = 0;
    foreach(word in words){
        if(word.Length > maxLength){//Checks which word is longer
            maxLength = word.Length;
        }
    }
}
```
Ispravno:
```cs
void FindLongestWord(List<double[]> words){
    int maxLength = 0;
    foreach(word in words){
        maxLength = CompareValues(word.Length, maxLength)
    }
}

int CompareValues(int wordA, int wordB){
    if(wordA>wordB){
        return wordA;
    }
    return wordB
}
```
#### Puno privremenih varijabli
Napraviti novu klasu gdje su privremene varijable metode atributi nove klase a klasa sadrži tu metodu.
Dobar primjer: https://blog.ploeh.dk/2015/09/18/temporary-field-code-smell/

### Velike klase
Klase sa velikim brojem atributa i velikim brojem velikih metoda. Za velike metode je potrebno napraviti ono što je navedeno u poglavlju [Velike metode](#velike-metode). Za atribute je potrebno razmotriti ima li smisla grupirati određene atribute u novu klasu i koristiti tu klasu umjesto brojnih atributa slično kao u poglavlju [Metode s velikim brojem parametara](#metoda-s-velikom-brojem-parametara)

### Zavidne metode
Metode koje koriste veliki broj varijabl i/ili metoda iz neke druge klase. Za takve metode je potrebno razmotriti ima li smisla prebaciti ih u klasu gdje su atribute koje ta metoda koristi
#### Dio metode koristi podatke druge klase
Ako je moguće, dio metode koji koristi podatke druge klase je potrebno prebaciti u tu drugu klasu kao zasebnu metodu te tu novu metodu koristiti u početnoj.
#### Metoda koristi podatke iz više drugih klasa
Ako je moguće, odrediti koja klasa se najviše koristiti u metodi te premjestit metodu tamo.
Neispravno:
```cs
class ShapeRenderer{
    public Constants Const { get; set; }
    public Math Math{ get; set; }
    ...
    public double Scale(int value, int norm){
        return value/norm;
    }
}

class CircleControler{
    ...
    public void RenderCircle(double radius){
        Shaper shaper = new Shaper()
        radius = shaper.Scale(radius, 2);
        RenderShape(shaper.Math.Pow(radius,2)*shaper.Const.Pi)
    }
    ...
    public void CreateTarget(){
        RenderCircle(2);
        RenderCircle(3);
        RenderCircle(4);
    }
}
```
Ispravno:
```cs
class ShapeRenderer{
    public Constants Const { get; set; }
    public Math Math{ get; set; }
    ...
    public double Scale(int value, int norm){
        return value/norm;
    }
    public void RenderCircle(double radius){
        radius = shaper.Scale(radius, 2);
        RenderShape(shaper.Math.Pow(radius,2)*shaper.Const.Pi)
    }
}

class CircleControler{
    ShapeRenderer shapeRenderer;
     public void CreateTarget(){
        shapeRenderer.RenderCircle(2);
        shapeRenderer.RenderCircle(3);
        shapeRenderer.RenderCircle(4);
    }
}
```
### Nakpunine podataka
Kad klasa sadrži veliki broj atributa i/ili kad metoda sadrži veliki broj parametara. Potrebno je razmotriti ima li smisla razbiti klasu na više manjih klasa. U slučaju metode vrijedi isto potrebno razmotriti ima li smisla razbiti metodu na više manjih metoda. Slično kao u [Metode s velikim brojem parametara](#metoda-s-velikom-brojem-parametara)

### Odbijeno nasljedstvo
Radi se o dječijim klasama koje ne koriste sve atribut i metode svojih roditelja. Vrlo vjerovatno se radi o krivo sastavljenoj hijerarhiji klasa. U slučaju da ovo stvara preveliki problem razmisli ima li smilsa koristi kompoziciju umjesto nasljedivanja.
Dobar blog sa primjerima u Javi: https://www.geeksforgeeks.org/favoring-composition-over-inheritance-in-java-with-examples/
Dobar blog sa primjerima u C#: https://code-maze.com/csharp-composition-vs-inheritance/

### Lijene klase
Male klase koje su često neptorebne i potrebno ih je ukloniti ili spojiti sa roditeljkom klasom ili nekom drugom klasom s kojim imas smisla biti spojena. Ponekad ima smisla ostaviti ju kakva je jer moeže uzrokovati probleme u sustavu zbog brkanja zavisnosti.
Alt objašnjenj: https://code-smells.com/dispensables/lazy-class

### Privremeni atributi
Atributi koji su povremeno ili rjetko korišteni, zbog njih je kod teže razumjeti. Takvi atributi nisu nužni i može ih se izdvojiti u drugu klasu.
Dobar primjer: https://blog.ploeh.dk/2015/09/18/temporary-field-code-smell/

### Divergentne promjene vs Operacija sačmaricom
Divergente promjene se odnose na promjene koje nastaju kad je potrebno izmjeniti dio klase što uzrokuje promjene u drugim dijelovima klase. S druge strane Operacija sačmaricom su promjene koje nastaju kad potrebno izmjeniti dio klase što uzrokuje promjene u nizu drugih klasa.
Dobar blog: https://code-maze.com/csharp-refactoring-change-preventers/

### Podatkovne klase
Klase koje sadrže samo atribute, geter i seter bez metoda koje imaju neku svrhu. Služe kao spremnici za podatke (u Kotlinu postoje podatkovne klase specifično za ovu svrhu). Data klase nisu same u sebi loše i ponekad imaju svrhu. 

Ako ih ima smisla koristiti potrebno je paziti na enkapsulaciju podataka. To uljučuje da podatci trebaju biti privtni i imati geter i setere samo ako je potrebno. Za kolekcije je potrebno pobrinuti se da ne vraćamo kolekciju već pogled na kolekciju i pripadne metode za modifikaciju kolekcije.

Ako neke klase/metode većinski koriste podatke Podatkovne klase vidjeti ima li smisla prebaciti ih u tu klasu/metodu

Dobar blog: https://code-smells.com/dispensables/data-class

### Opsežna uporaba komentara
Komentari skoro nikada nisu potrebni. Ako kod sadrži komentare, komentirani dio je vrlo vjerovatno potrebno prevaciti u novu metodu i nazvati tu metodu na način da je razumljivo što radi i umjesto komentiranog koda korisiti novo napravljenu metodu.
Pogledati ovaj video: https://www.youtube.com/watch?v=Bf7vDBBOBUA
### Naredba switch
Switch je moguće koristiti u OOP jezicima ali je rjetko poželjno zbog alternativa koje OOP nudi polimorfizmom i nasljedivanjem. Jedna ili dvije switch naredbe u sustavu su ok i nebi trebale stvarati problem. Često korištena kao Jednostavna tvornica (nije oblikovni obrazac) koja stvara različite objekte iste klase.

Primjer dolje je sa https://makolyte.com/refactoring-the-switch-statement-code-smell/

Neispravno:
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
	public List<BirdFood> GetFoods()
	{
		switch (birdType)
		{
			case BirdType.Cardinal:
				return new List<BirdFood>() { BirdFood.Insects, BirdFood.Seeds, BirdFood.Fruit};
			case BirdType.Goldfinch:
				return new List<BirdFood>() { BirdFood.Insects, BirdFood.Seeds };
			case BirdType.Chickadee:
				return new List<BirdFood>() { BirdFood.Insects, BirdFood.Fruit, BirdFood.Seeds };
		}
		throw new InvalidBirdTypeException();
	}
	public BirdSizeRange GetSizeRange()
	{
		switch (birdType)
		{
			case BirdType.Cardinal:
				return new BirdSizeRange() { Lower=8, Upper=9 };
			case BirdType.Goldfinch:
				return new BirdSizeRange() { Lower=4.5, Upper=5.5 };
			case BirdType.Chickadee:
				return new BirdSizeRange() { Lower=4.75, Upper=5.75 };
		}
		throw new InvalidBirdTypeException();
	}
}
```

Ispravno:
```cs
public abstract class Bird
{
	public abstract List<BirdColor> GetColors();
	public abstract List<BirdFood> GetFoods();
	public abstract BirdSizeRange GetSizeRange();

	public static Bird Create(BirdType birdType)
	{
		switch (birdType)
		{
			case BirdType.Cardinal:
				return new Cardinal();
			case BirdType.Chickadee:
				return new Chickadee();
			case BirdType.Goldfinch:
				return new Goldfinch();
			default:
				throw new InvalidBirdTypeException();
		}
	}
}

public class Cardinal : Bird
{
	public override List<BirdColor> GetColors()
	{
		return new List<BirdColor>() { BirdColor.Black, BirdColor.Red };
	}

	public override List<BirdFood> GetFoods()
	{
		return new List<BirdFood>() { BirdFood.Insects, BirdFood.Seeds, BirdFood.Fruit };
	}

	public override BirdSizeRange GetSizeRange()
	{
		return new BirdSizeRange() { Lower = 8, Upper = 9 };
	}
}

public class Chickadee : Bird
{
	public override List<BirdColor> GetColors()
	{
		return new List<BirdColor>() { BirdColor.Black, BirdColor.White, BirdColor.Tan };
	}

	public override List<BirdFood> GetFoods()
	{
		return new List<BirdFood>() { BirdFood.Insects, BirdFood.Fruit, BirdFood.Seeds };
	}

	public override BirdSizeRange GetSizeRange()
	{
		return new BirdSizeRange() { Lower = 4.75, Upper = 5.75 };
	}
}

public class Goldfinch: Bird
{
	public override List<BirdColor> GetColors()
	{
		return new List<BirdColor>() { BirdColor.Black, BirdColor.Yellow, BirdColor.White };
	}

	public override List<BirdFood> GetFoods()
	{
		return new List<BirdFood>() { BirdFood.Insects, BirdFood.Seeds };
	}

	public override BirdSizeRange GetSizeRange()
	{
		return new BirdSizeRange() { Lower = 4.5, Upper = 5.5 };
	}
}
```
### Čovjek u sredini
Kad klasa služi kao posrednik između klijenta i klase koja obavlja posao. Ako želimo dodati novu funkcionlanost u klasu koja obavlja posao moramo dodati i nove metode u klasu koja služi kao posrednik kako bi se nove funkcionalnosti mogle koristiti u klijentskom kodu.
Primjer dolje je sa: https://www.thecodebuzz.com/middle-man-code-smell-resolution-examples

Neispravno:
```cs
class Program
 {
    static void Main(string[] args)
     {
         Person person = new Person();
         person = person.GetManager();
     }
 }
 
 
 class Person
 {
     public Department Department { get; set; }
     public Person GetManager()
     {
         return Department.GetManager();
     }
 }
 
 
 class Department
 {
     private readonly Person _manager;
     public Department(Person manager)
     {
         _manager = manager;
     }
     public Person GetManager()
     {
         return _manager;
     }
 }
```

Ispravno:
```cs
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            Department department = person.GetDepartment();
            person = department.GetManager();
        }
    }

    class Person
    {
        public Department Department;
        public Department GetDepartment()
        {
            return Department;
        }
    }
 
    class Department
    {
        private readonly Person _manager;
        public Department(Person manager)
        {
            _manager = manager;
        }
        public Person GetManager()
        {
            return _manager;
        }
    }
```

## Antiobrasci
Ako neki sustav pati od jednog ili više antiobrazaca potrebno je razmotriti o kojim se obrascima radi te koja se moguća rješenja mogu implementirati kako bi se suzbili utjecaji antiobrazaca. Potrebno je razmotriti do čega antiobrazci u sustavu mogu s vremenom dovesti, ima li ih smisla popravljati i ako ima koliko će popravljanje trajati.

### Božanska klasa
Antiobrazac kod kojeg jedna klasa sadrži previše metoda i atributa te je prevelika odgovornost na njoj i krši načela OOP-a. Takvu klasu je moguće i potrebno razdvojiti na više manjih klasa grupiranjem srodnih atributa i metoda božanske klase.

### Mrtav kod
Kod u sustavu koji nesluži nikakvoj svrsi, često zbunjujuć i nije jasno što točno radi. Najčešće nema nikakvih posljedica ukljanjanja takvog koda i poželjno je.

### Funkcijska dekompozicija
Proceduralni pristup u objektno orijentiranom programiranju koje se često manifestira u forsiranju proceduralnog dizajna u objektno orjentiranom jeziku gdje to nema smisla. Očituje se u manjku OOP strukture ne korištenju kompozcije niti nasljedivanje što često rezultira klasama koje imaju jednu metodu koja se zove slično kao i klasa.

Dobar izvor: https://sourcemaking.com/antipatterns/functional-decomposition

### Poltergeist
Antiobrazac koji opisuje dizajn sustava gdje postoje klase koje se instanciraju, odrade nešto posla i ostatak životnog vremena provedu ne radeći ništa tj. samo zauzimaju nepotrebne resurse.

Dobar izvor: https://sourcemaking.com/antipatterns/poltergeists

### Zlatni čekić
Antiobrazac koji se manifestira korištenjem istog pristupa za sve probleme u sustavu.

Dobar izvor: https://sourcemaking.com/antipatterns/golden-hammer

### Špageti kod
Antiobrazac koji opisuje sustav s lošom oop strukturom na način da ga je teško održavati, manjka u nasljedivanju i kompoziciji i ako ih koristi ne radi to ispravno i s time pridonisi ne razumljivosti koda.

Dobar izvor: https://sourcemaking.com/antipatterns/spaghetti-code

### Cut and paste programiranje
Pojavljivanje istih ili sličnih dijelova kod na više mjesta u aplikaciju. Nastaje kad copy-pastamo kod iz jednog dijela aplikacije u drugi. Opasno jer kod koji kopiramo moze sadržavati bugove koje onda raznosimo po sustavu i kad treba popraviti taj bug potrebno ga je naći popraviti na  više mjesta.

### Magični brojevi i stringovi
Zboj uporabe loših značenje konstanti je djelomično ili potpuno skriveno.

### Realni tipovi za novac
Kod korištenja realnih tipova podatak za predstavljanje novca dolazi do grešaka u zaokruživanju pri izvođenju operacija nad brojevima što stvara neželjen deficit ili suficit. Novce je potrebno predstaviti sa cjelobrojnim tipovima podataka ili koristiti posebne tipove za novce.

### Strah od dodavanja klasa
Loša metodologija kod koje programer umjesto da definira novu klasu sa novom potrebnom metodom i atributima stavlja novu metodu i atribute u postojeću klasu. Ovakav pristup negativno utječa na čitljivost

## STUPID code
Šest pristupa u kodiranju koji rezultiraju sustavom koji nije modularan, kojeg je teško testirati te je otporan na promjene.

- Singleton
Oblikovni obrazac koji ograničava broj instanci u sustavu na način da postoji jedna instanca dostupna kroz cijeli sustav.To je nekad poželjno no često krivo korišteno na mjestime gdje nije potreban.
- Tight coupling
Čvrsta sprega je pojava u oop sustavima gdje promjena jedne klase zahtjeva promjenu druge. Nekad imas smisla implementirati ali najčešće želimo imati sustav čije komponente lako zamjenjive.
- Untestability
U kontekstu oop-a odnosi se na unit testiranje tj. testiranje klasa. Ako su dvije klase previše ovisne jedna o drugoj to otežava testiranje
- Premature optimisation
Događa se programer nepotrebno komplicira ili previse misli pri implementaciji (engl. overthingking) i onda napravi nepotrebno kompleksan sustav. Pri implementaciji bilo koje funkcionalnosti prvo nakodiraj funkcionalnsot da radi a tek nakon što funkcionalnost radi vidi trebaš li je optimizirati ili ne.
- Indescriptive naming
[Koristi svrhovita imena](/DevOfSwSuppWithOOP/CleanCode/README.hr.md#koristi-svrhovita-imena)
- Duplication
[Duplicirani kod](#duplicirani-kod)
