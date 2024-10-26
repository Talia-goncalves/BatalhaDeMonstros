namespace BatalhaDeMonstros.GameManagement
{
    public class GameManager
    {
        public int Score { get; set; } = 0;

        public GameManager() { }

        public void Reset()
        {
            Score = 0;
        }
    }
}
