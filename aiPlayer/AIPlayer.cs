using BatalhaDeMonstros.Actions;
using BatalhaDeMonstros.Monsters;

namespace BatalhaDeMonstros.AIPlayer
{
    public class AIPlayer
    {
        public ICombatAction ChooseAction(Monster attacker, Monster defender)
        {
            var random = new Random();
            int choice = random.Next(1, 4);

            return choice switch
            {
                1 => new AttackAction(),
                2 => new DefendAction(),
                3 => new SpecialAction(),
                _ => new AttackAction()
            };
        }
    }
}
