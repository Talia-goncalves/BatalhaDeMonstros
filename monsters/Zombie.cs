namespace BatalhaDeMonstros.Monsters
{
    public class Zombie : Monster
    {
        public Zombie() : base(health: 120, attackPower: 15, defense: 8) { }

        public override void UseSpecialAbility(Monster target)
        {
            Console.WriteLine($"{GetType().Name} usa habilidade especial: Autocura!");
            Health += 10;
        }
    }
}
