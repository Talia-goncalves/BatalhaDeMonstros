# Arquitetura do Projeto
A arquitetura do projeto está organizada em camadas, com cada camada responsável por uma parte específica da lógica de jogo e fluxo de dados. Aqui está uma visão geral das camadas e componentes sugeridos:

1. Camada de Entrada
    - Program.cs: Ponto de entrada do jogo; exibe o menu principal e inicia o processo do jogo.
    - UI (User Interface): Interage diretamente com o usuário e coleta as escolhas de ações.

2. Camada de Domínio (Core)
    - BattleGame: Classe principal que controla o fluxo de jogo, incluindo a inicialização dos monstros, turnos, e lógica de PvE/PvP.
    - Monster (classe abstrata): Classe base para todos os monstros, com propriedades e métodos comuns como Health, Attack(), Defend(), etc.
    - Classes de Monstros Concretos (e.g., Dragon, Robot, Zombie): Classes que herdam de Monster e implementam comportamentos específicos.
    - Actions: Interfaces e classes para ações de combate (ex.: ICombatAction, AttackAction, DefendAction, SpecialAction).

3. Camada de Serviços
    - AIPlayer: Controla a lógica de combate para a IA no modo PvE.
    - GameManager: Controla o sistema de pontuação e status do jogo.
    - HealthObserver: Observador para monitorar e notificar mudanças de vida de cada monstro.

4. Camada de Persistência
    - GameSaver: Classe responsável por salvar o estado do jogo.
    - GameMemento: Classe de armazenamento dos dados do jogo no momento da saída, implementando o padrão de projeto - Memento.
