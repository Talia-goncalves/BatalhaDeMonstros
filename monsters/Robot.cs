namespace BatalhaDeMonstros.Monsters
{
    // A classe Robot herda de Monster e representa um monstro do tipo robô.
    public class Robot : Monster
    {
        // O construtor inicializa as propriedades de saúde, poder de ataque e defesa do Robot.
        // O valor de saúde é 90, o poder de ataque é 15 e a defesa é 12.
        public Robot() : base(health: 90, attackPower: 15, defense: 12) { }

        // Sobrescreve a habilidade especial do monstro base.
        // O Robot tem a habilidade especial chamada "Raio Laser".
        public override void UseSpecialAbility(Monster target)
        {
            // Exibe uma mensagem indicando que o Robot usou sua habilidade especial.
            Console.WriteLine($"{GetType().Name} usa habilidade especial: Raio Laser!");

            // Aplica dano de 20 na saúde do monstro alvo.
            target.Health -= 20;
        }
    }
}
