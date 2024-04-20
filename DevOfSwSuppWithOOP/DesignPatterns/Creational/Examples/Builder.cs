namespace DevOfSwSuppWithOOP.DesignPatterns.Creational.Builder{
    namespace Problem{
        public interface Type { }
        public class Fire : Type { }
        public class Water : Type { }
        public class Normal : Type { }

        public interface Species { }
        public class Human : Species { }
        public class Elf : Species { }
        public class Dwarf : Species { }

        public interface Armor { }
        public class SteelArmor : Armor { }
        public class LeatherArmor : Armor { }

        public class Player{
            Type type;
            Species species;
            Armor armor;
            public Player(Type type, Species species, Armor armor){
                this.type = type;
                this.species = species;
                this.armor = armor;
            }
            public void Play(){
                Console.WriteLine("Play");
            }
        }

        class ClientCode
        {
            public static void Run()
            {
                Player steelDwarf = new (new Fire(), new Dwarf(), new SteelArmor());
                steelDwarf.Play();
            }
        }
    }

    namespace Solution{
        public interface Type { }
        public class Fire : Type { }
        public class Water : Type { }
        public class Normal : Type { }

        public interface Species { }
        public class Human : Species { }
        public class Elf : Species { }
        public class Dwarf : Species { }

        public interface Armor { }
        public class SteelArmor : Armor { }
        public class LeatherArmor : Armor { }

        public class Player
        {
            public Type Type {get; set;}
            public Species Species {get; set;}
            public Armor Armor {get; set;}

            public Player(){}

            public Player(Type type, Species species, Armor armor)
            {
                Type = type;
                Species = species;
                Armor = armor;
            }

            public void Play()
            {
                Console.WriteLine("Play");
            }
        }

        public interface IPlayerBuilder{
            public IPlayerBuilder Type(Type type);
            public IPlayerBuilder Spicies(Species species);
            public IPlayerBuilder Armor(Armor armor);
            public IPlayerBuilder Reset();
            public Player Build();
        }

        public class PlayerBuilder : IPlayerBuilder
        {
            Player player;
            public PlayerBuilder(){
                player = new Player();
            }

            public IPlayerBuilder Armor(Armor armor)
            {
                player.Armor = armor;
                return this;
            }

            public IPlayerBuilder Reset()
            {
                player = new Player();
                return this;
            }

            public IPlayerBuilder Spicies(Species species)
            {
                player.Species = species;
                return this;
            }

            public IPlayerBuilder Type(Type type)
            {
                player.Type = type;
                return this;
            }

            public Player Build(){
                return player;
            }
        }

        public class PlayerManager{
            IPlayerBuilder builder;

            public PlayerManager(IPlayerBuilder builder){
                this.builder = builder;
            }

            public void ChangeBuilder(IPlayerBuilder builder){
                this.builder = builder;
            }

            public Player BuildSteelDwarf(){
                return builder
                    .Reset()
                    .Armor(new SteelArmor())
                    .Spicies(new Dwarf())
                    .Type(new Normal())
                    .Build();
            }
        }

        class ClientCode
        {
            public static void Run()
            {
                PlayerManager playerManager = new PlayerManager(new PlayerBuilder());
                Player player = playerManager.BuildSteelDwarf();
                player.Play();
            }
        }
    }
}