using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveMachine : MonoBehaviour
{
    public static SaveMachine Instance;

    public string playerName;
    public int scorePoints, level;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
