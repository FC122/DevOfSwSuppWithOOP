namespace DevOfSwSuppWithOOP.DesignPatterns.Behavioral.Iterator{
    namespace Problem{
        public class Item
        {
            public string name;

            public Item(string name)
            {
                this.name = name;
            }
        }
    }

    namespace Solution{
        public class Item
        {
            public string name;

            public Item(string name)
            {
                this.name = name;
            }
        }

        public interface IItemIterator
        {
            public bool HasNext();
            public Item GetNext();
        }

        public interface IItemCollection
        {
            public IItemIterator CreateItemIterator();
        }

        public class ItemIterator : IItemIterator
        {
            private ItemCollection itemCollection;
            int current;

            public ItemIterator(ItemCollection itemCollection)
            {
                this.itemCollection = itemCollection;
            }

            public Item GetNext()
            {
                if (HasNext())
                {
                    Item item = itemCollection.GetItem(current);
                    current++;
                    return item;
                }
                else
                {
                    throw new Exception("Nema");
                }
            }

            public bool HasNext()
            {
                return current <= itemCollection.Count();
            }
        }

        public class ItemCollection : IItemCollection
        {
            private List<Item> items;

            public ItemCollection(List<Item> items)
            {
                this.items = items;
            }

            public IItemIterator CreateItemIterator()
            {
                return new ItemIterator(this);
            }

            public int Count()
            {
                return items.Count;
            }

            public Item GetItem(int index)
            {
                return items[index];
            }
        }

        public static class ClientCode
        {
            public static void Run()
            {
                ItemCollection itemCollection = new ItemCollection(new List<Item>(){
                    new Item("BORK"), new Item("dc")
                });
            }
        }
    }
}