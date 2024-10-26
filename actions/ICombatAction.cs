using BatalhaDeMonstros.Monsters;

namespace BatalhaDeMonstros.Actions
{
    public interface ICombatAction
    {
        void Execute(Monster attacker, Monster defender);
    }
}
