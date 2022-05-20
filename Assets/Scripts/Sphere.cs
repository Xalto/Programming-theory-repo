using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : Object
{
    public float boundaries = 1, pivotPoint;
    private Vector3 startingPos;

    public override void Awake()
    {
        base.Awake();
        startingPos = transform.localPosition;
        pivotPoint = startingPos.x + boundaries;
    }
    private void Update()
    {
        ObjectMovement();
    }
    public override void ObjectMovement()
    {
        Traslation(speed);
    }
    public void Traslation(float speed)
    {
        if (transform.localPosition.x > pivotPoint)
        {
            objRB.AddForce(Time.deltaTime * -speed, 0, 0, ForceMode.VelocityChange);
        }
        else
        {
            objRB.AddForce(Time.deltaTime * speed, 0, 0, ForceMode.VelocityChange);
        }
    }
}
