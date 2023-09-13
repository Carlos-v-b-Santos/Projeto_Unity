using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MatrixManager : MonoBehaviour
{
    //lista de listas para formar a tabela verdade estatica
    List<List<bool>> truthTable_static = new List<List<bool>>();

    List<char> expressao;

    //NÃO, '
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
        canvas = GameObject.Find("Canvas").GetComponent<Transform>();
        CreateMatrix(2);
        PrintMatrix();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        bool result = true;//resultado da expressao

        truthTable_static.Add(new List<bool>());//adiciona uma nova coluna na tabela verdade
        
        Debug.Log(total_colunas);

        for(int linha = 0; linha < qtd_linhas; linha++)
        {
            result = truthTable_static[0][linha];
            for(int coluna = 1; coluna < qtd_variaveis; coluna++)
            {
                result = result && truthTable_static[coluna][linha];
                
            }
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
