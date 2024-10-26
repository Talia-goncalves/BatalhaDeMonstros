using BatalhaDeMonstros.Monsters;

namespace BatalhaDeMonstros.Actions
{
    public class AttackAction : ICombatAction
    {
        public void Execute(Monster attacker, Monster defender)
        {
            Console.WriteLine($"{attacker.GetType().Name} ataca {defender.GetType().Name} causando {attacker.AttackPower} de dano!");
            defender.Health -= attacker.AttackPower;
        }
    }
}
