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

    //NÃO, !
    //E, *
    //OU, + 
    //condicional, >
    //bicondicional, -

    //Transform do Canvas, para criação dos elementos
    Transform canvas;

    //Prefab dos elementos visuais da tabela verdade
    public GameObject elementPrefab;
    
    

    // Start is called before the first frame update
    void Start()
    {  
        //para testes
        expressao.Add('a');
        expressao.Add('*');
        expressao.Add('b');
        Debug.Log(expressao[0]);

        canvas = GameObject.Find("Canvas").GetComponent<Transform>();
        int qtd_variaveis = AnalyseExpression(expressao);
        CreateMatrix(qtd_variaveis);
        PrintMatrix();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int AnalyseExpression(List<char> expressao)
    {
        int i = 0;
        int qtd_variaveis = 0;

        foreach (char c in expressao)
        {
            switch (c)
            {
                case '!':
                case '*':
                case '+':
                case '>':
                case '-':
                    operations.Add(c);
                    variables.Add(new KeyValuePair<int,int>(i++,i++));
                    qtd_variaveis += 2;
                    Debug.Log(operations[^1]);
                    Debug.Log(variables.Count);
                    break;
                /* case 'a':
                case 'b':
                case 'c':
                    variables.Add(i++);
                    qtd_variaveis++;
                    Debug.Log(variables[^1]);
                    break; */
            }
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

        CalculateResultFieldMatrix(qtd_variaveis);
        



        //Debug.Log(truthTable_static[0][0]);
    }

    void CalculateResultFieldMatrix(int qtd_variaveis)
    //calcular o ultimo campo da matriz
    {
        int total_colunas = truthTable_static.Count;//atribui a quantidade atual de colunas
        int qtd_linhas = (int)Mathf.Pow(2,qtd_variaveis);//quantidade de linhas
        
        //int index_operation = 0;
        int index_variable = 0;
        
        bool result = true;//resultado da expressao

        truthTable_static.Add(new List<bool>());//adiciona uma nova coluna na tabela verdade
        
        Debug.Log(total_colunas);

        for(int linha = 0; linha < qtd_linhas; linha++)
        {
            foreach(char c in operations)
            {
                switch (c)
                {
                    case '!':
                        Debug.Log("nao implementado");
                        break;
                    case '*':
                        result = truthTable_static[variables[index_variable].Key][linha]
                                && truthTable_static[variables[index_variable].Value][linha];
                        break;
                    case '+':
                        result = truthTable_static[variables[index_variable].Key][linha]
                                || truthTable_static[variables[index_variable].Value][linha];
                        break;
                    case '>':
                        Debug.Log("nao implementado");
                        break;
                    case '-':
                        Debug.Log("nao implementado");
                        break;
                }
                
            }
/*             for(int coluna = 0; coluna < qtd_variaveis; coluna += 2)
            {
                foreach (char operacao in operations)
                {
                    
                }
                result = result && truthTable_static[coluna][linha];
                
            } */
            truthTable_static[total_colunas].Add(result);//atribui o valor final da ultima coluna
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
                posY -= 75;
            }
            posY = 0;
            posX += 75;
        }
        

    }
}
