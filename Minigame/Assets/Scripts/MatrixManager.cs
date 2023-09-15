using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MatrixManager : MonoBehaviour
{
    //lista de listas para formar a tabela verdade estatica
    List<List<bool>> truthTable_static = new List<List<bool>>();

    List<char> expressao = new List<char>();
    List<KeyValuePair<int,int>> variables = new List<KeyValuePair<int,int>>();
    List<char> operations = new List<char>();

    //NÃO, 1
    //bicondicional, 2
    //condicional, 3
    //E, 4
    //OU, 5 

    //Transform do Canvas, para criação dos elementos
    Transform canvas;

    //Prefab dos elementos visuais da tabela verdade
    public GameObject elementPrefab;
    
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
        GenerateExpression(2);
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
        char caracter = (char) 65;

        Debug.Log("expressao:");
        for(int i = 0; i < (int)Mathf.Pow(2,qtd_variaveis)-1; i++)
        {
            if(var)
            {
                expressao.Add(caracter++);
                var = false;
            }
            else
            {
                expressao.Add(operacoes[Random.Range(0,operacoes.Count)]);
                var = true;
            }

            
            Debug.Log(expressao[^1]);
        }
        Debug.Log("fim_expressao");
    }

    int AnalyseExpression(List<char> expressao)
    {
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

                    for(int i = operations.Count -1; i > 0; i--)
                    {
                        if (operations[i - 1] > operations[i])
                        {
                            char temp = operations[i - 1];
                            int temp_ind = operacoes_index[i-1];

                            operations[i - 1] = operations[i];
                            operacoes_index[i-1] = operacoes_index[i];

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
            Debug.Log("operacoes:" + operations[temp_i++] + "index:"+index);

            char esq = expressao[index-1];
            int esq_index;

            char dir = expressao[index+1];
            int dir_index;

            if (variaveis_index_analisadas.Contains(index-1))
            {
                esq_index = divisoes;
                divisoes++;
            }
            else
            {
                esq_index = variaveis_index.IndexOf(esq);
                variaveis_usadas++;
                //qtd_variaveis++;
                variaveis_index_analisadas.Add(index-1);
                Debug.Log("ultima:" + variaveis_index_analisadas[^1]);
            }

            if (variaveis_index_analisadas.Contains(index+1))
            {
                dir_index = divisoes;
                divisoes++;
            }
            else
            {
                dir_index = variaveis_index.IndexOf(dir);
                variaveis_usadas++;
                //qtd_variaveis++;
                variaveis_index_analisadas.Add(index+1);
                Debug.Log("ultima:" + variaveis_index_analisadas[^1]);
            }

            variables.Add(new KeyValuePair<int,int>(esq_index,dir_index));
            
            Debug.Log("variaveis:" + variables[^1]);
            Debug.Log(variables.Count);
        }

        return qtd_variaveis;
    }

    void CreateMatrix(int qtd_variaveis)
    //criar tabela verdade
    {
        int qtd_linhas = (int)Mathf.Pow(2,qtd_variaveis);//quantidade de linhas que tera a tabela

        //atribuir os valores iniciais da tabela verdade
        for (int coluna = 0; coluna < qtd_variaveis; coluna++)
        {
            truthTable_static.Add(new List<bool>());//adicionar nova coluna
            
            int cont = 0;//contador para repetição de variavel
            bool value = true;//valor a ser atribuido
            int qtd_repeticoes = (int)Mathf.Pow(2,qtd_variaveis-coluna)/2;//quantidade de repetições do mesmo valor

            for(int linha = 0; linha < qtd_linhas; linha++)
            {
                if(cont < qtd_repeticoes)
                {
                    cont++;
                }
                else
                {
                    //inverter valor
                    if(value) value = false;
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
        int qtd_linhas = (int)Mathf.Pow(2,qtd_variaveis);//quantidade de linhas
        
        //int index_operation = 0;
       
        
        bool result = true;//resultado da expressao

        //adiciona uma nova coluna na tabela verdade
        
        for(int i = 0; i < operations.Count; i++)
        {
            truthTable_static.Add(new List<bool>());
        }

        Debug.Log(inicio_colunas);

        for(int linha = 0; linha < qtd_linhas; linha++)
        {
            int index_coluna = inicio_colunas;
             int index_variable = 0;
            foreach(char c in operations)
            {
                switch (c)
                {
                    case '1'://NAO
                        Debug.Log("nao implementado");
                        break;
                    case '2'://SE SOMENTE SE
                        result = (((truthTable_static[variables[index_variable].Key][linha])
                            &&(truthTable_static[variables[index_variable].Value][linha])) 
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
    }

    void PrintMatrix()
    {
        int posX = 0;
        int posY = 0;
        TMP_Text m_textElement;

        foreach (List<bool> i in truthTable_static)
        {
            foreach(bool j in i)
            {
                //Debug.Log(i[j]);
                GameObject clone = Instantiate(elementPrefab, new Vector3(posX, posY, 0), Quaternion.identity, canvas.transform);
                clone.name = new string("x: " + posX + "y: " + posY);
                m_textElement = clone.GetComponent<TMP_Text>();
                m_textElement.text = new string("-" + j + "-");
                posY -= 125;
            }
            posY = 0;
            posX += 125;
        }
        

    }
}
