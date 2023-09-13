using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MatrixManager : MonoBehaviour
{
    List<List<int>> colunas = new List<List<int>>();
    public GameObject elemento;
    Transform canvas;
    

    // Start is called before the first frame update
    void Start()
    {  
        canvas = GameObject.Find("Canvas").GetComponent<Transform>();
        CreateMatriz(2);
        printMatriz();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateMatriz(int qtd_variaveis)
    {
        
        
        
        for (int i = 0; i < qtd_variaveis; i++)
        {
            colunas.Add(new List<int>());
            int cont = 1;
            int valor = 1;

            for(int j = 1; j <= Mathf.Pow(2,qtd_variaveis); j++)
            {
                if(cont <= (Mathf.Pow(2,(qtd_variaveis-i))/2))
                {
                    cont++;
                }
                else
                {
                    if(valor == 1)
                    {
                        valor = 0;
                    }
                    else
                    {
                        valor = 1;
                    }
                    cont = 2;
                }
                colunas[i].Add(valor);

                Debug.Log("i:" + i + "j:" + j + "t:" + colunas[i][j-1]);
            }
            
        }

        int c_total = colunas.Count;
        Debug.Log(c_total);
        int total = 0;
        colunas.Add(new List<int>());
        
        
        for(int i = 0; i < Mathf.Pow(2,qtd_variaveis); i++)
        {
            for(int j = 0; j < qtd_variaveis; j++ )
            {
                total += colunas[j][i];
            }
            colunas[c_total].Add(total);
            total = 0;
        }



        //Debug.Log(colunas[0][0]);
    }

    void printMatriz()
    {
        int posX = 0;
        int posY = 0;
        TMP_Text m_textElement;

        foreach (List<int> i in colunas)
        {
            foreach(int j in i)
            {
                //Debug.Log(i[j]);
                GameObject clone = Instantiate(elemento, new Vector3(posX, posY, 0), Quaternion.identity, canvas.transform);
                clone.name = new string("x: " + posX + "y: " + posY);
                m_textElement = clone.GetComponent<TMP_Text>();
                m_textElement.text = new string("n: " +j);
                posY -= 50;
            }
            posY = 0;
            posX += 50;
        }
        

    }
}
