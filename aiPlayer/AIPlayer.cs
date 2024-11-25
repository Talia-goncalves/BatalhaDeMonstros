using BatalhaDeMonstros.Actions;
using BatalhaDeMonstros.Monsters;

namespace BatalhaDeMonstros.AIPlayer
{
    // Representa um jogador controlado pela IA.
    public class AIPlayer
    {
        // Escolhe aleatoriamente uma ação de combate para o atacante usar contra o defensor.
        public ICombatAction ChooseAction(Monster attacker, Monster defender)
        {
            var random = new Random(); // Gera números aleatórios.
            int choice = random.Next(1, 4); // Gera um número entre 1 e 3 para decidir a ação.

            // Retorna a ação correspondente com base no número gerado.
            return choice switch
            {
                1 => new AttackAction(), // Ação de ataque.
                2 => new DefendAction(), // Ação de defesa.
                3 => new SpecialAction(), // Ação especial.
                _ => new AttackAction()  // Valor padrão caso algo inesperado aconteça.
            };
        }
    }
}
