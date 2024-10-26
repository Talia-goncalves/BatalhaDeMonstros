using BatalhaDeMonstros.Monsters;

namespace BatalhaDeMonstros.Actions
{
    public class DefendAction : ICombatAction
    {
        public void Execute(Monster attacker, Monster defender)
        {
            Console.WriteLine($"{attacker.GetType().Name} está se defendendo!");
            attacker.IncreaseDefense(5);
        }
    }
}
