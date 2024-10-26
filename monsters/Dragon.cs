namespace BatalhaDeMonstros.Monsters
{
    public class Dragon : Monster
    {
        public Dragon() : base(health: 100, attackPower: 20, defense: 10) { }

        public override void UseSpecialAbility(Monster target)
        {
            Console.WriteLine($"{GetType().Name} usa habilidade especial: Sopro de Fogo!");
            target.Health -= 25;
        }
    }
}
