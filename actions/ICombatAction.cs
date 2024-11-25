using BatalhaDeMonstros.Monsters;

namespace BatalhaDeMonstros.Actions
{
    // Interface que define uma ação de combate no jogo.
    // Qualquer ação de combate (como ataque, defesa, etc.) deve implementar este contrato.
    public interface ICombatAction
    {
        // Método que executa a ação de combate entre dois monstros.
        void Execute(Monster attacker, Monster defender);
    }
}
