using BatalhaDeMonstros.Monsters;

namespace BatalhaDeMonstros.Actions
{
    // Representa uma ação especial no combate entre monstros.
    public class SpecialAction : ICombatAction
    {
        // Executa a habilidade especial do atacante contra o defensor.
        public void Execute(Monster attacker, Monster defender)
        {
            Console.WriteLine($"{attacker.GetType().Name} usa sua habilidade especial em {defender.GetType().Name}!");
            attacker.UseSpecialAbility(defender); // Chama o método que aplica a habilidade especial.
        }
    }
}
