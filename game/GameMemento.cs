using BatalhaDeMonstros.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BatalhaDeMonstros.Memento
{
    [Serializable]
    public class GameMemento
    {
        public List<Monster> Monsters { get; }
        public bool IsPvE { get; }  // Adicionando a propriedade IsPvE para indicar o modo de jogo

        public GameMemento(List<Monster> monsters, bool isPvE)
        {
            Monsters = monsters.Select(m => new Monster(m.Health, m.AttackPower, m.Defense)).ToList();
            IsPvE = isPvE;  // Armazena o modo de jogo
        }
    }
}