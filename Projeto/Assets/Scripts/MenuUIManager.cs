using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _menuList;
    [SerializeField] private Button[] _firstSelected;
    [SerializeField] private int _menuID = 0;
    [SerializeField] private AudioSource _audioSource;

    private void Start()
    {
        if (_audioSource == null)
        {
            Debug.LogError("Audio Source is NULL");
        }

        _audioSource = GetComponent<AudioSource>();

        SelectedMenu(_menuID);
    }

    public void ActivateMenu(Button button)
    {
        if (button.name == "Options_Button")
        {
            _menuID = 1;
            StartCoroutine(WaitForSound());
        }
        else if(button.name == "Back_Button")
        {
            _menuID = 0;
            StartCoroutine(WaitForSound());
        }
    }

    private void SelectedMenu(int menuID)
    {
        foreach (GameObject menu in _menuList)
        {
            menu.SetActive(false);
        }

        _menuList[menuID].SetActive(true);
        _firstSelected[menuID].Select();

    }

    IEnumerator WaitForSound()
    {
        yield return new WaitForSeconds(.3f);
        SelectedMenu(_menuID);
    }
}
