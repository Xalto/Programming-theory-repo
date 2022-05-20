using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawnables;
    // Start is called before the first frame update
    void Start()
    {
        NewLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LevelUp()
    {
        SaveMachine.Instance.level++;
    }

    void NewLevel()
    {
        SpawnObj(SaveMachine.Instance.level);
    }

    void SpawnObj(int total)
    {

        for (int i = 0; i < total; i++)
        {
            Instantiate(spawnables[0], RandomPos(), transform.rotation);
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
