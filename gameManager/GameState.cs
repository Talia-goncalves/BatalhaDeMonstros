namespace BatalhaDeMonstros.Game
{
    // A classe GameState representa o estado atual do jogo, especificamente a saúde dos monstros.
    // Ela armazena um dicionário que mapeia o nome de cada monstro para sua saúde.
    class GameState
    {
        // Dicionário que armazena a saúde dos monstros.
        // A chave é o nome do monstro e o valor é a saúde atual do monstro.
        public Dictionary<string, int> MonsterHealths { get; }

        // Construtor que inicializa o estado do jogo com as informações de saúde dos monstros.
        // O dicionário de saúde dos monstros é copiado para garantir que o estado original não seja modificado diretamente.
        public GameState(Dictionary<string, int> monsterHealths)
        {
            // Copia o dicionário fornecido para MonsterHealths, criando uma cópia independente.
            MonsterHealths = new Dictionary<string, int>(monsterHealths);
        }
    }
}
