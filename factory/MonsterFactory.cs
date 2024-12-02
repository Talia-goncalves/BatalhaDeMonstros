using BatalhaDeMonstros.Monsters;

namespace BatalhaDeMonstros.Factory
{
    // Fábrica responsável por criar instâncias de monstros com base em seu tipo.
    public static class MonsterFactory
    {
        // Cria um monstro específico com base no tipo fornecido.
        public static Monster CreateMonster(string type)
        {
            // Retorna a instância do monstro correspondente ao tipo ou lança uma exceção se o tipo for inválido.
            return type switch
            {
                "Dragon" => new Dragon(), // Cria um dragão.
                "Zombie" => new Zombie(), // Cria um zumbi.
                "Robot" => new Robot(),   // Cria um robô.
                _ => throw new ArgumentException("Tipo de monstro desconhecido.") // Erro para tipos não reconhecidos.
            };
        }
    }
}
