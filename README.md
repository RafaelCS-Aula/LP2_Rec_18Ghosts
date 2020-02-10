# Projeto 18 _Ghosts_ com Implementação em Consola e _Unity_

Projeto de 2º Época de Linguagens de Programação II

## Autoria

* Rafael Castro e Silva - 21903059
  * Desenvolveu o projeto.

### Repositório:

[Link para repositório](https://github.com/RafaelCS-Aula/LP2_Rec_18Ghosts)

* O _branch_ _master_ contem o Modelo de jogo, como um projeto _.NET_ básico
sem qualquer implementação.
  * O _unity implementation_ contem o Modelo do jogo implementado num projeto de
  _Unity_.
  * O _console implementation_ contem o Modelo do jogo implementado num projeto
  _.NET_.


## Detalhes Implementação de Modelo (WIP)

* Existem 3 classes, no _namespace_ `BridgeClasses` que são _Facades_ entre o 
  *Modelo* e a *Implementação*. As classes do Modelo nunca precisam de 
  interagir com as classes especificas da Implementação, usando as
  `BridgeClasses` que por sua vez interagem com as classes do sistema
  que está a implementar o Modelo.
* O Modelo usa bastantes _namespaces_ para controlar a o que cada classe
  está exposta, houve o esforço de tentar com que classes não soubessem
  mais do que tinham de usar. Isto foi especialmente importante para
  controlar o que as classes da Implementação conseguiriam ver.
* Além do Modelo, a Implementação tem de possuir pelo menos uma classe que
  trate de _Input_ e uma que trate de _Rendering_, isto garantido pelas 
  `BridgeClasses` que só aceitam classes exteriores que implementem certas
  interfaces. Cumprindo assim o _Pattern_ _MVC_.
* _SOLID_ foi seguido, cada classe tem uma função própria (embora esta seja
  um pouco geral em alguns casos) (*S*). (*O*) também foi cumprido pelo uso de
  _namespaces_, propriedades `readonly` e `private`.
* Como mencionado a cima, as `BridgeClasses` nomeadamente `RenderInfo` e 
  `InputReceiver` guardam referências a classes fora do modelo que implementem
  certas _interfaces_. Uma implementação tem de simplesmente fornecer classes
  que implementem essas _interfaces_ e comunique com as `BridgeClasses` e o 
  Modelo pode comunicar de volta sem problemas.

## UML

## Referências

* O código que alterna a vez dos jogadores no `GameController` foi copiado do
  projeto de Linguagens de Programação I do ano anterior desenvolvido por
  mim, Inácio Amerio e Diogo Henriques.
* Para consulta foram utilizados os _sites DotNetPerls, StackOverFlow_ e a _.NET API_. 
