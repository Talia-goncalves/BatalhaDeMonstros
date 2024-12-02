using BatalhaDeMonstros.Monsters;

namespace BatalhaDeMonstros.Actions
{
    // Classe que define a ação de ataque entre monstros.
    public class AttackAction : ICombatAction
    {
        // Executa o ataque, reduzindo a saúde do monstro defensor.
        public void Execute(Monster attacker, Monster defender)
        {
            // Exibe uma mensagem indicando o ataque.
            Console.WriteLine($"{attacker.GetType().Name} ataca {defender.GetType().Name} causando {attacker.AttackPower} de dano!");

            // Aplica o dano à saúde do defensor.
            defender.Health -= attacker.AttackPower;
        }
    }
}
