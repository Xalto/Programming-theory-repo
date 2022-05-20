using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public Material[] materials;
    private Material objMat;
    private Rigidbody objRB;

    public float speed = 5;

    private void Awake()
    {
        objMat = GetComponent<Renderer>().sharedMaterial;
        objRB = GetComponent<Rigidbody>();
        SetMaterial();
        ObjectMovement();
    }

    void SetMaterial()
    {
        int randomMat = Random.Range(0, materials.Length);
        objMat = materials[randomMat];
    }

    public virtual void ObjectMovement()
    {
        Rotation(speed);
    }

    void Rotation(float speed)
    {
        objRB.AddTorque(speed, speed, speed, ForceMode.Impulse);
    }
}
