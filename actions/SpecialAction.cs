using BatalhaDeMonstros.Monsters;

namespace BatalhaDeMonstros.Actions
{
    public class SpecialAction : ICombatAction
    {
        public void Execute(Monster attacker, Monster defender)
        {
            Console.WriteLine($"{attacker.GetType().Name} usa sua habilidade especial em {defender.GetType().Name}!");
            attacker.UseSpecialAbility(defender);
        }
    }
}
