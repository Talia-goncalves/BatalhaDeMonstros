namespace BatalhaDeMonstros.Monsters
{
    // A classe Dragon representa um monstro específico do tipo Dragão,
    // que herda da classe base Monster.
    public class Dragon : Monster
    {
        // O construtor do Dragão define os valores iniciais de saúde, poder de ataque e defesa.
        // Esses valores são passados para a classe base (Monster) utilizando o construtor base.
        public Dragon() : base(health: 100, attackPower: 20, defense: 10) { }

        // A habilidade especial do Dragão é o "Sopro de Fogo",
        // que causa dano ao alvo (target) diminuindo sua saúde em 25.
        public override void UseSpecialAbility(Monster target)
        {
            // Exibe uma mensagem indicando que o Dragão usou sua habilidade especial.
            Console.WriteLine($"{GetType().Name} usa habilidade especial: Sopro de Fogo!");
            
            // Diminui a saúde do alvo em 25 pontos como efeito do Sopro de Fogo.
            target.Health -= 25;
        }
    }
}
