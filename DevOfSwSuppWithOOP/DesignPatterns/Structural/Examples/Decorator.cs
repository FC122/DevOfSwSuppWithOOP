namespace DevOfSwSuppWithOOP.DesignPatterns.Structural.Decorator{
    namespace Problem{
        public class BaseHealthEffect
        {
            public void ApplyBaseHealth()
            {
                Console.WriteLine("Apply Base Health");
            }
        }

        public class HealthRegeneration
        {
            public void ApplyHealthRegeneration()
            {
                Console.WriteLine("Health Regen");
            }

        }
        public class ArmorBuff
        {
            public void IncreaseArmor()
            {
                Console.WriteLine("Armor Increase");
            }
        }

        public class MagicDamage
        {
            public void IncreaseMagicDamage()
            {
                Console.WriteLine("Magic Dmg");
            }
        }

        public class Player
        {
            BaseHealthEffect baseHealthEffect;
            HealthRegeneration healthRegeneration;
            ArmorBuff armorBuff;
            MagicDamage magicDamage;
            public Player()
            {
                baseHealthEffect = new BaseHealthEffect();
                healthRegeneration = new HealthRegeneration();
                armorBuff = new ArmorBuff();
                magicDamage = new MagicDamage();
                baseHealthEffect.ApplyBaseHealth();
                healthRegeneration.ApplyHealthRegeneration();
                armorBuff.IncreaseArmor();
                magicDamage.IncreaseMagicDamage();
            }
        }

        public static class ClientCode
        {
            public static void Run()
            {
                new Player();
            }
        }
    }

    namespace Solution{
        public class BaseHealthEffect
        {
            public void ApplyBaseHealth()
            {
                Console.WriteLine("Apply Base Health");
            }
        }

        public class HealthRegeneration
        {
            public void ApplyHealthRegeneration()
            {
                Console.WriteLine("Health Regen");
            }

        }
        public class ArmorBuff
        {
            public void IncreaseArmor()
            {
                Console.WriteLine("Armor Increase");
            }
        }

        public class MagicDamage
        {
            public void IncreaseMagicDamage()
            {
                Console.WriteLine("Magic Dmg");
            }
        }

        public class Player
        {
            BaseHealthEffect baseHealthEffect;
            HealthRegeneration healthRegeneration;
            ArmorBuff armorBuff;
            MagicDamage magicDamage;
            public Player()
            {
                baseHealthEffect = new BaseHealthEffect();
                healthRegeneration = new HealthRegeneration();
                armorBuff = new ArmorBuff();
                magicDamage = new MagicDamage();
                baseHealthEffect.ApplyBaseHealth();
                healthRegeneration.ApplyHealthRegeneration();
                armorBuff.IncreaseArmor();
                magicDamage.IncreaseMagicDamage();
            }
        }

        public static class ClientCode
        {
            public static void Run()
            {
                new Player();
            }
        }
    }
}