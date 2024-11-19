using BatalhaDeMonstros.Actions;
using BatalhaDeMonstros.GameManagement;
using BatalhaDeMonstros.Monsters;
using BatalhaDeMonstros.Observers;
using BatalhaDeMonstros.Memento;

namespace BatalhaDeMonstros.BattleGames
{
    public class BattleGame
    {
        private readonly List<Monster> _monsters = new();
        private readonly bool _isPvE;
        private readonly AIPlayer.AIPlayer _aiPlayer = new();
        private readonly HealthObserver _healthObserver = new();
        private readonly GameManager _gameManager = new();
        private readonly GameSaver _gameSaver = new();
        
        // Variável para controlar a exibição da mensagem de salvar
        private bool firstTurn = true;

        public BattleGame(bool isPvE)
        {
            _isPvE = isPvE;
        }

        // Novo construtor para carregar o estado do jogo
        public BattleGame(GameMemento memento)
        {
            _isPvE = memento.IsPvE;
            _monsters = memento.Monsters;
        }

        public void AddMonster(Monster monster) => _monsters.Add(monster);

        public void Start()
        {
            Console.WriteLine("Iniciando batalha!");

            // Escolha do monstro para o jogador
            var playerMonster = ChooseMonster("Jogador");
            _monsters.Add(playerMonster);

            // Escolha do monstro para a IA ou segundo jogador
            Monster opponentMonster;
            if (_isPvE)
            {
                opponentMonster = ChooseRandomMonster();
                Console.WriteLine($"Oponente (IA) escolheu: {opponentMonster.GetType().Name}");
            }
            else
            {
                opponentMonster = ChooseMonster("Jogador 2");
            }
            _monsters.Add(opponentMonster);

            // Loop do jogo
            while (playerMonster.Health > 0 && opponentMonster.Health > 0)
            {
                // Mostrar a mensagem de 'sair' apenas na primeira rodada
                if (firstTurn)
                {
                    Console.WriteLine("Digite 'sair' para salvar e sair, ou pressione Enter para continuar.");
                    firstTurn = false; // Desabilitar a exibição para as rodadas subsequentes
                }

                if (Console.ReadLine()?.ToLower() == "sair")
                {
                    SaveGameState();
                    Console.WriteLine("Jogo salvo e saindo...");
                    return;
                }

                ExecuteTurn(playerMonster, opponentMonster);

                if (opponentMonster.Health > 0)
                {
                    if (_isPvE)
                    {
                        ExecuteTurnAI(opponentMonster, playerMonster);
                    }
                    else
                    {
                        ExecuteTurn(opponentMonster, playerMonster);
                    }
                }

                _healthObserver.OnHealthChanged(playerMonster);
                _healthObserver.OnHealthChanged(opponentMonster);
            }

            _gameManager.Score += playerMonster.Health > 0 ? 10 : 0;
            Console.WriteLine(playerMonster.Health > 0 ? "Jogador vence!" : "Oponente vence!");
        }

        private void SaveGameState()
        {
            var memento = new GameMemento(_monsters, _isPvE); // Passando o valor de _isPvE para o memento
            _gameSaver.SaveGame(memento);
        }

        private Monster ChooseMonster(string player)
        {
            Console.WriteLine($"\n{player}, escolha seu monstro: (1) Dragon (2) Robot (3) Zombie");
            int choice = int.Parse(Console.ReadLine() ?? "1");

            return choice switch
            {
                1 => new Dragon(),
                2 => new Robot(),
                3 => new Zombie(),
                _ => throw new ArgumentException("Escolha inválida. Selecione 1, 2 ou 3.")
            };
        }

        private Monster ChooseRandomMonster()
        {
            Random random = new Random();
            int choice = random.Next(1, 4);

            return choice switch
            {
                1 => new Dragon(),
                2 => new Robot(),
                3 => new Zombie(),
                _ => new Dragon()
            };
        }

        private void ExecuteTurn(Monster attacker, Monster defender)
        {
            Console.WriteLine($"\n{attacker.GetType().Name} - Escolha uma ação: (1) Atacar (2) Defender (3) Habilidade Especial");
            int choice = int.Parse(Console.ReadLine() ?? "1");

            ICombatAction action = choice switch
            {
                1 => new AttackAction(),
                2 => new DefendAction(),
                3 => new SpecialAction(),
                _ => throw new ArgumentException("Ação inválida.")
            };

            action.Execute(attacker, defender);
            Console.WriteLine($"{defender.GetType().Name} tem {defender.Health} de vida restante.");
        }

        private void ExecuteTurnAI(Monster attacker, Monster defender)
        {
            var action = _aiPlayer.ChooseAction(attacker, defender);
            action.Execute(attacker, defender);
            Console.WriteLine($"{defender.GetType().Name} tem {defender.Health} de vida restante.");
        }
    }

}