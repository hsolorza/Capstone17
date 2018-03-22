using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierTrajectory : MonoBehaviour {
    public int segments = 60;
    public float objectWidth = 1;
    public float xoffset = 5;
    public float yoffset = 5;
    public float zoffset = 0;
    public float x1, x2, x3, x4, y1, y2, y3, y4, z1, z2, z3, z4;
    public struct point
    {
        public float X;
        public float Y;
        public float Z;
    };
    public List<GameObject> cube;
    private LineRenderer line;
    public List< point> rOut;
    void Start()
    {
        //segments = (int)(360 / (Mathf.Asin(objectWidth / (xradius)) * 180.0 / 3.1415));
        line = gameObject.GetComponent<LineRenderer>();

        line.positionCount = (segments + 1);
        line.useWorldSpace = false;
        CreatePoints();
    }
    private void Bezier( point one, point two,  point three, point four, int res)
{
        rOut = new List<point>(segments);
        for (int i = 0; i<res; i++)
	{
            point tmp;
		    float t = (float)i * (float)1 / (float)res;
            tmp.X = (Mathf.Pow((1-t),3)*one.X) +
			(3*t* Mathf.Pow(1-t,2)*two.X) +
			(3*Mathf.Pow(t,2)*(1-t)*three.X) +
			(Mathf.Pow(t,3)*four.X);
            tmp.Y = (Mathf.Pow((1-t),3)*one.Y) +
			(3*t* Mathf.Pow(1-t,2)*two.Y) +
			(3*Mathf.Pow(t,2)*(1-t)*three.Y) +
			(Mathf.Pow(t,3)*four.Y);
            tmp.Z = (Mathf.Pow((1-t),3)*one.Z) +
			(3*t* Mathf.Pow(1-t,2)*two.Z) +
			(3*Mathf.Pow(t,2)*(1-t)*three.Z) +
			(Mathf.Pow(t,3)*four.Z);
            rOut.Insert(i,tmp);
    }
}
    void CreatePoints()
    {

        cube = new List<GameObject>(segments);
        GameObject tempCube;
        float x;
        float y;
        float z;

        point a,b,c,d;
        a.X = x1;
        a.Y = y1;
        a.Z = z1;
        b.X = x2;
        b.Y = y2;
        b.Z = z2;
        c.X = x3;
        c.Y = y3;
        c.Z = z3;
        d.X = x4;
        d.Y = y4;
        d.Z = z4;
        Bezier(a,b,c,d,segments);
        for (int i = 0; i < (segments); i++)
        {
            x = rOut[i].X + xoffset;
            y = rOut[i].Y + yoffset;
            z = rOut[i].Z + zoffset;

            line.SetPosition(i, new Vector3(x, y, z));
            Debug.Log(line.GetPosition(i).x);
            tempCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //tempCube.AddComponent<Rigidbody>();
            tempCube.transform.position = new Vector3(line.GetPosition(i).x, line.GetPosition(i).y, line.GetPosition(i).z);
            cube.Insert(i, tempCube);
        }
    }
}
