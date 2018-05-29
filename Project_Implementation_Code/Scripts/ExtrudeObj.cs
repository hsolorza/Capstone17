using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtrudeObj : MonoBehaviour {

    public float extrudeX = 1f;
    public float extrudeY = 1f;
    public float extrudeZ = 1f;

    //public GameObject myObj;

    void Update()
    {
        transform.localScale = new Vector3(extrudeX, extrudeY, extrudeZ);
    }

    public void AdjustExtrudeX(float newExtrudeX)
    {
        extrudeX = newExtrudeX;

    }

    public void AdjustExtrudeY(float newExtrudeY)
    {
        extrudeY = newExtrudeY;

    }

    public void AdjustExtrudeZ(float newExtrudeZ)
    {
        extrudeZ = newExtrudeZ;

    }
}
