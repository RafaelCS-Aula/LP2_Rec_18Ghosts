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
* Os Portais foram implementados como fantasmas "falsos" com a sua própria 
  lógica de combate, isto permitiu que não tivesse de haver código extra só
  para os Portais e pode-se utilizar os sistemas que os fantasmas já usavam
  como a luta e o movimento.

### Nota com a Implementação Unity

* Pela altura de entrega deste documento, tentar correr o jogo no editor do
  _Unity_
  causa com que a janela congele e o seu consumo de memória suba constantemente.
* O congelar da janela do editor verifica-se sempre, no entanto se a janela não
  estiver aberta o consumo de memória não é afetado.
* Correndo o jogo através do _debugger_ do _Visual Studio_ o jogo corre
  normalmente até ao ponto em que é necessário _input_ do jogador, o que é
  impossível de fornecer pois não há interface para tal.

## UML

![18GhostsUML.png](18GhostsUML.png)

## Referências

* O código que alterna a vez dos jogadores no `GameController`, tal como
  a maioria do código em `ScreenRenderer` foi copiado do projeto de Linguagens
  de Programação I do ano anterior desenvolvido por mim, Inácio Amerio e Diogo 
  Henriques.
* Para consulta foram utilizados os _sites DotNetPerls, StackOverFlow_ e a _.NET API_.
