using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.InputSystem;

public class InfoPanel : MonoBehaviour
{
    private const string ethicMeterKey = "ETHIC_METER";
    private const string totalScoreKey = "TotalScore";

    public GameObject menuPanel;
    public TextMeshProUGUI ethicMeter;
    public TextMeshProUGUI minigamePoints;
    public List<TextMeshProUGUI> npcsRelations = new List<TextMeshProUGUI>();
    public List<string> npcsNames = new List<string>();
    public List<string> npcsRoles = new List<string>();
    [SerializeField] bool isActive;
    // Start is called before the first frame update
    void Start()
    {
         menuPanel.SetActive(false);
         isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateRelationships()
    {
        for (int i = 0; i < npcsNames.Count; i++)
        {
            var value = PlayerPrefs.GetInt(npcsRoles[i], 0);
            npcsRelations[i].text = string.Format(npcsNames[i].ToString() + " = " + value);
        }
    }

    void ShowMenu()
    {
        Debug.Log("abrir menu");
        UpdateRelationships();
        ethicMeter.text = string.Format("Pontos de ética:" + PlayerPrefs.GetInt(ethicMeterKey));
        minigamePoints.text = string.Format("Pontos no minigame:" + PlayerPrefs.GetInt(totalScoreKey, 0));
    }

    public void SwitchState()
    {
        Debug.Log("abra menu");
        if (isActive)
        {
            menuPanel.SetActive(false);
            isActive = false;
        }
        else
        {
            ShowMenu();
            menuPanel.SetActive(true);
            isActive = true;
        }
    }
    public void SwitchState(InputAction.CallbackContext context)
    {
        Debug.Log("abra menu");
        if (isActive)
        {
            menuPanel.SetActive(false);
            isActive = false;
        }
        else
        {
            ShowMenu();
            menuPanel.SetActive(true);
            isActive = true;
        }
    }

    private void OnEnable()

    {
        GameManager.Instance.playerInputActions.Player.Menu.performed += SwitchState;
        GameManager.Instance.playerInputActions.Player.Menu.performed += SwitchState;
        
    }

    private void OnDisable()
    {
        GameManager.Instance.playerInputActions.Player.Menu.performed -= SwitchState;
    }

}
