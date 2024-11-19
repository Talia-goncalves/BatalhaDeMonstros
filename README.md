# BatalhaDeMonstros

Este é um jogo de batalha de monstros desenvolvido com C# e .NET. O jogo permite que dois jogadores escolham um monstro e se enfrentem em batalhas, com a opção de salvar o progresso a qualquer momento durante o jogo.
Descrição do Jogo

## A dinâmica do jogo é simples:
- Cada jogador escolhe um monstro entre Dragon, Robot ou Zombie.
- Os jogadores se alternam em turnos, onde podem atacar, defender ou usar uma habilidade especial do monstro escolhido.
- A cada ação, o jogo solicita que o jogador pressione Enter para continuar ou digite "sair" para salvar o progresso e sair do jogo.
- O primeiro monstro a atingir 0 pontos de vida perde, e o outro jogador é declarado vencedor.

## Requisitos

Antes de começar, você precisa ter o .NET SDK instalado no seu sistema.

### Instalando o .NET SDK
1. Vá até o site oficial do .NET e baixe a versão mais recente do .NET SDK.
2. Siga as instruções de instalação para o seu sistema operacional:
    - Para Windows, o instalador será um arquivo .exe.
    - Para MacOS, baixe o pacote .pkg e siga as instruções.
    - Para Linux, siga as instruções específicas para sua distribuição.

### Verificando a Instalação

Após a instalação, abra o terminal ou prompt de comando e digite o seguinte comando para verificar se o .NET foi instalado corretamente:

```dotnet --version```

Este comando retornará a versão do .NET que foi instalada.

## Instruções de Execução

### Clonando o Repositório

Primeiro, clone o repositório do projeto para o seu computador:

```git clone https://github.com/Talia-goncalves/BatalhaDeMonstros.git```

### Instalando Dependências

O projeto já utiliza as dependências padrão do .NET, então você só precisa restaurar os pacotes NuGet. Navegue até a pasta do projeto e execute o seguinte comando:

```
cd BatalhaDeMonstros
npm install
```

Isso irá baixar todas as dependências necessárias.

## Rodando o Jogo

Agora que todas as dependências estão instaladas, você pode rodar o jogo com o comando:

```dotnet run```

O jogo será iniciado no terminal, e você verá um menu inicial onde poderá escolher entre:

- Novo Jogo: Iniciar uma nova partida.
- Carregar Jogo: Carregar um jogo salvo.
- Sair: Sair do jogo.

### Escolha o Modo de Jogo

Após iniciar um novo jogo, será solicitado que você escolha o modo de jogo:

- PvE: Jogador contra o ambiente (jogador contra o computador).
- PvP: Jogo entre dois jogadores.

### Escolha o Monstro

Cada jogador escolhe um monstro entre os seguintes:

- Dragon: Monstro com habilidades de fogo.
- Robot: Monstro com habilidades de ataque laser.
- Zombie: Monstro com habilidades de veneno.

### Durante o Jogo

Durante a batalha, cada jogador terá a oportunidade de realizar ações em seu turno, como:

- Atacar: Realizar um ataque físico no adversário.
- Defender: Se defender de um ataque inimigo.
- Habilidade Especial: Usar a habilidade única do monstro.

Após cada ação, o jogo aguarda que o jogador pressione Enter para continuar, ou digite "sair" para salvar o progresso e encerrar o jogo.

### Exemplo de Jogo

Aqui está um exemplo de como o jogo se comporta:

```Bem-vindo ao Jogo de Batalha de Monstros!
Escolha uma opção:
(1) Novo Jogo
(2) Carregar Jogo
(3) Sair
1
Escolha o modo de jogo: (1) PvE (2) PvP
2
Iniciando batalha!

Jogador, escolha seu monstro: (1) Dragon (2) Robot (3) Zombie
2

Jogador 2, escolha seu monstro: (1) Dragon (2) Robot (3) Zombie
1
Digite 'sair' para salvar e sair, ou pressione Enter para continuar.

Robot - Escolha uma ação: (1) Atacar (2) Defender (3) Habilidade Especial
1
Robot ataca Dragon causando 15 de dano!
Dragon tem 85 de vida restante.

Dragon - Escolha uma ação: (1) Atacar (2) Defender (3) Habilidade Especial
3
Dragon usa sua habilidade especial em Robot!
Dragon usa habilidade especial: Sopro de Fogo!
Robot tem 65 de vida restante.

sair
Salvando o Jogo
```

Durante o jogo, você pode digitar "sair" a qualquer momento para salvar o progresso. O jogo será pausado e o estado atual será salvo para que você possa retomar mais tarde.

##  Estrutura do Projeto

O projeto é organizado da seguinte forma:

```
BatalhaDeMonstros/
├── actions/
│   ├── AttackAction.cs
│   ├── DefendAction.cs
│   ├── ICombatAcion.cs
│   └── SpecialAction.cs
├── aiPlayer/
│   └── AIPlayer.cs
├── factory/
│   └── MonsterFactory.cs
├── game/
│   ├── Game.cs
│   ├── GameMamento.cs
│   └── GameSaver.cs
├── gameManager/
│   ├── GameManager.cs
│   └── GameState.cs
├── monster/
│   ├── Dragon.cs
│   ├── Monster.cs
│   ├── Robot.cs
│   └── Zombie.cs
├── observer/
│   └── HealthObserver.cs
├── Program.cs
└── README.md
```