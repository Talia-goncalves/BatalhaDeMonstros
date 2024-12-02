using BatalhaDeMonstros.Monsters;

namespace BatalhaDeMonstros.Observers
{
    public class HealthObserver
    {
        public void OnHealthChanged(Monster monster)
        {
            if (monster.Health <= 0)
                Console.WriteLine($"{monster.GetType().Name} foi derrotado!");
        }
    }
}
