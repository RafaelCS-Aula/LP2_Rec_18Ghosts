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
  * Existem 4 `color`s:
    * _RED_
    * _YELLOW_
    * _BLUE_
    * _MIRROR_
  * `Position` é um `struct` com 2 propriedades `X` e `Y`.
  
* **`Portals`**
  * Serão apenas um elemento visual.
  * Há um `Ghost` á frente de cada portal da `color` do mesmo.
    * Este `Ghost` tem uma versão diferente da lógica quando colide com outros.
      * Sendo essa lógica a regra para interação `Portal`-`Ghost`.
  
* **`Mirrors`**
  * São `Tiles` como qualquer outra, mas com a cor _MIRROR_.
  * Quando o `Ghost` selecionado estiver num `Mirror`, ativa o modo _input_ `_DROP_`.

* `Game Board`
  * Programaticamente feito de `Dictionary<Position[], BoardObject[,,]>`
    * O outro será onde o estado do jogo é atualizado cada _turn_.
    * No array tri-dimensional de `BoardObjects`
      * A primeira dimensão são as carpetes e espelhos.
      * A segunda dimensão onde se movimentam os fantasmas.
      * A terceira onde residem os fantasmas _dummy_ para os portais. 
