using System;
using BatalhaDeMonstros.BattleGames;
using BatalhaDeMonstros.Memento;

namespace BatalhaDeMonstros
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BattleGame game;
            GameSaver gameSaver = new GameSaver();  // Instância do GameSaver para carregar e salvar

            Console.WriteLine("Bem-vindo ao Jogo de Batalha de Monstros!");
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("(1) Novo Jogo");
            Console.WriteLine("(2) Carregar Jogo");
            Console.WriteLine("(3) Sair");

            int choice = int.Parse(Console.ReadLine() ?? "3");

            switch (choice)
            {
                case 1:
                    // Novo Jogo - Pergunta sobre o modo PvE ou PvP
                    Console.WriteLine("Escolha o modo de jogo: (1) PvE (2) PvP");
                    int modeChoice = int.Parse(Console.ReadLine() ?? "1");
                    bool isPvE = modeChoice == 1;
                    game = new BattleGame(isPvE);  // Instancia um novo jogo com o modo selecionado
                    break;

                case 2:
                    // Carregar Jogo
                    GameMemento savedState = gameSaver.LoadGame();  // Carrega o estado salvo
                    if (savedState != null)
                    {
                        Console.WriteLine("Jogo carregado com sucesso!");
                        game = new BattleGame(savedState.IsPvE);  // Passa o valor de IsPvE para o BattleGame
                    }
                    else
                    {
                        Console.WriteLine("Nenhum jogo salvo encontrado. Iniciando novo jogo.");
                        game = new BattleGame(true);  // Por padrão, inicia um novo jogo PvE
                    }
                    break;

                case 3:
                    // Sair
                    Console.WriteLine("Saindo do jogo...");
                    return;

                default:
                    Console.WriteLine("Opção inválida. Saindo do jogo...");
                    return;
            }

            // Inicia o jogo (seja carregado ou novo)
            game.Start();
        }
    }
}