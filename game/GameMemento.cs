using BatalhaDeMonstros.Monsters;
using System.Collections.Generic;

namespace BatalhaDeMonstros.Memento
{
    public class GameMemento
    {
        public List<Monster> Monsters { get; }

        public GameMemento(List<Monster> monsters)
        {
            Monsters = monsters.Select(m => new Monster(m.Health, m.AttackPower, m.Defense)).ToList();
        }
    }
}
