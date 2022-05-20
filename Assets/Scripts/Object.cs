using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public Material[] materials;
    public Rigidbody objRB;

    public float speed = 5;

    public virtual void Awake()
    {
        objRB = GetComponent<Rigidbody>();
        SetMaterial();
        ObjectMovement();
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
}
