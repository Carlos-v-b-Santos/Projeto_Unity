EXTERNAL finalizarQuestStep()

Bom dia, (nome da pessoa)
    + [Bom dia, chefe!]
        -> contexto
    + [Bom dia!]
        -> contexto
    + [oi]
        -> contexto

=== contexto ===
No momento estamos trabalhando em um software de análises estatísticas e precisamos que você programe o módulo de entrada de dados, você tem três dias.
    + [vou precisar de ajuda]
        -> rota1
    + [consigo sozinho(a)]
        Ótimo!
        -> rota2

=== rota1 ===
Você pode pedir ajuda dos seus colegas se tiver alguma dificuldade, mas entenda que eles também estão atarefados e se você for capaz de fazer sozinho vai ser melhor para a empresa.

O que você decide fazer?
    + [pedir ajuda e colocar creditos na documentaçãa]
        -> final1
    + [pedir ajuda, mas não dar créditos na documentação]
        -> final2
    + [não pedir ajuda]
        -> rota2

=== rota2 ===
Se passam dois dias, você está no ultimo dia para terminar o código antes do prazo, mas você percebe que não será capaz de entregar o código no prazo. Você sabe de um código fonte de um software comercial com as funcionalidades que você tem que implementar, você poderia copiá-los já que não tem tempo para modifica-los.
+ [entregar o que conseguir fazer]
    -> final3
+ [copiar o código-fonte, mas não colocar os créditos na documentação]
    -> final4
+ [copiar o código-fonte, mas dar os créditos na documentação]
    -> final5
+ [Pedir ajuda]
    -> final6
    
=== final1 ===
    Com ajuda de seus colegas você consegue terminar o código no prazo, ao dar os créditos aos seus colegas, você age eticamente de acordo com o princípio 1.5 da ACM que trata do respeito ao trabalho de terceiros. Embora a empresa ainda tenha duvidas da sua competência individual
    Voce recebe 20 pontos de ética
    Voce recebe 10 pontos de competência
    ~ finalizarQuestStep()
-> END
    
=== final2 ===
    Com ajuda de seus colegas, você consegue terminar o código no prazo, como você não deu crédito aos seus colegas, seus superiores acreditam que você foi competente de fazer sozinho, isso agradou eles, mas essa foi uma ação antiética, sendo contra o príncipio 1.5 da ACM que trata do respeito ao trabalho de terceiros.
    você perde 10 pontos de ética
    você recebe 20 pontos de competência
-> END

=== final3 ===
    Você não conseguiu completar o código a tempo, mas não recorreu a nenhum meio antiético
    Você recebe 20 pontos de etica
    Você perde 20 pontos de competência
-> END

=== final4 ===
    Copiando, você consegue entregar o código no prazo e como você não deu crédito aos programadores originais seus superiores acreditam que você foi competente de fazer sozinho, isso agradou eles, mas essa foi uma ação antiética, sendo contra o príncipio 1.5 da ACM que trata do respeito ao trabalho de terceiros.
    Você perde 10 pontos de ética
    Você recebe 20 pontos de competência
-> END

=== final5 ===
    Copiando, você consegue entregar o código no prazo, ao dar créditos ao software comercial, você age eticamente de acordo com o princípio 1.5 da ACM que trata do respeito ao trabalho de terceiros. Embora a empresa ainda tenha duvidas da sua competência individual
    Você recebe 10 pontos de ética
    Você recebe 10 pontos de competência
-> END

=== final6 ===
    Já estava encima da hora e mesmo com ajuda você não consegue terminar o código, mas não recorreu a nenhum meio antiético.
    Você recebe 20 pontos de ética
    Você perde 10 pontos de ética
-> END