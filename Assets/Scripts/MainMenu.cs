using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TMP_InputField inputName;
    public GameObject playerNameScreen;

    public void StartGame()
    {
        string name = inputName.text;
        SaveMachine.Instance.playerName = name;
        SceneManager.LoadScene(1);
    }

    public void NameSelect()
    {
        playerNameScreen.SetActive(true);        
    }
}
