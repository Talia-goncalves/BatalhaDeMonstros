using BatalhaDeMonstros.Actions;
using BatalhaDeMonstros.GameManagement;
using BatalhaDeMonstros.Monsters;
using BatalhaDeMonstros.Observers;
using BatalhaDeMonstros.Memento;

namespace BatalhaDeMonstros.BattleGames
{
    // Classe responsável por gerenciar o jogo de batalha entre monstros.
    public class BattleGame
    {
        private readonly List<Monster> _monsters = new(); // Lista que armazena os monstros participantes.
        private readonly bool _isPvE; // Determina se o jogo é Player vs Environment (IA) ou Player vs Player.
        private readonly AIPlayer.AIPlayer _aiPlayer = new(); // Instância da IA para o jogo PvE.
        private readonly HealthObserver _healthObserver = new(); // Observador que cuida da saúde dos monstros.
        private readonly GameManager _gameManager = new(); // Gerenciador do jogo.
        private readonly GameSaver _gameSaver = new(); // Responsável por salvar o estado do jogo.

        // Variável para exibir a mensagem de "sair" apenas no primeiro turno
        private bool firstTurn = true;

        // Construtor para iniciar o jogo, recebendo se é PvE ou PvP
        public BattleGame(bool isPvE)
        {
            _isPvE = isPvE;
        }

        // Construtor para carregar o estado do jogo a partir de um memento (para continuar um jogo salvo)
        public BattleGame(GameMemento memento)
        {
            _isPvE = memento.IsPvE; // Restaura a configuração de PvE ou PvP.
            _monsters = memento.Monsters; // Restaura os monstros do jogo.
        }

        // Método para adicionar um monstro à lista de monstros
        public void AddMonster(Monster monster) => _monsters.Add(monster);

        // Inicia o jogo
        public void Start()
        {
            Console.WriteLine("Iniciando batalha!");

            // Jogador escolhe seu monstro
            var playerMonster = ChooseMonster("Jogador");
            _monsters.Add(playerMonster);

            // Oponente escolhe seu monstro (IA ou outro jogador)
            Monster opponentMonster;
            if (_isPvE)
            {
                opponentMonster = ChooseRandomMonster(); // IA escolhe um monstro aleatório
                Console.WriteLine($"Oponente (IA) escolheu: {opponentMonster.GetType().Name}");
            }
            else
            {
                opponentMonster = ChooseMonster("Jogador 2"); // Segundo jogador escolhe seu monstro
            }
            _monsters.Add(opponentMonster);

            // Loop do jogo: continua enquanto ambos os monstros tiverem vida
            while (playerMonster.Health > 0 && opponentMonster.Health > 0)
            {
                // Exibe a mensagem de 'sair' apenas no primeiro turno
                if (firstTurn)
                {
                    Console.WriteLine("Digite 'sair' para salvar e sair, ou pressione Enter para continuar.");
                    firstTurn = false; // Desabilita a mensagem após o primeiro turno
                }

                // Verifica se o jogador deseja salvar e sair
                if (Console.ReadLine()?.ToLower() == "sair")
                {
                    SaveGameState(); // Salva o estado do jogo
                    Console.WriteLine("Jogo salvo e saindo...");
                    return;
                }

                // Executa o turno do jogador
                ExecuteTurn(playerMonster, opponentMonster);

                // Se o oponente ainda tiver vida, o turno dele é executado
                if (opponentMonster.Health > 0)
                {
                    if (_isPvE)
                    {
                        ExecuteTurnAI(opponentMonster, playerMonster); // A IA executa sua ação
                    }
                    else
                    {
                        ExecuteTurn(opponentMonster, playerMonster); // Segundo jogador executa sua ação
                    }
                }

                // Notifica as mudanças de saúde aos observadores
                _healthObserver.OnHealthChanged(playerMonster);
                _healthObserver.OnHealthChanged(opponentMonster);
            }

            // Atribui pontos dependendo do vencedor (se o jogador vencer, ganha 10 pontos)
            _gameManager.Score += playerMonster.Health > 0 ? 10 : 0;
            Console.WriteLine(playerMonster.Health > 0 ? "Jogador vence!" : "Oponente vence!");
        }

        // Método para salvar o estado do jogo, criando um memento
        private void SaveGameState()
        {
            var memento = new GameMemento(_monsters, _isPvE); // Cria o memento com o estado atual do jogo
            _gameSaver.SaveGame(memento); // Salva o memento
        }

        // Método que permite ao jogador escolher seu monstro
        private Monster ChooseMonster(string player)
        {
            Console.WriteLine($"\n{player}, escolha seu monstro: (1) Dragon (2) Robot (3) Zombie");
            int choice = int.Parse(Console.ReadLine() ?? "1"); // Lê a escolha do jogador

            return choice switch
            {
                1 => new Dragon(), // Retorna um Dragão
                2 => new Robot(),  // Retorna um Robô
                3 => new Zombie(), // Retorna um Zumbi
                _ => throw new ArgumentException("Escolha inválida. Selecione 1, 2 ou 3.") // Se a escolha for inválida
            };
        }

        // Método que permite à IA escolher um monstro aleatório
        private Monster ChooseRandomMonster()
        {
            Random random = new Random();
            int choice = random.Next(1, 4); // Escolha aleatória entre 1 e 3

            return choice switch
            {
                1 => new Dragon(), // Retorna um Dragão
                2 => new Robot(),  // Retorna um Robô
                3 => new Zombie(), // Retorna um Zumbi
                _ => new Dragon()  // Valor default, nunca deve chegar aqui
            };
        }

        // Método para executar o turno de um jogador
        private void ExecuteTurn(Monster attacker, Monster defender)
        {
            Console.WriteLine($"\n{attacker.GetType().Name} - Escolha uma ação: (1) Atacar (2) Defender (3) Habilidade Especial");
            int choice = int.Parse(Console.ReadLine() ?? "1"); // Lê a escolha da ação

            ICombatAction action = choice switch
            {
                1 => new AttackAction(),   // Se a escolha for 1, ataca
                2 => new DefendAction(),   // Se a escolha for 2, defende
                3 => new SpecialAction(),  // Se a escolha for 3, usa habilidade especial
                _ => throw new ArgumentException("Ação inválida.") // Se a escolha for inválida
            };

            // Executa a ação escolhida
            action.Execute(attacker, defender);
            Console.WriteLine($"{defender.GetType().Name} tem {defender.Health} de vida restante.");
        }

        // Método para executar o turno da IA
        private void ExecuteTurnAI(Monster attacker, Monster defender)
        {
            var action = _aiPlayer.ChooseAction(attacker, defender); // A IA escolhe uma ação
            action.Execute(attacker, defender); // Executa a ação escolhida
            Console.WriteLine($"{defender.GetType().Name} tem {defender.Health} de vida restante.");
        }
    }
}
