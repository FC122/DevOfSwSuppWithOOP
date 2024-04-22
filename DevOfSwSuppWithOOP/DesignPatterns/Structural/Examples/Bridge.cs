namespace DevOfSwSuppWithOOP.DesignPatterns.Structural.Bridge{
    namespace Problem{
        public class SteelBow
        {
            public void ShootFireArrow(FireArrow fireArrow)
            {
                fireArrow.ShootArrow();
            }
            public void ShootRegularArrow(RegularArrow regularArrow)
            {
                regularArrow.ShootArrow();
            }
        }
        public class RegularArrow
        {
            public void ShootArrow()
            {
                Console.WriteLine("Shoot Regular Arrow");
            }
        }
        public class FireArrow
        {
            public void ShootArrow()
            {
                Console.WriteLine("Shoot Fire Arrow");
            }
        }

        public class Game
        {
            public Game()
            {
                SteelBow steelBow = new SteelBow();
                steelBow.ShootFireArrow(new FireArrow());
                steelBow.ShootRegularArrow(new RegularArrow());
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
        public abstract class Bow{
            public List<IArrow> arrows;
            public Bow(List<IArrow> arrows){
                this.arrows = arrows;}
            public void ShootArrows(){
                arrows.ForEach(arrow =>{
                    arrow.ShootArrow();
                });
                arrows.Clear();
            }
            public void ShootArrow(){
                arrows[0].ShootArrow();
                arrows.Remove(arrows[0]);
            }
        }
        public class SteelBow : Bow{
            public SteelBow(List<IArrow> arrows) : base(arrows){}
        }
        public interface IArrow{
            public void ShootArrow();
        }
        public class RegularArrow : IArrow{
            public void ShootArrow(){
                Console.WriteLine("Shoot Regular Arrow");
            }
        }
        public class FireArrow : IArrow{
            public void ShootArrow(){
                Console.WriteLine("Shoot Fire Arrow");
            }
        }
        public class Game{
            public Game(){
                List<IArrow> arrows = new List<IArrow>() { new FireArrow(), new RegularArrow() };
                Bow bow = new SteelBow(arrows);

                bow.ShootArrows();
            }
        }
        public static class ClientCode{
            public static void Run(){
                new Game();
            }
        }
    }

}
