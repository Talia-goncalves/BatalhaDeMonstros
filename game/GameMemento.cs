using BatalhaDeMonstros.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BatalhaDeMonstros.Memento
{
    // A classe GameMemento é responsável por armazenar o estado do jogo.
    // Ela é usada para salvar o progresso do jogo, permitindo que o jogo seja restaurado depois.
    [Serializable] // Atributo que marca a classe como serializável, permitindo que sua instância seja salva em um arquivo ou outro meio persistente.
    public class GameMemento
    {
        // Lista de monstros que estão no jogo no momento da gravação do memento.
        // Esta lista é usada para restaurar os monstros a seu estado anterior.
        public List<Monster> Monsters { get; }

        // Propriedade que indica se o jogo está no modo Player vs Environment (PvE) ou Player vs Player (PvP).
        public bool IsPvE { get; }  

        // Construtor que cria um memento a partir do estado atual do jogo.
        // Ele recebe a lista de monstros e o status do modo de jogo (PvE ou PvP).
        public GameMemento(List<Monster> monsters, bool isPvE)
        {
            // A lista de monstros é copiada para garantir que não ocorram modificações no estado original do jogo.
            // Utiliza-se o método Select para criar uma cópia profunda dos monstros (sem referências para os objetos originais).
            Monsters = monsters.Select(m => new Monster(m.Health, m.AttackPower, m.Defense)).ToList();

            // O modo de jogo (PvE ou PvP) é armazenado para ser restaurado quando o memento for carregado.
            IsPvE = isPvE;  
        }
    }
}
