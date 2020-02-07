# Projeto 18 _Ghosts_ com Implementação em Consola e _Unity_

Projeto de 2º Época de Linguagens de Programação II

## Autoria

* Rafael Castro e Silva - 21903059

## Detalhes Implementação de Modelo (WIP)

* Existem 2 modos de interação com `Ghost`s:
  * `Drop`, usado em `Mirrors` e quando soltar do `Dungeon` e `Setup`.
    * Seleciona `Ghost` -> Seleciona `Tile`.
    * Há comparação da `color` na origem do movimento...
      * Utiliza a `color` da `Tile` do `Ghost`.
      * Caso o `Ghost` não esteja numa `Tile`, utiliza a `color` do `Ghost`.
    * ... Com o destino:
      * Só valida se as `color` forem idênticas.
    * Opção para permitir selecionar `Tile` com outro fantasma lá.
    * `Tile` de destino adquirida de uma `List` com `Tile` válidas. 
  * `Slide`, usado em situação normal para mexer `Ghost` no campo
    * Seleciona `Ghost` -> Uso das _Arrow Keys_.
  
* Todos os elementos do jogo possuem as características: `Position` e `Color`.
  * Existem 5 `color`s:
    * _RED_
    * _YELLOW_
    * _BLUE_
    * _MIRROR_
    * _BLOCK_
  * `Position` é um `struct` com 2 propriedades `X` e `Y`.
  
* **`Portals`**
  * Serão apenas um elemento visual.
  * Há um `Ghost` á frente de cada portal da `color` do mesmo.
    * Este `Ghost` tem uma versão diferente da lógica quando colide com outros.
      * Sendo essa lógica a regra para interação `Portal`-`Ghost`.
  
* **`Mirrors`**
  * São `Tiles` como qualquer outra, mas com a cor _MIRROR_.
  * Quando o `Ghost` selecionado estiver num `Mirror`, ativa o modo movimento `_DROP_`.

* `Game Board`
  * Programaticamente feito de `Dictionary<Vector, BoardObject[]>`
    * O outro será onde o estado do jogo é atualizado cada _turn_.
    * No array tri-dimensional de `BoardObjects`
      * A primeira dimensão são as carpetes e espelhos.
      * A segunda dimensão onde se movimentam os fantasmas.
      * A terceira onde residem os fantasmas _dummy_ para os portais. 

### Core Loop

A **negrito** são as partes que são encarregues do `Model`.
O resto é dependente da plataforma em que correr.

1. **Começa um turno**
2. Receber e Registar _Input_.
3. Validar _Input_ recebido no contexto do jogo.
   1. Selecionou um fantasma de maneira correta.
   2. OU selecionou uma posição de grelha de maneira correta.
4. **Utilizar o _Input_**
   1. Fantasmas verificam se estão numa _tile_ com um `ISelectionInteratable`.
   2. O modo de movimento (_drop_ ou _slide_) é decidido.
5. Chamar o registo de _Input_ mais uma vez.
   1. _Drop:_ Pede uma posição de grelha.
   2. _Slide:_ Uso de _Arrow Keys_ para mover fantasma.
6. 3
7. **Validar _Input_ recebido no contexto das regras do movimento**
   1. Comparação de cores etc
8. **Resolver o _Input_**
   1. Fantasmas verificam a presença de `IInstantInteratable` na nova posição
      1. Lutas de Fantasmas
      2. Fantasma está na nova posição
      3. Fantasma está na _Dungeon_
      4. Fantasma escapou.
9. _Render_ do jogo no estado atualizado
10. **Mudar a vez do Jogador.**
