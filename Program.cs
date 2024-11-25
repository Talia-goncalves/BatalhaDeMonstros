using BatalhaDeMonstros.BattleGames;
using BatalhaDeMonstros.Memento;

namespace BatalhaDeMonstros
{
    public static class Program
    {
        // Método principal que inicia o jogo
        public static void Main(string[] args)
        {
            BattleGame game;  // Declaração de variável para o jogo
            GameSaver gameSaver = new GameSaver();  // Instancia o GameSaver para salvar e carregar o jogo

            // Mensagem de boas-vindas ao jogador
            Console.WriteLine("Bem-vindo ao Jogo de Batalha de Monstros!");
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("(1) Novo Jogo");
            Console.WriteLine("(2) Carregar Jogo");
            Console.WriteLine("(3) Sair");

            // Lê a escolha do jogador
            int choice = int.Parse(Console.ReadLine() ?? "3");

            // Processa a escolha do jogador
            switch (choice)
            {
                case 1:
                    // Novo Jogo - Pergunta sobre o modo PvE ou PvP
                    Console.WriteLine("Escolha o modo de jogo: (1) PvE (2) PvP");
                    int modeChoice = int.Parse(Console.ReadLine() ?? "1");
                    bool isPvE = modeChoice == 1;  // Determina se o jogo será PvE (Player vs Environment) ou PvP (Player vs Player)
                    
                    // Cria um novo jogo com o modo de jogo selecionado
                    game = new BattleGame(isPvE);  
                    break;

                case 2:
                    // Carregar Jogo - Tenta carregar o estado salvo anteriormente
                    GameMemento savedState = gameSaver.LoadGame();  // Carrega o estado salvo
                    if (savedState != null)
                    {
                        // Caso o jogo tenha sido carregado com sucesso, cria o jogo com o modo salvo
                        Console.WriteLine("Jogo carregado com sucesso!");
                        game = new BattleGame(savedState.IsPvE);  // Passa o valor de IsPvE para o BattleGame
                    }
                    else
                    {
                        // Caso não haja jogo salvo, inicia um novo jogo com o modo PvE
                        Console.WriteLine("Nenhum jogo salvo encontrado. Iniciando novo jogo.");
                        game = new BattleGame(true);  // Por padrão, inicia um novo jogo PvE
                    }
                    break;

                case 3:
                    // Sair - Encerra o jogo
                    Console.WriteLine("Saindo do jogo...");
                    return;

                default:
                    // Caso o jogador digite uma opção inválida
                    Console.WriteLine("Opção inválida. Saindo do jogo...");
                    return;
            }

            // Inicia o jogo após a seleção (seja um jogo novo ou carregado)
            game.Start();
        }
    }
}
