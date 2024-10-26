namespace BatalhaDeMonstros.Game
{
    class GameState
    {
        public Dictionary<string, int> MonsterHealths { get; }

        public GameState(Dictionary<string, int> monsterHealths)
        {
            MonsterHealths = new Dictionary<string, int>(monsterHealths);
        }
    }
}
