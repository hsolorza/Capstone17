using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CircleTrajectory : MonoBehaviour
{
    public int segments = 60;
    public float xoffset = 0;
    public float yoffset = 0;
    public float shrink = 1;
    public float xradius;
    public float yradius;
    public List<GameObject> cube;
    private LineRenderer line;

    void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();

        line.positionCount = (segments + 1);
        line.useWorldSpace = false;
        CreatePoints();
    }


    void CreatePoints()
    {
        cube = new List<GameObject>(segments);
        GameObject tempCube;
        float x;
        float y;
        float z = 0f;

        float angle = 20f;

        for (int i = 0; i < (segments + 1); i++)
        {
            // circle
            //x = Mathf.Sin(Mathf.Deg2Rad * angle) * xradius + xoffset;
            //y = Mathf.Cos(Mathf.Deg2Rad * angle) * yradius + yoffset;
            //prabola
            x = i - segments/2 + xoffset;
            y = x*x*shrink + yoffset;   // a/2 t^2 + v0t + xdisp
            line.SetPosition(i, new Vector3(x, y, z));
            Debug.Log(line.GetPosition(i).x);
            tempCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //tempCube.AddComponent<Rigidbody>();
            tempCube.transform.position = new Vector3(line.GetPosition(i).x, line.GetPosition(i).y, line.GetPosition(i).z);
            cube.Insert(i, tempCube);
            angle += (360f / segments);
        }
    }
}
