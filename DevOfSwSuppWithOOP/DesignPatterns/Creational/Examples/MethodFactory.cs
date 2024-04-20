using DevOfSwSuppWithOOP.DesignPatterns.Creational.MethodFactory.Problem;

namespace DevOfSwSuppWithOOP.DesignPatterns.Creational.MethodFactory{
    namespace Problem{
        class DragonDungeon
        {
            public void OpenDragonDungeon()
            {
                Console.WriteLine("Open Dragon Dungeon");
            }
        }
        
        class IceDungeon
        {
            public void OpenIceDungeon()
            {
                Console.WriteLine("Open Ice Dungeon");
            }
        }

        class DungeonMaster
        {
            DragonDungeon dragonDungeon;
            IceDungeon iceDungeon;
            public void OpenDragonDungeon()
            {
                dragonDungeon = new DragonDungeon();
                dragonDungeon.OpenDragonDungeon();
            }
            public void OpenIceDragonDungeon()
            {
                iceDungeon = new IceDungeon();
                iceDungeon.OpenIceDungeon();
            }
        }

        class ClientCode
        {
            public static void Run()
            {
                DungeonMaster dm = new DungeonMaster();
                dm.OpenDragonDungeon();
            }
        }
    }

    namespace Solution{
        abstract class Dungeon{
            public abstract void Open();
        }

        class DragonDungeon : Dungeon
        {
            public override void Open()
            {
                Console.WriteLine("Open Dragon Dungeon");
            }
        }

        class IceDungeon : Dungeon
        {
            public override void Open()
            {
                Console.WriteLine("Open Ice Dungeon");
            }
        }

        abstract class DungeonFactory{
            public abstract Dungeon CreateDungeon();
        }

        class IceDungeonFactory : DungeonFactory
        {
            public override Dungeon CreateDungeon()
            {
                return new IceDungeon();
            }
        }

        class DragonDungeonFactory: DungeonFactory{
            public override Dungeon CreateDungeon()
            {
                return new DragonDungeon();
            }
        }

        class DungeonMaster{
            DungeonFactory dungeonFactory;
            public DungeonMaster(DungeonFactory dungeonFactory){
                this.dungeonFactory = dungeonFactory;
            }
            public void OpenDungeon(){
                dungeonFactory.CreateDungeon().Open();
            }
        }

        class ClientCode
        {
            public static void Run()
            {
                DungeonMaster dm = new DungeonMaster( new DragonDungeonFactory());
                dm.OpenDungeon();
            }
        }
    }
}
