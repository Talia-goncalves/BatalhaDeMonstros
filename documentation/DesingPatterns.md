# Utilização de Design Patterns no Projeto de Batalha de Monstros

Este documento detalha a utilização de cinco padrões de design no projeto "Batalha de Monstros", com o nome dos  arquivos onde foram implementados.

---

## 1. **Factory Method**
- ### Local:
  - **Criação de Monstros**

- ### Arquivo:
  - `factory/MonsterFactory.cs`

- ### Implementação:
  - O padrão Factory Method foi aplicado para criar diferentes tipos de monstros (`Dragon`, `Robot`, e `Zombie`).  
  - A classe `MonsterFactory` encapsula a lógica de criação e retorna instâncias específicas das subclasses de `Monster`.

- ### Benefício:
  - Facilitou a extensão do jogo com novos tipos de monstros, sem necessidade de alterar o código existente.

---

## 2. **Singleton**
- ### Local:
  - **Gerenciamento Central do Jogo**

- ### Arquivo:
  - `gameManager/GameManager.cs`

- ### Implementação:
  - A classe `GameManager` foi implementada como um Singleton, garantindo que apenas uma instância gerencie o estado do jogo, como o progresso dos turnos e a configuração inicial dos jogadores.

- ### Benefício:
  - Evita inconsistências, garantindo que todas as partes do sistema acessem o mesmo estado global do jogo.

---

## 3. **Strategy**
- ### Local:
  - **Execução de Ações de Combate**

- ### Arquivos:
  - `actions/ICombatAction.cs`
  - `actions/AttackAction.cs`
  - `actions/DefendAction.cs`
  - `actions/SpecialAction.cs`

- ### Implementação:
  - O padrão Strategy foi utilizado para permitir que os jogadores e a IA realizem diferentes tipos de ações durante o combate.  
  - A interface `ICombatAction` define um contrato para as ações, e classes como `AttackAction`, `DefendAction`, e `SpecialAction` implementam comportamentos específicos.

- ### Benefício:
  - Adicionou flexibilidade ao sistema, permitindo modificar ou adicionar novas ações sem impactar o restante do código.

---

## 4. **Observer**
- ### Local:
  - **Monitoramento de Saúde dos Monstros**

- ### Arquivo:
  - `observer/HealthObserver.cs`

- ### Implementação:
  - O padrão Observer foi aplicado para atualizar componentes relacionados à saúde dos monstros sempre que esta muda.  
  - A classe `HealthObserver` observa os monstros e notifica o jogo quando há alterações críticas, como a derrota de um monstro.

- ### Benefício:
  - Separou a lógica de notificação, promovendo um design mais modular e desacoplado.

---

## 5. **Memento**
- ### Local:
  - **Sistema de Salvamento e Restauração do Jogo**

- ### Arquivos:
  - `game/GameMemento.cs`
  - `game/GameSaver.cs`

- ### Implementação:
  - O padrão Memento foi aplicado para salvar o estado do jogo a qualquer momento.  
  - A classe `GameMemento` armazena o estado atual, enquanto `GameSaver` gerencia a criação e restauração de momentos salvos.

- ### Benefício:
  - Proporcionou ao jogador a capacidade de salvar e restaurar o progresso, melhorando a experiência do usuário.

---
