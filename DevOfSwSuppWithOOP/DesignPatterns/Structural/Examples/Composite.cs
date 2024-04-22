 namespace DevOfSwSuppWithOOP.DesignPatterns.Structural.Composite{
    namespace Problem{
        public class Item{
            string name;
            int price;
            public Item(string name, int price){
                this.name = name;
                this.price = price;
            }
            public string Name { get { return name; } }
            public int Price { get { return price;}}
        }

        public class Package{
            string name;
            List<Item> items;

            public Package(string name){
                this.name = name;
                items = new List<Item>();
            }

            public void AddItem(Item item){
                items.Add(item);
            }

            public void RemoveItem(Item item){
                items.Remove(item);
            }
            public string Name{ get { return name; } }
            public List<Item> Items{ get{return items;}}
        }

        public static class ClientCode
        {
            public static void Run()
            {
                Package package = new Package("Package1");
                int totalPrice=0;
                package.AddItem(new Item("Sat", 20));
                package.AddItem(new Item("Pan", 30));
                package.Items.ForEach(item=>{
                    totalPrice+=item.Price;
                });

                Console.WriteLine($"{totalPrice}");
                //kako dodati paket u paket?
                //sta ako imamo razlicite vrste paketa i itema?
            }
        } 
    }

    namespace Solution{
        public interface IItem{
            public string Name {get;}
            public int Price {get;}
        }

        public class Item:IItem{
            string name;
            int price;

            public Item(string name, int price){
                this.name = name;
                this.price = price;
            }

            public string Name { get { return name; }}
            public int Price { get { return price;}}
        }

        public class Package:IItem{
            string name;
            int price;

            List<IItem> items;

            public Package(string name){
                this.name = name;
                items = new List<IItem>();
            }

            public string Name { get { return name; }}
            public int Price { get { 
                price = 0;
                items.ForEach(item=>{
                    price+=item.Price;
                });
                return price;
             }}

             public void AddItem(IItem item){
                items.Add(item);
            }

            public void RemoveItem(IItem item){
                items.Remove(item);
            }
        }

        public static class ClientCode
        {
            public static void Run()
            {
                Package smallPackage = new Package("SmallPackage");
                smallPackage.AddItem(new Item("Pan", 20));
                smallPackage.AddItem(new Item("Mouse", 30));

                Package bigPackage = new Package("BigPackage");
                bigPackage.AddItem(smallPackage);
                bigPackage.AddItem(new Item("Lamp", 30));

                Console.WriteLine($"{bigPackage.Price}");
            }
        }
    }
 }