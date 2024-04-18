namespace DevOfSwSuppWithOOP.CleanCode.Renaming.Solution2{
    class Product
    {
        public string Name { get; private set; } 
        public string Price { get; private set; }
        public bool IsStocked { get; set; } 

        public Product(string name, string price)
        {
            Name = name;
            Price = price;
            IsStocked = false;
        }
    }

    class Inventory
    {
        List<Product> products;

        public Inventory(List<Product> products) 
        {
            this.products = products;
        }

        public void Restock(Product outOfStockProduct)
        {
            foreach (Product product in products)
            { 
                if (outOfStockProduct == product)
                    product.IsStocked = true;
            }
        }

        public void RemoveAllOutOfStockProducts()
        {
            products.RemoveAll(product => product.IsStocked == false);
        }
    }

    public static class ClientCode
    {
        public static void Run()
        {
            Inventory inventory = new Inventory([new Product("Paper", "22")]);
        }
    }
}