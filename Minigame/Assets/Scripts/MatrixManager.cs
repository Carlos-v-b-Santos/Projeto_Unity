using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MatrixManager : MonoBehaviour
{
    List<List<int>> colunas = new List<List<int>>();
    public GameObject elemento;

    // Start is called before the first frame update
    void Start()
    {
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

            for(int j = 1; j <= Mathf.Pow(2,qtd_variaveis); j++)
            {
                if(j <= Mathf.Pow(2,qtd_variaveis-i)/2)
                {
                    colunas[i].Add(1);
                }
                else
                {
                    colunas[i].Add(0);
                }    
            }
            
        }
        Debug.Log(colunas[0][0]);
    }

    void printMatriz()
    {
        int posX = 0;
        int posY = 0;

        foreach (List<int> i in colunas)
        {
            foreach(int j in i)
            {
                GameObject clone = Instantiate(elemento, new Vector3(posX, posY, 0), Quaternion.identity);
                clone.name = new string("x: " + posX + "y: " + posY);
                posY -= 50;
            }
            posY = 0;
            posX += 50;
        }
        
    }
}
