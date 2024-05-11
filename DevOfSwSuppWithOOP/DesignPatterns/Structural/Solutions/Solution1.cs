namespace DevOfSwSuppWithOOP.DesignPatterns.Structural.Solution1{
    interface IPackable{
        public void Pack();
    }

    class Item : IPackable
    {
        string name;
        public Item(string name){
            this.name = name;
        }
        public void Pack()
        {
            Console.WriteLine($"Pack item {name}");
        }
    }

    class Package:IPackable{
        string name;
        List<IPackable> packables;
        public Package(string name){
            this.name=name;
            packables = new List<IPackable>();
        }

        public void Add(IPackable packable){
            packables.Add(packable);
        }

        public void Remove(IPackable packable){
            packables.Remove(packable);
        }

        public void Pack(){
            Console.WriteLine($"In {name} packing these items:");
            packables.ForEach(packable=>{
                packable.Pack();
            });
        }
    }

    public static class ClientCode{
        public static void Run(){
            Item lamp = new Item("lamp");
            Item glass = new Item("glass");
            Package smallPackage = new Package("smallPackage");
            smallPackage.Add(glass);
            smallPackage.Add(lamp);
            Item speakers = new Item("speakers");
            Package bigPackage = new Package("bigPackage");
            bigPackage.Add(smallPackage);
            bigPackage.Add(speakers);
            bigPackage.Pack();
        }
    }
}
