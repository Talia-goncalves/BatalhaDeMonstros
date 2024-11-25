using BatalhaDeMonstros.Monsters;

namespace BatalhaDeMonstros.Actions
{
    // Classe que define a ação de defesa de um monstro.
    public class DefendAction : ICombatAction
    {
        // Executa a defesa, aumentando a defesa do monstro atacante.
        public void Execute(Monster attacker, Monster defender)
        {
            // Exibe uma mensagem indicando que o monstro está se defendendo.
            Console.WriteLine($"{attacker.GetType().Name} está se defendendo!");

            // Aumenta a defesa do monstro atacante.
            attacker.IncreaseDefense(5);
        }
    }
}
