using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawnables;

    void Awake()
    {
        NewLevel();
    }

    public void LevelUp()
    {
        SaveMachine.Instance.level++;
        NewLevel();
    }

    void NewLevel()
    {
        SpawnObj(SaveMachine.Instance.level);
    }

    void SpawnObj(int total)
    {
        for (int i = 0; i < total; i++)
        {
            int randomObj = Random.Range(0, spawnables.Length);
            Instantiate(spawnables[randomObj], RandomPos(), transform.rotation);
        }
    }

    private Vector3 RandomPos()
    {
        int xValue = Random.Range(-5, 6);
        int yValue = Random.Range(-5, 6);
        Vector3 position = new Vector3(xValue, yValue, 0);
        return position;
    }
}
