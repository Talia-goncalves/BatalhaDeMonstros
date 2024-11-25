namespace BatalhaDeMonstros.GameManagement
{
    // A classe GameManager gerencia o estado do jogo, como a pontuação.
    // Ela permite controlar o progresso do jogo, incluindo a pontuação do jogador.
    public class GameManager
    {
        // A pontuação do jogador. Inicialmente é 0.
        public int Score { get; set; } = 0;

        // Construtor da classe GameManager. Ele inicializa o objeto.
        // No caso, o construtor não faz nada além de inicializar a classe.
        public GameManager() { }

        // Método para resetar a pontuação do jogo.
        // Normalmente, é utilizado quando o jogo termina ou quando o jogador reinicia o jogo.
        public void Reset()
        {
            // Reseta a pontuação para 0.
            Score = 0;
        }
    }
}
