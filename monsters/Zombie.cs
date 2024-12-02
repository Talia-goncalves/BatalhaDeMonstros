namespace BatalhaDeMonstros.Monsters
{
    // A classe Zombie herda de Monster e representa um monstro do tipo zumbi.
    public class Zombie : Monster
    {
        // O construtor inicializa as propriedades de saúde, poder de ataque e defesa do Zombie.
        // O valor de saúde é 120, o poder de ataque é 15 e a defesa é 8.
        public Zombie() : base(health: 120, attackPower: 15, defense: 8) { }

        // Sobrescreve a habilidade especial do monstro base.
        // O Zombie tem a habilidade especial chamada "Autocura".
        public override void UseSpecialAbility(Monster target)
        {
            // Exibe uma mensagem indicando que o Zombie usou sua habilidade especial.
            Console.WriteLine($"{GetType().Name} usa habilidade especial: Autocura!");

            // O Zombie se cura, ganhando 10 pontos de saúde.
            Health += 10;
        }
    }
}
