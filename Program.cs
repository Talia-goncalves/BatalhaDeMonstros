using BatalhaDeMonstros.Game; 
using BatalhaDeMonstros.Monsters;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Escolha o modo de jogo: (1) PvE (2) PvP");
        int mode = int.Parse(Console.ReadLine() ?? "1");

        bool isPvE = mode == 1;

        Game game = new Game(isPvE);
        
        // Adicionando monstros ao jogo
        game.AddMonster(new Dragon());
        game.AddMonster(new Robot());
        game.AddMonster(new Zombie());

        // Iniciando o jogo
        game.Start();
    }
}
