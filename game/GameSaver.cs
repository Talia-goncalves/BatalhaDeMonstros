GameSaver.cs:
using System.Text.Json;
using BatalhaDeMonstros.Memento;

namespace BatalhaDeMonstros.Memento
{
    public class GameSaver
    {
        private const string SaveFilePath = "game_save.json";

        public void SaveGame(GameMemento memento)
        {
            // Serializa o memento como JSON e salva em um arquivo
            var json = JsonSerializer.Serialize(memento);
            File.WriteAllText(SaveFilePath, json);
            Console.WriteLine("Jogo salvo com sucesso.");
        }

        public GameMemento? LoadGame()
        {
            // Verifica se o arquivo de salvamento existe
            if (!File.Exists(SaveFilePath))
            {
                Console.WriteLine("Nenhum arquivo de salvamento encontrado.");
                return null;
            }

            // Lê o arquivo e desserializa o JSON de volta para um objeto GameMemento
            var json = File.ReadAllText(SaveFilePath);
            var memento = JsonSerializer.Deserialize<GameMemento>(json);
            Console.WriteLine("Jogo carregado com sucesso.");
            return memento;
        }
    }
}