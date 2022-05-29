# LP1 Projeto2

---

## Autoria

* Pedro Fernandes - 21908084:
  * Tratou da criação da classe Board(Model), Tiles e respetivas classes derivadas de Tiles
  * Bug Fixing geral por todo o código

* Pedro Osório - 22002513:
  * Tratou da criação da interface IView e classe theView
  * Fez diagrama UML
* Pedro Rovisco - 22005821:
  * Tratou da criação da classe Controller e da classe SaveSystem
  * Fez Report

---

## Git repository

<https://github.com/Pedro-21908084/LP1Projeto2>

Nota: Usuário "TOUGHPOWER" corresponde ao aluno Pedro Osório - a22002513

---

## Arquitetura da solução

### Classe Tile

Contém:

* Um construtor Tile que inicia a board, o icon e IsSpecial
* Um método Effect que trata de executar o efeito da respetiva Tile
* Um método ToString que retorna um Icon

### Classe Boost(Classe derivada de Tile)

Contém:

* Um Método que faz mover o respetivo player 2 casas em frente na respetiva direcção

### Classe CheatDice(Classe derivada de Tile)

Contém:

* Um Método que mete o boolean CheatDice do respetivo jogador a true

### Classe Cobra(Classe derivada de Tile)

Contém:

* Um método que faz o respetivo jogador mover de volta para a posição inicial da board

### Classe ExtraDice(Classe derivada de Tile)

Contém:

* Um Método que mete o boolean ExtraDice do respetivo jogador a true

### Classe Ladder(Classe derivada de Tile)

Contém:

* Um Método que faz o respetivo jogador mover uma casa para cima na vertical

### Classe Snake(Classe derivada de Tile)

Contém:

* Um Método que faz o respetivo jogador mover uma casa para baixo na vertical

### Classe UTurn(Classe derivada de Tile)

Contém:

* Um Método que faz o respetivo jogador mover 2 casas para trás na respetiva direcção

### Classe Player

Contém:

* Um constructor que inicializa o icon, a posição inical em X e em Y e por fim os booleans CheatDice e ExtraDice
*Um método ToString que retorna o icon

### Interface IView e Classe TheView

Contém:

* 16 métodos que só mostram textos na consola
* 3 métodos que para além de mostrar texto retornam os inputs do jogador

### Classe Board

Contém:

* Um construtor que inicializa um array de Player e chama o método Generate Map
* Um método GenerateMap que gera o tabuleiro com tiles
* Um método AddToTurn que retorna string que diz os respetivos movimentos do jogador
* Um método ResetTurnMsg que retorna uma string com nada
* Um método Move que faz mover o respetivo jogador e também verifica como ele se deverá mover.
* Um método CheckPlayerOverlap que verifica e atua quando os jogadores se encontram com a mesma posição
* 2 métodos CheckStackOverflow e CheckStackOverflowPlayers que verificam os casos possiveis infinitos que façam crashar o programa
* Um método ArrayToBoard que converte uma posição em formato array para a board
* Um método PosLine que retorna o limite de valor por linha
* Um método BoardToArray que converte uma posição de board em formato array
* Um método ThrowDice que retorna uma valor random de 1-7 não inclusivo
* 2 método PlaceTile que escolhem ao acaso as várias tiles pela board entre um número minimo e máximo de vezes
* Um método GenerateRandomPos que atribui as tiles escolhidas ao acaso na board
* Uma função que verifica a condição de vitória e retorna o vencedor do jogo

### Classe Controller

Contém:

* Um construtor que inicializa as instâncias view,board e save system
* Um método RunGame que corre o jogo
* Um método TurnSystemLoop que corre o Loop do jogo
* Um método CheckPlayerInput que verifica onde o jogador se encontra e verifica respetivamente o que fazer com o input dado pelo jogador
* Um método CheatDiceQuestion que verifica se o jogador quer usar o CheatDice e com o input dele toma a devida acção

### Classe SaveSystem

Contém:

* Um construtor que inicializa o nome do ficheiro
* Um método DeleteSaveFile que apaga o ficheiro guardado
* Um método Save que guarda a board atual do jogo mais as Propriedades e variaveis do jogador
* Um método ConvertPlayerToString que converte as propriedades e variaveis do jogador em strings
* Um método Load que carrega o save file previamente guardado caso exista
* Um método String2Player que converte dados do jogador em string para reais
* Um método que verifica os icons das tiles e respetivamente cria novas instâncias e retorna-as

### Classe Program

Contém:

* As instâncias inicializadas de view, player1, player 2, save system e model
* Corre o jogo através da função RunGame do controller

## Diagrama UML

![UML](SnakesAndLadders_UMLDiagram.png)
