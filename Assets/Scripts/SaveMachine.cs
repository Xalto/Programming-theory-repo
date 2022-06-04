using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveMachine : MonoBehaviour
{
    public static SaveMachine Instance;

    public string playerName;
    public int scorePoints, level = 1, colId, shaId = 99;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(Instance);
    }


}
