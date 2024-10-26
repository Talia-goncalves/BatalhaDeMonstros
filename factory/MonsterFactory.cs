using BatalhaDeMonstros.Monsters;

namespace BatalhaDeMonstros.Factory
{
    public static class MonsterFactory
    {
        public static Monster CreateMonster(string type)
        {
            return type switch
            {
                "Dragon" => new Dragon(),
                "Zombie" => new Zombie(),
                "Robot" => new Robot(),
                _ => throw new ArgumentException("Tipo de monstro desconhecido.")
            };
        }
    }
}
