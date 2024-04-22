namespace DevOfSwSuppWithOOP.DesignPatterns.Structural.Flyweight{
    namespace Problem{
        public class Weapon
        {
            string name;
            string material;
            string category;
            int dmg;
            public Weapon(int dmg, string name, string material, string category)
            {
                this.name = name;
                this.material = material;
                this.category = category;
                this.dmg = dmg;
                Console.WriteLine($"{dmg} {name} {material} {category}");
            }
        }

        public class Game
        {
            List<Weapon> weapons;
            public Game()
            {
                weapons = new List<Weapon>();
                for (int i = 0; i < 10; i++)
                {
                    weapons.Add(new Weapon(10, "Excalibur", "Metal", "Sword"));
                    weapons.Add(new Weapon(15, "God Killer", "Wooden", "Bow"));
                    weapons.Add(new Weapon(30, "King Slayer", "Bronze", "Spear"));
                }
            }
        }
        public static class ClientCode
        {
            public static void Run()
            {
                new Game();
            }
        }
    }

    namespace Solution{
        public class Weapon
        {
            string name;
            WeaponType weaponType;
            int dmg;

            public Weapon(int dmg, string name, WeaponType weaponType)
            {
                this.name = name;
                this.weaponType = weaponType;
                this.dmg = dmg;
                Console.WriteLine($"{dmg} {name} {weaponType.material} {weaponType.category}");
            }
        }

        public class WeaponType
        {
            public string material;
            public string category;
            public WeaponType(string material, string category)
            {
                this.material = material;
                this.category = category;
            }
        }

        public class WeaponFactory
        {
            public static Dictionary<string, WeaponType> weaponTypes
                = new Dictionary<string, WeaponType>();
            public static WeaponType GetWeaponType(String name)
            {
                return weaponTypes[name];
            }
        }

        public class Game
        {
            List<Weapon> weapons;
            public Game()
            {
                WeaponFactory.weaponTypes.Add("MetalSword", new WeaponType("Metal", "Sword"));
                WeaponFactory.weaponTypes.Add("WoodenBow", new WeaponType("Wooden", "Bow"));
                WeaponFactory.weaponTypes.Add("King Slayer", new WeaponType("Bronze", "Spear"));
                weapons = new List<Weapon>();
                for (int i = 0; i < 10; i++)
                {
                    weapons.Add(new Weapon(10, "Excalibur", WeaponFactory.GetWeaponType("MetalSword")));
                    weapons.Add(new Weapon(10, "God Killer", WeaponFactory.GetWeaponType("MetalSword")));
                    weapons.Add(new Weapon(30, "King Slayer", WeaponFactory.GetWeaponType("MetalSword")));
                }
            }
        }
        
        public static class ClientCode
        {
            public static void Run()
            {
                new Game();
            }
        }
    }
}