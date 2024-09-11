INCLUDE GlobalsVar.ink

EXTERNAL playerName()
EXTERNAL finalizarQuestStep()
EXTERNAL increaseRelationship(npc, value)
EXTERNAL decreaseRelationship(npc, value)
EXTERNAL increaseEthicMeter(value)
EXTERNAL decreaseEthicMeter(value)

VAR leaderKEY = "Leader_of_Software"
VAR backendKEY = "Backend_Senior"
VAR frontendKEY = "Frontend_full"
VAR requirementsKEY = "Requirements"
VAR testerKEY = "Tester"
VAR databaseKEY = "Database"

{historyProgression:
- 6: -> Fase2_1
- 7: -> Fase2_2_1
}
nada.

=== Fase2_1 ===
O ambiente na startup continua tenso após o tumultuado dia anterior. A equipe precisa avançar no desenvolvimento do software, mas agora a propriedade intelectual se torna um ponto crítico e um novo conflito surge entre Luíza e Sávio. 
Durante o desenvolvimento do software, a equipe de back-end, liderada por Sávio, utilizou um código-fonte aberto de uma biblioteca externa para implementar uma funcionalidade crítica. O uso desse código acelerou o desenvolvimento, permitindo que o projeto fosse entregue dentro do prazo estipulado. No entanto, durante uma auditoria de código interna, Luíza, a líder do projeto, percebeu que a licença da biblioteca impõe certas restrições que podem representar riscos legais.
A biblioteca externa que foi utilizada está sob a licença GPL (General Public License), que exige que qualquer software derivado ou que faça uso direto de seu código-fonte seja distribuído com o mesmo tipo de licença. Isso implica que, se o software da startup for lançado comercialmente, ele precisará ser distribuído como software de código aberto, algo que a empresa não pode aceitar, pois pretende vender o software sob uma licença proprietária para seus clientes.

~historyProgression = 7
~ finalizarQuestStep()
->END

=== Fase2_2_1 ===
Precisamos revisar todas as partes do código para garantir a conformidade com a propriedade intelectual. Não podemos arriscar problemas legais que prejudiquem nossa reputação ou causem perdas financeiras.#speaker:Luiza
Já fizemos o necessário. Estamos desperdiçando tempo precioso. Temos outras prioridades, como a entrega do projeto. Esse perfeccionismo só vai atrasar tudo.#speaker:Sávio
Não se trata de perfeccionismo, Sávio, mas de garantir que estamos protegidos legalmente. Um erro agora pode custar caro no futuro, e não podemos ignorar isso. Precisamos respeitar as diretrizes que nos comprometemos a seguir.#speaker:Luiza
Essa discussão está indo longe demais. Precisamos de praticidade, não de complicação.#speaker:Sávio
*[Manter o desenvolvimento atual sem alterações significativas e focar apenas na conformidade legal.]
    -> Fase2_2_1.A
    
*[Fazer as mudanças necessárias para garantir a conformidade com a propriedade intelectual, mesmo que isso cause atrasos no projeto.]
    -> Fase2_2_1.B
*[Propor um plano para revisar e ajustar todo o código e as contribuições para garantir total conformidade com a propriedade intelectual, independentemente dos prazos.]
    -> Fase2_2_1.C
*[Sugerir abandonar o projeto se não for possível garantir a conformidade com a propriedade intelectual.]
    -> Fase2_2_1.D
-> END

= A
Luíza desaprova
~ decreaseRelationship(leaderKEY,40)

Sávio aprova
~increaseRelationship(backendKEY,40)

Felícia desaprova um pouco
~decreaseRelationship(frontendKEY,20)

Raquel desaprova um pouco
~decreaseRelationship(requirementsKEY,20)

Tadeu desaprova um pouco
~decreaseRelationship(testerKEY,20)

Bernardo reage de forma neutra

-> Fase2_2_2

= B
Recebe pontos de ética
~ increaseEthicMeter(20)

Luíza aprova
~ increaseRelationship(leaderKEY,40)

Sávio desaprova
~decreaseRelationship(backendKEY,40)

Felícia aprova
~increaseRelationship(frontendKEY,40)

Raquel aprova
~increaseRelationship(requirementsKEY,40)

Tadeu aprova um pouco
~increaseRelationship(testerKEY,20)

Bernardo aprova um pouco
~increaseRelationship(databaseKEY,20)

-> Fase2_2_2

= C
Recebe pontos de ética
~ increaseEthicMeter(20)

Luíza aprova
~ increaseRelationship(leaderKEY,40)

Sávio desaprova
~decreaseRelationship(backendKEY,40)

Felícia aprova
~increaseRelationship(frontendKEY,40)

Raquel aprova um pouco
~increaseRelationship(requirementsKEY,20)

Tadeu aprova um pouco
~increaseRelationship(testerKEY,20)

Bernardo aprova um pouco
~increaseRelationship(databaseKEY,20)

-> Fase2_2_2

= D
Recebe pontos de ética
~ increaseEthicMeter(10)

Luíza desaprova
~ decreaseRelationship(leaderKEY,40)

Sávio aprova
~increaseRelationship(backendKEY,40)

Felícia aprova
~increaseRelationship(frontendKEY,40)

Raquel desaprova
~decreaseRelationship(requirementsKEY,40)

Tadeu desaprova um pouco
~decreaseRelationship(testerKEY,20)

Bernardo desaprova um pouco
~decreaseRelationship(databaseKEY,20)
  
-> Fase2_2_2

=== Fase2_2_2 ===
Sávio, o admiro como profissional, mas neste momento a atitude mais cabível é agir conforme as regras e diretrizes a serem seguidas, revisaremos o código e faremos as adaptações necessárias no menor intervalo de tempo, enquanto isso terei que lidar com fúria dos stakeholders. Como meu subordinado, sugiro que haja conforme as minhas descrições. Se não estiver satisfeito com sua função e participação no time, ao final do projeto podemos conversar sobre a possibilidade de mudanças. Aos demais,voltemos todos ao trabalho!#speaker:Luiza
~historyProgression = 8
~ finalizarQuestStep()
-> END