using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public Material[] materials;
    public Rigidbody objRB;
    public int objectID, scoreValue = 5;

    public float speed = 5;

    public virtual void Awake()
    {
        objRB = GetComponent<Rigidbody>();
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

    public void ScoreUp()
    {
        SaveMachine.Instance.ScorePoints(scoreValue);
    }

    void TrackID()
    {
        int shape = 0;
        int color = 0;
        if (transform.GetComponent<Renderer>().material.name == "Red (Instance)")
        {
            color = 1;
        } else if (transform.GetComponent<Renderer>().material.name == "Green (Instance)")
        {
            color = 2;
        } else if (transform.GetComponent<Renderer>().material.name == "Blue (Instance)")
        {
            color = 3;
        }

        if (transform.name == "Sphere(Clone)")
        {
            shape = 1;
        }
        else if (transform.name == "Cube(Clone)")
        {
            shape = 2;
        }
        else if (transform.name == "Capsule(Clone)")
        {
            shape = 3;
        }

        objectID = (shape * 10 + color);
        Debug.Log(objectID.ToString());
    }
}
