using System.Security.Cryptography.X509Certificates;

namespace DevOfSwSuppWithOOP.DesignPatterns.Creational.Prototype{
    namespace Problem{
        public class Cat
        {
            public string name;
            public string weight;
            private string type;
            public Cat(string name, string weight, string type)
            {
                this.name = name;
                this.weight = weight;
                this.type = type;
            }
            public void LogData()
            {
                Console.WriteLine($"{name},{weight},{type}");
            }
        }
        class ClientCode
        {
            public static void Run()
            {
               Cat cat = new Cat("Cato", "20", "Persian");
               //clone the cat
               Cat catClone = new Cat(cat.name, "", "");
               //cant get weight and type because they are private
               cat.LogData();
               catClone.LogData();
            }
        }
    }

    namespace Solution{
        public interface ICloneable{
            object Clone();
        }

        public class Cat:ICloneable
        {
            public string name;
            public string weight;
            private string type;
            public Cat(string name, string weight, string type)
            {
                this.name = name;
                this.weight = weight;
                this.type = type;
            }

            public object Clone()
            {
                return new Cat(name, weight, type);
            }

            public void LogData()
            {
                Console.WriteLine($"{name},{weight},{type}");
            }
        }

        public class Clowder{
            private List<ICloneable> cats;
            public void Add(ICloneable clone){
                cats.Add(clone);
            }

            public ICloneable GetById(int index){
                return cats[index];
            }
        }

         class ClientCode
        {
            public static void Run()
            {
                Cat cat = new Cat("Cato", "20", "Persian");
                Cat catClone = (Cat)cat.Clone();
                cat.LogData();
                catClone.LogData();
            }
        }
    }
}