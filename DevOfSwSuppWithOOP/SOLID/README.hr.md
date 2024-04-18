# SOLID načela
U ovom poglavlju biti će objašnjeni SOLID principi kodiranja programske podrške u objektno orjentiranim jezicima. Koncepti objašnjeni ovdje vrijede za skoro sve oop jezike. Primjeri ovdje su programirani u C# programskom jeziku. Cilj poglavlja je detaljno i jasno objasniti čitaču svaki od principa te pokazati kako ih primjeniti na jednostavnim primjerima.

SOLID je akronim koji označava pet principa objektno orijentiranog dizajna koji promiču čvrsto, održivo i fleksibilno programiranje. Ovi principi čine temelj dobre prakse u razvoju softvera.

- S, Single responsibilty principle (SRP)
- O, Open closed principle (OCP)
- L, Lisk substitution principle (LSP)
- I, Interface segregation principle (ISP)
- D, Dependency inversion principle (DIP)

Za svaki
Teorija
Profin primjer ili sličan profinom primjeru
Primjer staviti u kod

## SRP
Svaka klasa treba imati samo jednu odgovornost, odnosno odgovornost za jednu funkcionalnost

Neispravno:
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

Ispravno:
```cs
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
}

class UserLogger{
    public void LogUserData(User user){
        Console.WriteLine($"{user.Name}, {user.Surname}")
    }
}

class JSONExporter{
    public JSONFile ExportToJSON(){
        Console.WriteLine($"Export to JSON")
    }
}
```

## OCP
Klase trebaju biti zatvorene za izmjene, ali otvorene za prosirenja

Primjer dolje je sa https://makolyte.com/refactoring-the-switch-statement-code-smell/

Problem:
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

Rješenje:
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
## LSP
Izvedene klase trebaju moci zamijeniti osnovnu. Kršenje LSP dovodi do kršenja OCP.

Problem:
```cs
class Bird{
    public virtual void Walk(){
        Console.WriteLine($"Bird is walking");
    }
    public virtual void Fly(){
        Console.WriteLine($"Bird is jumping");
    }
}

class Emu:Bird{
    public override void Walk(){
        Console.WriteLine($"Bird is walking fast");
    }
    public override void Fly(){
        throw new NotImplementedException ();
    }
} 

class BirdContoler{
    List<Bird> birds;
    public Birds {set{birds = value;}}

    public void MakeBirdsWalk(){
        foreach(bird in birds){
            bird.Walk();
        }
    }

    public void MakeBirdsFLy(){
        foreach(bird in birds){
            bird.Fly();//šta kad naleti na emua?
        }
    }
}
```

Rješenje 1:
```cs
//prve dvije klase ostaju iste
class BirdContoler{
    List<Bird> birds;
    public Birds {set{birds = value;}}

    public void MakeBirdsWalk(){
        foreach(bird in birds){
            bird.Walk();
        }
    }

    //Krsi OCP
    public void MakeBirdsFLy(){
        foreach(bird in birds){
            if(bird.GetType() != typeof(Emu))
                bird.Fly();
        }
    }
}
```

Rješenje 2:
```cs
interface IFlyable{
    public void Fly();
}

interface IWalkable{
    public void Walk();
}

class Emu:IWalkable{
    public void Walk(){
        Console.WriteLine($"Bird is walking fast");
    }
}

class Sparrow: IFlyable, IWalkable{
    public void Walk(){
        Console.WriteLine($"Bird is walking fast");
    }

    public void Fly(){
        Console.WriteLine($"Bird is flying fast");
    }
}

class BirdControler{
    public void MakeBirdsFly(List<IFlyable> birds){
        foreach(IFlyable flyableBird in birds){
            flybleBird.Fly();
        }
    }
}
```

## ISP
Ne treba kroz ugradnju sucelja forsirati implementaciju metoda koje se ne koriste ili nisu potrebne ili nisu valjane za danu klasu

Problem:
```cs
class IBirdable{
    public virtual void Walk(){
        Console.WriteLine($"Bird is walking");
    }
    public virtual void Fly(){
        Console.WriteLine($"Bird is jumping");
    }
}

class Emu:IBirdable{
    public override void Walk(){
        Console.WriteLine($"Bird is walking fast");
    }
    public override void Fly(){
        throw new NotImplementedException ();
    }
} 
```

Rješenje:
```cs
interface IFlyable{
    public void Fly();
}

interface IWalkable{
    public void Walk();
}

class Emu:IWalkable{
    public void Walk(){
        Console.WriteLine($"Bird is walking fast");
    }
}

class Sparrow: IFlyable, IWalkable{
    public void Walk(){
        Console.WriteLine($"Bird is walking fast");
    }

    public void Fly(){
        Console.WriteLine($"Bird is flying fast");
    }
}
```

## DIP
Klase na višim razinama ne trebaju ovisiti o klasama na nižim razinama, nego (oboje) trebaju ovisiti o apstrakciji

Problem:
```cs
class Bird{
    public virtual void Walk(){
        Console.WriteLine($"Bird is walking");
    }
}

class BirdContoler{
    List<Bird> birds;
    public Birds {set{birds = value;}}

    public void MakeBirdsWalk(){
        foreach(bird in birds){
            bird.Walk();
        }
    }
}
```

Rješenje:
```cs
class Iwalkable{
    public void Walk();
}

class BirdContoler{
    List<IWalkable> birds;
    public Birds {set{birds = value;}}

    public void MakeBirdsWalk(){
        foreach(bird in birds){
            bird.Walk();
        }
    }
}
```