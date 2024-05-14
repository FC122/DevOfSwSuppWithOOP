```cs
interface Ciphering {
    string Encryption(string text);
    string Decryption(string text);
}

class CeasarCipherAlgorithm : Ciphering {
    public string Encryption(string text) {
        // Implement Caesar cipher encryption logic
    }

    public string Decryption(string text) {
        // Implement Caesar cipher decryption logic
    }
}

class TheMessage {
    public string plaintext { get; private set; } // The readable text is called 'plaintext' in cryptography
    private Ciphering algorithmOfCipher;

    public TheMessage(string text, Ciphering cipher) {
        plaintext = text;
        algorithmOfCipher = cipher;
    }

    public void ChangePlaintextValue(string text) {
        plaintext = text;
    }

    public void AdjustCipher(Ciphering cipher) {
        algorithmOfCipher = cipher;
    }

    public string EncryptTheMessage() {
        return algorithmOfCipher.Encryption(plaintext); // Returns the ciphertext (the encrypted text)
    }
}

```


Nakodiraj jedan primjer čvrste sprege i jedan primjer labave sprege.



Refaktorirajte kod dan u sljedećem izlistanju. U crticama objasnite što i zašto je obuhvaćeno refaktoriranjem
```cs
List<int> extraction (List<int> 1st){
    List<int> extract = new List<int>(); 
    double avg = 0; 
    foreach (int el in 1st) 
        avg+= el;
    avg / 1st.Count;

    foreach (int el in 1st) 
        if (el > avg) extract.Add(el):
    return extract;
}
```

```cs
List<int> FindGreaterThanAverage(List<int> numbers){
    List<int> greaterThanAverage = new(); 
    double average = FindAverage(numbers)
    foreach (int numbers in numbers) 
        if (number > average) greaterThanAverage.Add(number);
    return greaterThanAverage;
}

double FindAverage(List<int> numbers){
    double sum = 0; 
    foreach (int number in numbers) 
        sum+= number;
    return sum / numbers.Count;
}
```





Objasnite što je načelo "open-closed". Dajte primjer pseudokoda koji ga narušava i objasnite u čemu se to ogleda i zašto je to problem. Prepravite kod tako da poštuje navedeno načelo.





Objasnite liskov princip. Dajte primjer pseudokoda koji ga narušava i objasnite u čemu se to ogleda i zašto je to problem.
```cs
    public interface IAttack{int TotalDamage { get; }}
    public class PhysicalAttack : IAttack{
        private const int BoostFactor = 2;
        public PhysicalAttack(bool isBoosted, int damage){
            IsBoosted = isBoosted;
            Damage = damage;
        }
        public bool IsBoosted { get; private set; }
        public int Damage { get; private set; }
        public int TotalDamage{
            get { return IsBoosted ? BoostFactor * Damage : Damage; }
        }
    }
    public class ComboAttack : IAttack{
        private List<IAttack> attacks = new List<IAttack>();
        public void Add(IAttack attack){
            attacks.Add(attack);
        }
        public void Remove(IAttack attack){
            attacks.Remove(attack);
        }
        public int TotalDamage{
            get{
                int totalDamage = 0;
                foreach (var attack in attacks){
                    totalDamage += attack.TotalDamage;
                }
                return totalDamage;
            }
        }
    }
```






Primjeri napravljeni na predavanju:
```c#
//singleton class
public class GameManager
{
    private static GameManager gameManager;

    public static GameManager GetGameManager()
    {   // lazy initialization
        if (gameManager == null)
        {
            gameManager = new GameManager();
        }
        return gameManager;
    }

    public void GetConfigs()
    {
        Console.WriteLine("Configs");
    }
}

//Usage
static void Main(string[] args)
{
    GameManager gameManager = new GameManager()
    gameManager.GetConfigs();
}
```


 enum Engine {V8, V6, W12}
    enum Tires {Winter, Summer}
    enum Collor {Red, Black, Gray}

    class CarDirector{
        Car car1 = new Car();
        IDrivable carBuilder;
        public CarDirector(IDrivable carBuilder){
            this.carBuilder = carBuilder;
        }

        public Car BuildRedV8(){
            return carBuilder.AddEngine(Engine.V8).AddCollor(Collor.Red).Build();
        }
    }

    interface IDrivable {
        public CarBuilder AddEngine(Engine engine);
        public CarBuilder AddCollor(Collor collor);
        public CarBuilder AddTires(Tires tires);
    }

    interface IClonable{
        public object Clone();
    }

    

    class Car:IClonable{
        CarDirector carDirector1 = new CarDirector(new CarBuilder());
        private string name;
        public Engine Engine {get;set;}
        public Tires Tires {get;set;}
        public Collor Collor {get;set;}
        public Car(Engine engine, Tires tires, Collor collor, string name) {
            Engine = engine;
            Tires = tires;
            Collor = collor;
            this.name = name;
        }

        public Car(){}

        public object Clone()
        {
            Car car = new Car(this.Engine,this.Tires,this.Collor,this.name);
            return car;
        }
        //...
    }

    class CarBuilder:IDrivable{
        Car car;
        public CarBuilder(){
            car = new Car();
        }

        public CarBuilder AddEngine(Engine engine){
            car.Engine = engine;
            return this;
        }

        public CarBuilder AddTires(Tires tires){
            car.Tires = tires;
            return this;
        }

        public CarBuilder AddCollor(Collor collor){
            car.Collor = collor;
            return this;
        }

        public CarBuilder Reset(){
            car = new Car();
            return this;
        }

        public Car Build(){
            return car;
        }

    }





    class CharacterManager{
        IBuildable characterBuilder;

        public CharacterManager(IBuildable characterBuilder) {
            this.characterBuilder = characterBuilder;
        }

        public void ChangeBuilder(IBuildable characterBuilder) {
            this.characterBuilder = characterBuilder;
        }

        public Character SteelDwarf(Height height, Sex sex){
            return characterBuilder
            .Reset()
            .SetRace(Race.Dwarf)
            .SetArmor(Armor.Steel) 
            .SetHeight(height)
            .SetSex(sex)
            .Build();
        }
    }

    enum Race{Elf, Dwarf, Orc}
    enum Armor{Steel, Leather, NoArmor}
    enum Height {Short, Mid, Tall, Giant}
    enum Sex{Male, Female, Other}

    class Character: ICloneable{
        private string weight;
        public string Name {get; set;}
        public Race Race { get; set;}
        public Height Height  { get; set;}
        public Armor Armor  { get; set;}
        public Sex Sex { get; set;}

        public Character(string name, Race race, Height height, Armor armor, Sex sex){
            this.Name = name;
            Race = race;
            Height = height;
            Armor = armor;
            Sex = sex;
        }

        public object Clone(){
           Character character = new Character(this.Name,this.Race,this.Height,this.Armor,this.Sex);
            character.weight = this.weight;
            return character;
        }

        public Character(){}
        //...neke metode
    }

    interface IClonable{
        public object Clone();
    }

    interface IBuildable{
        public CharacterBuilder Reset();
        public CharacterBuilder SetName(string name);
        public CharacterBuilder SetRace(Race race);
        public CharacterBuilder SetHeight(Height height);
        public CharacterBuilder SetArmor(Armor arm);
        public CharacterBuilder SetSex(Sex sex);
        public Character Build();
    }

    class CharacterBuilder:IBuildable{
        private Character character;

        public CharacterBuilder(){
            this.character = new Character();
        }

        public CharacterBuilder SetName(string name){
            this.character.Name = name;
            return this;
        }

        public CharacterBuilder SetRace(Race race){
            this.character.Race = race;
            return this;
        }

        public CharacterBuilder SetHeight(Height height){
            this.character.Height = height;
            return this;
        } 

        public CharacterBuilder SetSex(Sex sex){
            this.character.Sex = sex;
            return this;
        }

        public CharacterBuilder SetArmor(Armor armor){
            this.character.Armor = armor;
            return this;
        }

        public CharacterBuilder Reset(){
            character = new Character();
            return this;
        }

        public Character Build()
        {
            return this.character;
        }
    }








