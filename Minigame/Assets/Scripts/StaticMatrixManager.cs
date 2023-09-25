using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StaticMatrixManager : MonoBehaviour
{
    //lista de listas para formar a tabela verdade estatica
    public List<List<bool>> truthTable_static = new List<List<bool>>();

    List<char> expressao = new List<char>();
    List<KeyValuePair<int, int>> variables = new List<KeyValuePair<int, int>>();
    List<char> operations = new List<char>();

    List<string> cabecalho = new List<string>();

    //NÃO, 1
    //bicondicional, 2
    //condicional, 3
    //E, 4
    //OU, 5 

    //Transform do Canvas, para criação dos elementos
    Transform canvas;

    //Prefab dos elementos visuais da tabela verdade
    public GameObject cabecalhoElement;
    
    public GameObject trueElementPrefab;
    public GameObject falseElementPrefab;

    public GameObject aPrefab;
    public GameObject bPrefab;
    public GameObject ouPrefab;
    public GameObject ePrefab;
    public GameObject sePrefab;
    public GameObject somentePrefab;


    // Start is called before the first frame update
    void Start()
    {
        //para testes
        //expressao.Add('a');
        //expressao.Add('5');
        //expressao.Add('b');
        //expressao.Add('4');
        //expressao.Add('a');
        //Debug.Log(expressao[0]);

        canvas = GameObject.Find("Canvas").GetComponent<Transform>();
        GenerateExpression(3);
        int qtd_variaveis = AnalyseExpression(expressao);
        CreateMatrix(qtd_variaveis);
        PrintMatrix();

    }

    // Update is called once per frame
    void GenerateExpression(int qtd_variaveis)
    {
        List<char> operacoes = new List<char>();
        //operacoes.Add('1');
        operacoes.Add('2');
        operacoes.Add('3');
        operacoes.Add('4');
        operacoes.Add('5');

        bool var = true;
        char caracter = (char)65;

        Debug.Log("expressao:");
        for (int i = 0; i < 2 * qtd_variaveis - 1; i++)
        {
            if (var)
            {
                expressao.Add(caracter);
                var = false;

                if(caracter == 'A')
                    caracter = 'B';
                else
                    caracter = 'A';
            }
            else
            {
                expressao.Add(operacoes[Random.Range(0, operacoes.Count)]);
                var = true;
            }


            Debug.Log(expressao[^1]);
        }
        Debug.Log("fim_expressao");
    }

    void ClearLists()
    {
        truthTable_static.Clear();
        variables.Clear();
        operations.Clear();
    }

    //void ClearChilds(Transform pai)
    //{
    //    foreach (Transform child in pai) {
    //        Destroy(child.gameObject);
    //    }
    //}

    int AnalyseExpression(List<char> expressao)
    {
       ClearLists();

        int variaveis_usadas = 0;

        //int qtd_variaveis = 0;
        int tamanho = expressao.Count;
        int qtd_variaveis = 0;
        List<char> analisadas = new List<char>();
        List<int> operacoes_index = new List<int>();
        List<char> variaveis_index = new List<char>();
        List<int> variaveis_index_analisadas = new List<int>();

        for (int index = 0; index < tamanho; index++)
        {
            char c = expressao[index];

            switch (c)
            {
                //case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                    operations.Add(c);
                    operacoes_index.Add(index);

                    for (int i = operations.Count - 1; i > 0; i--)
                    {
                        if (operations[i - 1] > operations[i])
                        {
                            char temp = operations[i - 1];
                            int temp_ind = operacoes_index[i - 1];

                            operations[i - 1] = operations[i];
                            operacoes_index[i - 1] = operacoes_index[i];

                            operations[i] = temp;
                            operacoes_index[i] = temp_ind;
                        }
                        else
                        {

                            break;
                        }

                    }
                    break;

                case 'A':
                case 'B':
                case 'C':
                    if (!(analisadas.Contains(c)))
                    {
                        variaveis_index.Add(c);
                        cabecalho.Add(new string(":"+c));
                        Debug.Log("cabecalho:" + cabecalho[^1]);
                        qtd_variaveis++;
                        analisadas.Add(c);
                    }
                    break;
            }
        }

        analisadas.Clear();
        int divisoes = qtd_variaveis;

        int temp_i = 0;
        foreach (int index in operacoes_index)
        {
            Debug.Log("operacoes:" + operations[temp_i++] + "index:" + index);

            char esq = expressao[index - 1];
            int esq_index;

            char dir = expressao[index + 1];
            int dir_index;

            if (variaveis_index_analisadas.Contains(index - 1))
            {
                esq_index = divisoes;
                divisoes++;
            }
            else
            {
                esq_index = variaveis_index.IndexOf(esq);
                variaveis_usadas++;
                //qtd_variaveis++;
                variaveis_index_analisadas.Add(index - 1);
                Debug.Log("ultima:" + variaveis_index_analisadas[^1]);
            }

            if (variaveis_index_analisadas.Contains(index + 1))
            {
                dir_index = divisoes;
                divisoes++;
            }
            else
            {
                dir_index = variaveis_index.IndexOf(dir);
                variaveis_usadas++;
                //qtd_variaveis++;
                variaveis_index_analisadas.Add(index + 1);
                Debug.Log("ultima:" + variaveis_index_analisadas[^1]);
            }

            variables.Add(new KeyValuePair<int, int>(esq_index, dir_index));

            cabecalho.Add(new string(expressao[esq_index] + "" + expressao[index] + "" + expressao[dir_index]));

            Debug.Log("cabecalho:" + cabecalho[^1]);
            Debug.Log("variaveis:" + variables[^1]);
            Debug.Log(variables.Count);
        }

        return qtd_variaveis;
    }

    void CreateMatrix(int qtd_variaveis)
    //criar tabela verdade
    {
        int qtd_linhas = (int)Mathf.Pow(2, qtd_variaveis);//quantidade de linhas que tera a tabela

        //atribuir os valores iniciais da tabela verdade
        for (int coluna = 0; coluna < qtd_variaveis; coluna++)
        {
            truthTable_static.Add(new List<bool>());//adicionar nova coluna

            int cont = 0;//contador para repetição de variavel
            bool value = true;//valor a ser atribuido
            int qtd_repeticoes = (int)Mathf.Pow(2, qtd_variaveis - coluna) / 2;//quantidade de repetições do mesmo valor

            for (int linha = 0; linha < qtd_linhas; linha++)
            {
                if (cont < qtd_repeticoes)
                {
                    cont++;
                }
                else
                {
                    //inverter valor
                    if (value) value = false;
                    else value = true;

                    cont = 1;//reiniciar contagem a partir do 1
                }
                truthTable_static[coluna].Add(value);//adiciona o valor na linha

                Debug.Log("c:" + coluna + "l:" + linha + "t:" + truthTable_static[coluna][linha]);
            }
        }

        CalculateFieldMatrix(qtd_variaveis);




        //Debug.Log(truthTable_static[0][0]);
    }

    void CalculateFieldMatrix(int qtd_variaveis)
    //calcular o ultimo campo da matriz
    {
        int inicio_colunas = truthTable_static.Count;//atribui a quantidade atual de colunas
        int qtd_linhas = (int)Mathf.Pow(2, qtd_variaveis);//quantidade de linhas

        //int index_operation = 0;


        bool result = true;//resultado da expressao

        //adiciona uma nova coluna na tabela verdade

        for (int i = 0; i < operations.Count; i++)
        {
            truthTable_static.Add(new List<bool>());
        }

        Debug.Log(inicio_colunas);

        for (int linha = 0; linha < qtd_linhas; linha++)
        {
            int index_coluna = inicio_colunas;
            int index_variable = 0;
            foreach (char c in operations)
            {
                switch (c)
                {
                    case '1'://NAO
                        Debug.Log("nao implementado");
                        break;
                    case '2'://SE SOMENTE SE
                        result = (((truthTable_static[variables[index_variable].Key][linha])
                            && (truthTable_static[variables[index_variable].Value][linha]))
                                || (!(truthTable_static[variables[index_variable].Key][linha])
                            && !(truthTable_static[variables[index_variable].Value][linha])));
                        break;
                    case '3'://SE SENAO
                        result = !(truthTable_static[variables[index_variable].Key][linha])
                            || truthTable_static[variables[index_variable].Value][linha];
                        break;
                    case '4'://E
                        result = truthTable_static[variables[index_variable].Key][linha]
                            && truthTable_static[variables[index_variable].Value][linha];
                        break;
                    case '5'://OU
                        result = truthTable_static[variables[index_variable].Key][linha]
                            || truthTable_static[variables[index_variable].Value][linha];
                        break;
                }

                truthTable_static[index_coluna].Add(result);
                index_coluna++;
                index_variable++;

            }



            /*             for(int coluna = 0; coluna < qtd_variaveis; coluna += 2)
                        {
                            foreach (char operacao in operations)
                            {

                            }
                            result = result && truthTable_static[coluna][linha];

                        } */
            //atribui o valor final da ultima coluna
        }

        truthTable_static.RemoveRange(qtd_variaveis,truthTable_static.Count-qtd_variaveis-1);
    }

    void PrintExpression()
    {
        GameObject option2 = aPrefab;
        //Transform expressaoTransform = GameObject.Find("Expressao").GetComponent<Transform>();
        
        float posX = -7;
        float posY = -2f;
        Vector2 pos2;

        //ClearChilds(expressaoTransform);
       


        foreach (char c in expressao)
        {
            pos2 = new Vector2(posX, posY);;
            switch (c)
            {
                case '1'://NAO
                    Debug.Log("nao implementado");
                    break;
                case '2'://SE SOMENTE SE
                    option2 = somentePrefab;
                    break;
                case '3'://SE SENAO
                    option2 = sePrefab;
                    break;
                case '4'://E
                    option2 = ePrefab;
                    break;
                case '5'://OU
                    option2 = ouPrefab;
                    break;
                case 'A':
                    option2 = aPrefab;
                    break;
                case 'B':
                    option2 = bPrefab;
                    break;
                default:
                    break;
            }
            posX += 2.0f;
            Instantiate(option2, pos2, Quaternion.identity);
        }
        
    }

    void PrintMatrix()
    {
        int c = 0;
        float posX = -7.0f;
        float posY = 4.0f;
        Vector2 pos = new Vector2(posX, posY);
        GameObject option;
        GameObject clone;
        //Transform tabelaVerdadeTransform = GameObject.Find("TabelaVerdade").GetComponent<Transform>();
        TMP_Text m_textElement;

        //ClearChilds(tabelaVerdadeTransform);

        foreach (List<bool> i in truthTable_static)
        {
            
            pos = new Vector2(posX, posY);

            clone = Instantiate(cabecalhoElement, pos, Quaternion.identity);
            m_textElement = clone.GetComponentInChildren<TMP_Text>();
            if(m_textElement)
                Debug.Log("uhu");
            m_textElement.text = cabecalho[c++];

            posY -= 0.4f;

            foreach (bool j in i)
            {
                pos = new Vector2(posX, posY);
                //Debug.Log(i[j]);
                if (j)
                {
                    option = trueElementPrefab;
                    //GameObject clone = Instantiate(trueElementPrefab, new Vector2(posX, posY), Quaternion.identity, canvas.transform);
                }
                else
                {
                    option = falseElementPrefab;
                }
                clone = Instantiate(option, pos, Quaternion.identity);

                clone.name = new string("x: " + posX + "y: " + posY);
                //m_textElement = clone.GetComponent<TMP_Text>();
                //m_textElement.text = new string("-" + j + "-");
                posY -= 0.65f;
            }
            posY = 4.0f;
            posX += 1.55f;
        }


    }

    public void InsertOperationInExpression(string caractere)
    {
        Debug.Log("inserir:" + caractere);
        expressao.Add(caractere[0]);
        Debug.Log("ultimo elemento:" + expressao[^1]);
        PrintExpression();
    }

    public void GerarTabela()
    {
        int qtd_variaveis = AnalyseExpression(expressao);
        CreateMatrix(qtd_variaveis);
        PrintMatrix();
    }

    public void LimparExpressao()
    {
        expressao.Clear();
        PrintExpression();
    }

    public void DeleteOperationInExpression()
    {
        expressao.RemoveAt(expressao.Count - 1);
        PrintExpression();
    }
}
