using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuInicialManager : MonoBehaviour
{
    [SerializeField] TMP_InputField inputName;
    [SerializeField] GameObject text_warning;

    //[SerializeField] GameObject loadGameButton;
    //[SerializeField] GameObject newGameButton;
    //[SerializeField] GameObject exitButton;

    public const string playerNameKey = "PLAYER_NAME";

    public void LoadGameButton()
    {
        if (PlayerPrefs.HasKey(playerNameKey))
        {
            text_warning.SetActive(false);
            PlayerPrefs.SetString(playerNameKey, inputName.text);
            GameManager.Instance.EnterPrincipalScene();
        }
        else
        {
            Debug.Log("não tem jogos salvos");
            text_warning.SetActive(true);
        }
    }

    public void NewGameButton()
    {
        text_warning.SetActive(false);
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString(playerNameKey, inputName.text);
        GameManager.Instance.EnterPrincipalScene();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
