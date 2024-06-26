INCLUDE GlobalsVar.ink

{historyProgression:
- 0: -> Fase1_1
- 1: -> Fase1_2
- 2: -> Fase1_3
- 3: -> Fase1_4
- 4: -> Fase1_5
- 5: -> Fase1_7
}
nada.

=== Fase1_1 ===
    Bom dia! Onde estão as correspondências? #speaker:???????
    * [desculpe, o que?]
    Você sabe, as encomendas!
    ...
    Oh,me desculpe você não é o entregador, se eu estiver certa, deve ser o novo estagiário, muito prazer!
    ++ [sim, sou eu]
    Como eu imaginava! Meu nome é Felícia, sou a desenvolvedora Front-end e você é ?
    
    ***[Carlos] 
        ~ playerName = "Carlos"
        -> Fase1_1.A
        
    +++[Rodrigo]
        ~ playerName = "Rodrigo"
        -> Fase1_1.A
        
    +++[João]
        ~ playerName = "João"
        -> Fase1_1.A
        
    +++[Ana]
        ~playerName = "Ana"
        -> Fase1_1.A
    
= A 
Bem vindo ao time {playerName} , espero que você se acomode muito bem aqui ! Nossa equipe é bem diversificada. Vem! Vou te apresentar aos outros, eles devem estar na sala de reuniões.#speaker:Felicia
~ historyProgression = 1
//troca de ambiente
-> END

=== Fase1_2 ===
    Como eu esperava, aí estão vocês!#speaker:Felicia
    "Logo depois a líder de projeto atribui a tarefa de acompanhar o Sávio que é o desenvolvedor back-end sênior, a equipe está encarregada de trabalhar em um projeto para o setor de RH de uma grande empresa. A  proposta é criar um software que facilite a análise de currículo dos funcionários atuais e dos futuros, para encontrar aqueles que melhor se adequam ao cargo de acordo com sua formação e habilidades. A reunião se estende até a hora do almoço e se encerra com todos indo fazer suas refeições, o The player fica encarregado de procurar pelo Sávio quando a pausa acabar."#speaker:Narrador
    ~ historyProgression = 2
-> END

=== Fase1_3 ===
    Após o almoço, o The player se encaminha para sala do Sávio, se anuncia e logo entra iniciando o diálogo. Ambos conversam e Sávio explica sobre as tarefas e a dinâmica do expediente.
    ~ historyProgression = 3
-> END

=== Fase1_4 ===
    Tudo ocorreu como o esperado durante a primeira semana. É segunda novamente, Sávio está em sua sala conversando com Raquel ( Requisitos ) ,o the player se encontra apenas como ouvinte, a respeito de alguns requisitos do projeto que parecem peculiares e parecem desnecessários. Contudo o cliente exigiu que esses fossem atendidos e sejam inseridos com prioridade mesmo que atrase outras funcionalidades mais relevantes. Um destes requisitos é o desenvolvimento de um filtro automatizado que leva em conta, sexo, raça, orientação sexual e religião para a escolha do candidato que venha preencher determinada vaga.
    Você não concorda comigo que o planejamento de requisitos é adequado e segue exatamente o que nos foi solicitado?#speaker:Raquel
    * [Sim, realizar os pedidos do cliente é sempre o maior objetivo.]
        -> Fase1_4.A

    *[Em parte sim! Mas será que não podemos conversar com o cliente a respeito?]
        -> Fase1_4.B
    
    *[Não! Priorizar o filtro e ignorar as demais funcionalidades parece tolice.]
        -> Fase1_4.C
-> END

= A
    Raquel concorda.
    Sávio discorda, argumenta que você não tem experiência para dar uma opinião fundamentada, prefere levar isso para a próxima reunião e discutir com quem realmente deve opinar no projeto.
    ~ historyProgression = 4
-> END
    
= B
    Raquel desaprova um pouco e  diz que não é tão fácil quanto parece mudar algo que já foi acertado anteriormente
    Sávio aprova e ele diz que comunicação é o melhor caminho e que vai levar o assunto para a próxima reunião.
    ~ historyProgression = 4
->END

= C
    Raquel desaprova e diz que todos os requisitos foram anteriormente bem discutidos e definidos por ela e o cliente, sendo ousadia da sua parte questionar como tolice a vontade deste.
    Sávio aprova um pouco e ele diz que antes de fazer qualquer julgamento é melhor discutirmos mais sobre o assunto na próxima reunião.
    ~ historyProgression = 4 
-> END

=== Fase1_5 ===
Está pronto para a reunião?
+[sim]
    -> Fase1_6
+[não]
    okay
-> END

=== Fase1_6 ===
Conforme o horário marcado, na sala de reuniões Luiza começa falando que estava ciente das agitações na equipe com relação ao planejamento de requisitos e por isso para a reunião de hoje ela incluiu os donos do projeto que está em desenvolvimento. 
Logo, o representante da empresa entra na chamada e  Luiza inicia explicação das pautas da reunião e em seguida questiona a possibilidade do requisito ser desconsiderado e estabelecer como prioridade as outras funcionalidades mais "estruturais"
O stakeholder diz que como foi planejado anteriormente, preferia que esse "sistema de filtragem" continue como o primeiro a ser implementado.
A líder de projeto pede esclarecimento quanto ao motivo.
Em contrapartida ,o stakeholder insiste que é pedido direto de sua empresa e deixa claro que não há abertura para questionamentos.
A líder de projeto então tenta negociar para amenizar os campos do filtro, removendo algumas funcionalidades como os campos de gênero, etnia, orientação sexual e religião.
O stakeholder diz que não é possível, pois são indispensáveis para os interesses da empresa e que cabe a eles somente executar conforme o que foi descrito e solicitado.
A front-end entra no meio e insiste em perguntar que interesses são esses em  querem saber sobre cada candidato essas características específicas, o que faz parecer que eles querem favorecer certos grupos.
Irritado, ele argumenta que é mais simples do que parece, a empresa quer começar a passar uma visão de inclusividade mas  para isso precisa filtrar os candidatos que são mulheres e que são negros, contrata-los e aumentar a porcentagem dessas minorias dentro da empresa.
Felícia rebate: Tudo bem quanto ao sexo e etnia, mas e quanto à orientação sexual e a religião?
O stakeholder revira os olhos e fala de forma grosseira que são interesses da empresa, não vai ficar explicando algo que já foi planejado anteriormente com a requisitos, cumprimenta a líder, saindo abruptamente da chamada.
A líder dá uma bronca na front-end, constrangendo - a  na frente dos outros membros que continuam sentados.
Após um breve momento de silêncio, a front-end começa a dizer que estava na cara que a empresa estava querendo era um sistema discriminatório e pergunta irritada para a requisitos o porquê dela ter aceitado aquilo. Raquel  se defende dizendo que aquilo era um exagero e quando planejou os requisitos, embora alguns fossem estranhos,não pareciam representar nenhum mal.Neste momento Sávio entra na conversa, exaltado, diz que Felícia está sendo intrometida demais e que apoia o ponto de vista da requisitos, continua, dizendo que Felícia deveria exercer sua função sem questionar, já que o papel dela é só enfeitar o trabalho de todos, assim como todas as outras fazem.Pela fala dele incluir todas as outras integrantes da equipe, a conversa ganha maiores proporções e num instante instalou-se um clima inóspito, resultando em um grande bate-boca.
A líder da equipe interrompe e toma as rédeas da situação ordenando  que fiquem calados, em seguida adia a reunião e os dispensa.
Todos saem da sala, exceto a front-end que se sente ofendida e exige uma retratação da parte de Sávio, pelo que foi dito. Luiza reconhece o erro de Sávio e diz que vai conversar com ele. 
~historyProgression = 5
-> END

=== Fase1_7 ===
Está pronto para a reunião?
+[sim]
    -> Fase1_7_1
+[não]
    okay
-> END

=== Fase1_7_1 ===
Chega o momento de todos reunirem na na sala , antes do stakeholder entrar na chamada a líder discute com todos o que pensam daquela situação e sobre a possível discriminação que poderia ocorrer.
O banco de dados e o back-end Sênior são neutros na situação, o que for decidido terá o aval deles.
A líder de projeto, a Front-end, a Requisitos e o tester são contra a implementação do sistema no planejamento atual, acreditando que a funcionalidade deve ser no mínimo alterada, senão, completamente excluída. E caso o stakeholder não concorde com as mudanças, o projeto será abandonado.
Então é perguntado ao jogador sobre o posicionamento dele:
*[dizer que o planejamento inicial não tinha nada de errado e que não precisava mudar de forma alguma]
    -> Fase1_7_1.A
    
*[dizer que acha que as mudanças precisam ser feitas pelo bem do prazo, independente se haverá discriminação ou não.]
    -> Fase1_7_1.B
*[dizer que acha que as mudanças precisam ser feitas, principalmente para evitar discriminação.]
    -> Fase1_7_1.C
*[dizer que acha que era melhor abandonar o projeto completamente, por conta da discriminação.]
    -> Fase1_7_1.D
-> END

= A
- perde pontos de ética
- lider de projeto, desaprova
- back-end sênior, desaprova um pouco
- front-end, desaprova
- requisitos, desaprova um pouco
- tester, desaprova um pouco
- banco de dados, reage de forma neutra
-> Fase1_7_2

= B
- perde pontos de ética
- lider de projeto, desaprova um pouco
- back-end sênior, aprova um pouco
- front-end, desaprova
- requisitos, desaprova
- tester, desaprova um pouco
- banco de dados, reage de forma neutra
-> Fase1_7_2

= C
- ganha pontos de ética
- lider de projeto, aprova
- back-end sênior, aprova um pouco
- front-end, aprova
- requisitos, aprova
- tester, aprova um pouco
- banco de dados, reage de forma neutra
-> Fase1_7_2

= D
- ganha pontos de ética
- lider de projeto, desaprova
- back-end sênior, desaprova
- front-end, aprova
- requisitos, desaprova
- tester, desaprova um pouco
- banco de dados, desaprova um pouco
-> Fase1_7_2

=== Fase1_7_2 ===
Após ouvir a opinião de todos, finalmente, se inicia a reunião com o stakeholder.
A líder de projeto começa com os argumentos de que a funcionalidade estava atrasando o desenvolvimento de outras mais importantes.O stakeholder responde friamente que já disse que era uma funcionalidade prioritária.
Em oposição , a lider de projeto então fala que se não é possível remover a funcionalidade, deve-se modificar, principalmente pela sua equipe estar preocupada com a possibilidade do algoritmo ser utilizado como uma ferramenta para discriminação.
Ouvindo isso,o stakeholder recua e resolve dar visão ao que  eles têm a dizer.
Com isso,a líder de projeto explica os problemas envolvendo principalmente os campos de "religião", "orientação sexual", e sobre como esse "filtro" funcionaria se baseando nos dados dos funcionários de cada categoria, dessa forma recomendando candidatos que manteriam as diferenças etnicas e de sexo equilibridas.
O stakeholder argumenta que isso complicaria em vez de simplificar.
A líder de projeto concorda que acaba sendo mais complicado,porém mais justo e que a parte das recomendações automáticas seria feita depois do registro geral de funcionários, como algo complementar. Dessa forma poderiam focar primeiro na parte mais importante.Por fim, o stakeholder concorda e a reunião se encerra.
Todos ficam satisfeitos com o resultado.Após encerrar a chamada, Luiza dá a oportunidade de Sávio se retratar, mas ele o faz de forma breve e objetiva sem mostrar muito entusiasmo. O clima não melhora entre a equipe, já que as garotas seguem afetadas pelo ocorrido, e então todos são dispensados.

-> END