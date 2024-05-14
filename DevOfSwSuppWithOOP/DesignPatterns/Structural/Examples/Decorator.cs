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
    public interface IEffect
    {
        public void ApplyEffect();
    }
    public class BaseEffect : IEffect
    {
        public void ApplyEffect()
        {
            Console.WriteLine("Apply Base Effect");
        }
    }
    public class NoEffect : IEffect
    {
        public void ApplyEffect()
        {
            Console.WriteLine("No Effect");
        }
    }
    public class BaseEffectDecorator : IEffect
    {
        IEffect effect;
        public BaseEffectDecorator(IEffect effect)
        {
            this.effect = effect;
        }
        public virtual void ApplyEffect()
        {
            effect.ApplyEffect();
        }
    }
    public class HealthRegenerationEffect : BaseEffectDecorator
    {
        public HealthRegenerationEffect(IEffect effect) : base(effect) { }
        public override void ApplyEffect()
        {
            base.ApplyEffect();
            Console.WriteLine("Health Regeneration");
        }
    }
    public class ArmorEffectDecorator : BaseEffectDecorator
    {
        public ArmorEffectDecorator(IEffect effect) : base(effect) { }
        public override void ApplyEffect()
        {
            base.ApplyEffect();
            Console.WriteLine("Armor Increase");
        }
    }
    public class MagicDamageDecorator : BaseEffectDecorator
    {
        public MagicDamageDecorator(IEffect effect) : base(effect) { }
        public override void ApplyEffect()
        {
            base.ApplyEffect();
            Console.WriteLine("Magic Damage Buff");
        }
    }
    public class Player
    {
        IEffect effect;
        public Player()
        {
            effect = new BaseEffectDecorator(
                new MagicDamageDecorator(
                    new ArmorEffectDecorator(
                        new HealthRegenerationEffect(
                            new BaseEffect()
                        )
                    )
                )
            );
            effect.ApplyEffect();
        }
    }
    public static class ClientCode
    {
        public static void Run()
        {
            new Player();
            BaseEffectDecorator bef = new BaseEffectDecorator(
                new MagicDamageDecorator(
                    new ArmorEffectDecorator(
                        new NoEffect(

                        ))
                )
            );
        }
    }
    }
}