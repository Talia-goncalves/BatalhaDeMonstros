namespace BatalhaDeMonstros.Monsters
{
    public class Robot : Monster
    {
        public Robot() : base(health: 90, attackPower: 15, defense: 12) { }

        public override void UseSpecialAbility(Monster target)
        {
            Console.WriteLine($"{GetType().Name} usa habilidade especial: Raio Laser!");
            target.Health -= 20;
        }
    }
}
