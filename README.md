# Projeto Unity - Componentes Modulares e Reutilizáveis

## Descrição

Este projeto tem como objetivo implementar funcionalidades de arma e movimentação de personagens utilizando os princípios de Programação Orientada a Objetos (OOP), com ênfase na modularização do código. A estrutura do projeto é dividida em componentes distintos, garantindo um código bem organizado e de fácil manutenção.

## Funcionalidades Implementadas

- **Arma**: Componente para gerenciar o comportamento da arma, incluindo:
  - Três tipos de disparos (tiro único, rajada e disparo em ângulo).
  - Sistema de recarregamento quando a munição acaba ou quando o jogador pressiona a tecla R.
- **Movimentação**: Componente separado para controlar a movimentação dos personagens, que pode ser controlada pelo jogador ou pela Inteligência Artificial (IA).
- **Melhorias Estéticas**: Inclusão de sprites e animações para enriquecer a apresentação visual do jogo.

## Estrutura do Projeto

- **`Prefabs/Projectile.prefab`**: Prefab do projétil utilizado pelo jogador.
- **`Scenes/MainScene.unity`**: Cena principal que contém os objetos da nave, inimigos e a lógica do jogo.
- **`Scripts/Projectile.cs`**: Script que define o comportamento do projétil.
- **`Scripts/Spaceship.cs`**: Script refatorado que controla a nave do jogador.
- **`Scripts/PlayerMovement.cs`**: Script que gerencia a movimentação do jogador.
- **`Scripts/Weapon.cs`**: Script responsável pelo comportamento da arma, incluindo disparo e recarga.
- **`Scripts/EnemyMovement.cs`**: Script que controla a movimentação dos inimigos.
- **`Sprites/spaceship.png`**: Sprite da nave do jogador.
- **`Sprites/projectile.png`**: Sprite do projétil.
- **`Sprites/enemy.png`**: Sprite do inimigo.

## Instruções de Uso

1. **Importe os Assets**: Adicione os scripts e assets ao seu projeto Unity.
2. **Configure a Nave**:
   - Adicione os componentes `Weapon` e `PlayerMovement` ao GameObject da nave na cena.
   - Configure as propriedades dos componentes no Inspector do Unity.
3. **Configure os Inimigos**:
   - Adicione o componente `EnemyMovement` aos inimigos na cena.
4. **Adicione Sprites**: Aplique os sprites `spaceship.png`, `projectile.png` e `enemy.png` aos objetos correspondentes na cena.

## Como Jogar

- **Movimentação**: Use as teclas de seta ou WASD para mover a nave.
- **Disparo**:
  - Pressione a tecla **Espaço** para disparar um tiro único.
  - Pressione a tecla **X** para disparar uma rajada de projéteis.
  - Pressione a tecla **V** para disparar em ângulo.
- **Recarregar**: Pressione a tecla **R** para recarregar a arma quando a munição acabar.

## Melhorias Futuras

- Adicionar novos tipos de armas e modos de disparo.
- Implementar uma IA mais complexa para os inimigos, proporcionando desafios variados ao jogador.
- Incluir mais efeitos sonoros e visuais, como explosões e feedback de disparo, para enriquecer a experiência do usuário.
- Implementar um sistema de pontuação e níveis para aumentar a rejogabilidade.

## Licença

Este projeto é para fins educacionais e pode ser utilizado e modificado livremente, desde que os créditos sejam mantidos.

## Contato

Para dúvidas, sugestões ou feedback, entre em contato.

- Luanna Ferreira
- Juliane Andreza
- Lucas Oliveira
- Leonardo Amansio
