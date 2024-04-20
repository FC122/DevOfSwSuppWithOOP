namespace DevOfSwSuppWithOOP.DesignPatterns.Creational.AbstractFactry{
    namespace Problem{
        public class FireWizard{
            public void DoFireMagic()
            {
                Console.WriteLine("Do Fire Magic");
            }
        }

        public class WaterWizard{
            public void DoWaterMagic(){
                Console.WriteLine("Do Water Magic");
            }
        }

        public class FireGoblin{
            public void DoFireDamage(){
                Console.WriteLine("Do Fire Damage");
            }
        }

        public class WaterGoblin
        {
            public void DoWaterDamage(){
                Console.WriteLine("Do Water Damage");
            }
        }

        public class GameManager{
            public void PlayWaterLevel(){
                WaterGoblin waterGoblin = new WaterGoblin();
                WaterWizard waterWizard = new WaterWizard();
                waterGoblin.DoWaterDamage();
                waterWizard.DoWaterMagic();
            }

            public void PlayFireLevel(){
                FireGoblin fireGoblin = new FireGoblin();
                FireWizard fireWizard = new FireWizard();
                fireGoblin.DoFireDamage();
                fireWizard.DoFireMagic();
            }
        }

        class ClientCode
        {
            public static void Run()
            {
                GameManager gameManager = new GameManager();
                gameManager.PlayFireLevel();
            }
        }
    }

    namespace Solution{
        public abstract class Goblin{
            public abstract void DoDamage();
        }

        public abstract class Wizard{
            public abstract void DoMagic();
        }

        public class FireWizard:Wizard
        {
            public override void DoMagic()
            {
                Console.WriteLine("Do Fire Magic");
            }
        }

        public class WaterWizard:Wizard
        {
            public override void DoMagic()
            {
                Console.WriteLine("Do Water Magic");
            }
        }

        public class FireGoblin:Goblin
        {
            public override void DoDamage()
            {
                Console.WriteLine("Do Fire Damage");
            }
        }

        public class WaterGoblin:Goblin
        {
            public override void DoDamage()
            {
                Console.WriteLine("Do Water Damage");
            }
        }

        public abstract class CharacterFactory{
            public abstract Wizard CreateWizard();
            public abstract Goblin CreateGoblin();
        }

        public class FireCharacterFactory : CharacterFactory
        {
            public override Goblin CreateGoblin()
            {
                return new FireGoblin();
            }

            public override Wizard CreateWizard()
            {
                return new FireWizard();
            }
        }

        public class WaterCharacterFactory : CharacterFactory
        {
            public override Goblin CreateGoblin()
            {
                return new WaterGoblin();
            }

            public override Wizard CreateWizard()
            {
                return new WaterWizard();
            }
        }

        public class GameManager{
            public void Play( CharacterFactory characterFactory){
                characterFactory.CreateGoblin();
                characterFactory.CreateWizard();
            }
        }

        class ClientCode
        {
            public static void Run()
            {
                CharacterFactory characterFactory = new FireCharacterFactory();
                GameManager gameManager = new GameManager();
                gameManager.Play(characterFactory);
            }
        }
    }
}