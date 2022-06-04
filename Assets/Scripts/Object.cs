using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public Material[] materials;
    public Rigidbody objRB;
    public GameManager manager;
    public int colID, shaID, scoreValue = 5;

    public float speed = 5;

    public virtual void Awake()
    {
        objRB = GetComponent<Rigidbody>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        SetMaterial();
        ObjectMovement();
        TrackID();
    }

    public void SetMaterial()
    {
        int randomMat = Random.Range(0, materials.Length);
        transform.GetComponent<Renderer>().sharedMaterial = materials[randomMat];
    }

    public virtual void ObjectMovement()
    {
        Rotation(speed);
    }

    public void Rotation(float speed)
    {
        objRB.AddTorque(speed, speed, speed, ForceMode.Impulse);
    }

    public void ScoreUp(int mult)
    {
        manager.ScorePoints(scoreValue * mult);
    }

    public void TrackID()
    {
        if (transform.GetComponent<Renderer>().material.name == "Red (Instance)")
        {
            colID = 0;
        } else if (transform.GetComponent<Renderer>().material.name == "Green (Instance)")
        {
            colID = 1;
        } else if (transform.GetComponent<Renderer>().material.name == "Blue (Instance)")
        {
            colID = 2;
        }

        if (transform.name == "Sphere(Clone)")
        {
            shaID = 0;
        }
        else if (transform.name == "Cube(Clone)")
        {
            shaID = 1;
        }
        else if (transform.name == "Capsule(Clone)")
        {
            shaID = 2;
        }

        Debug.Log(colID.ToString() + ", " + shaID.ToString());
    }

    private void OnMouseDown()
    { 
        IDCheck();
        SaveMachine.Instance.shaId = shaID;
        SaveMachine.Instance.colId = colID;
        DestroyAll("Solid");
        GameObject.Find("Spawner").GetComponent<Spawner>().LevelUp();
    }

    void DestroyAll(string tag)
    {
        GameObject[] objectsInScene = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject item in objectsInScene)
        {
            Destroy(item);
        }
    }

    void IDCheck()
    {
        if (SaveMachine.Instance.shaId == 99)
        {
            SaveMachine.Instance.shaId = shaID;
            SaveMachine.Instance.colId = colID;
            ScoreUp(1);
            return;
        }
        if (shaID == SaveMachine.Instance.shaId)
        {
            if (colID == SaveMachine.Instance.colId)
            {
                ScoreUp(2);
            }
            else if (colID != SaveMachine.Instance.colId)
            {
                ScoreUp(1);
            }
        }
        else if (shaID != SaveMachine.Instance.shaId)
        {
            if (colID == SaveMachine.Instance.colId)
            {
                ScoreUp(1);
            }
            else if (colID != SaveMachine.Instance.colId)
            {
                ScoreUp(-1);
            }
        }
    }
}
