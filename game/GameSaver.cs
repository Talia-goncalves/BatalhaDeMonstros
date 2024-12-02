using System.Text.Json;

namespace BatalhaDeMonstros.Memento
{
    // A classe GameSaver é responsável por salvar e carregar o estado do jogo.
    // Ela usa o formato JSON para persistir o estado (memento) em um arquivo.
    public class GameSaver
    {
        // Caminho do arquivo onde o estado do jogo será salvo.
        // O arquivo será chamado "game_save.json".
        private const string SaveFilePath = "game_save.json";

        // Método para salvar o estado do jogo em um arquivo JSON.
        public void SaveGame(GameMemento memento)
        {
            // Serializa o objeto memento para o formato JSON.
            var json = JsonSerializer.Serialize(memento);
            
            // Salva o JSON no arquivo especificado pelo SaveFilePath.
            File.WriteAllText(SaveFilePath, json);

            // Informa ao usuário que o jogo foi salvo com sucesso.
            Console.WriteLine("Jogo salvo com sucesso.");
        }

        // Método para carregar o estado do jogo a partir de um arquivo JSON.
        public GameMemento? LoadGame()
        {
            // Verifica se o arquivo de salvamento existe no caminho especificado.
            if (!File.Exists(SaveFilePath))
            {
                // Caso não exista, informa ao usuário que não há um arquivo de salvamento.
                Console.WriteLine("Nenhum arquivo de salvamento encontrado.");
                return null;
            }

            // Lê o conteúdo do arquivo e armazena como uma string.
            var json = File.ReadAllText(SaveFilePath);
            
            // Desserializa o JSON de volta para um objeto GameMemento.
            var memento = JsonSerializer.Deserialize<GameMemento>(json);

            // Informa ao usuário que o jogo foi carregado com sucesso.
            Console.WriteLine("Jogo carregado com sucesso.");

            // Retorna o memento restaurado do arquivo.
            return memento;
        }
    }
}
