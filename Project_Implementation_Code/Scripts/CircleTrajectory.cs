using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CircleTrajectory : MonoBehaviour
{
    private int segments = 60;
    public float objectWidth = 1;
    public float xoffset = 5;
    public float yoffset = 5;
    public float zoffset = 0;
    public float shrink = 1;
    public float xradius;
    public float yradius;
    public List<GameObject> cube;
    private LineRenderer line;

    void Start()
    {
        segments = (int)(360 / (Mathf.Asin(objectWidth / (xradius)) * 180.0 / 3.1415));
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
         
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * xradius + xoffset;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * yradius + yoffset;

            line.SetPosition(i, new Vector3(x, y, z));
            Debug.Log(line.GetPosition(i).x);
            tempCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //tempCube.AddComponent<Rigidbody>();
            tempCube.transform.position = new Vector3(line.GetPosition(i).x, line.GetPosition(i).y, line.GetPosition(i).z);
            float xAngle = Mathf.Acos((line.GetPosition(i).x - xoffset) / xradius) * (float)(180.0 / 3.1415) * (line.GetPosition(i).y - xoffset)/Mathf.Abs((line.GetPosition(i).y - xoffset));
            tempCube.transform.localEulerAngles = new Vector3(0,0,xAngle);
            
            cube.Insert(i, tempCube);
            angle += (360f / segments);
        }
    }
}
