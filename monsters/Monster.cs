namespace BatalhaDeMonstros.Monsters
{
    // A classe Monster representa um monstro genérico.
    // Esta classe serve como base para tipos específicos de monstros, como Dragon, Zombie, etc.
    public class Monster
    {
        // Propriedade que representa a saúde do monstro.
        public int Health { get; set; }

        // Propriedade que representa o poder de ataque do monstro.
        public int AttackPower { get; set; }

        // Propriedade que representa a defesa do monstro.
        // A defesa é privada para impedir que seja modificada diretamente, 
        // sendo controlada somente através de métodos.
        public int Defense { get; private set; }

        // Construtor que inicializa as propriedades de saúde, poder de ataque e defesa do monstro.
        // Esses valores são definidos ao criar uma nova instância do monstro.
        public Monster(int health, int attackPower, int defense)
        {
            Health = health;      
            AttackPower = attackPower;  
            Defense = defense;    
        }

        // Método para aumentar a defesa do monstro em um valor específico.
        // O valor de defesa é somado ao valor atual da defesa.
        public void IncreaseDefense(int amount) => Defense += amount;

        // Método virtual para usar uma habilidade especial. 
        // Este método pode ser sobrescrito em classes derivadas para implementar habilidades específicas.
        public virtual void UseSpecialAbility(Monster target) { }
    }
}
