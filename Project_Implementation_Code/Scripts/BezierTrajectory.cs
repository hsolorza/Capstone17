using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierTrajectory : MonoBehaviour {

    public struct point
    {
        public float X;
        public float Y;
        public float Z;
    };

    private void Bezier( point one, point two,  point three, point four, point rOut, int res)
{
	for(int i = 0; i<res; i++)
	{
		float t = (float)i * (float)1 / (float)res;
		rOut.X = (Mathf.Pow((1-t),3)*one.X) +
			(3*t* Mathf.Pow(1-t,2)*two.X) +
			(3*Mathf.Pow(t,2)*(1-t)*three.X) +
			(Mathf.Pow(t,3)*four.X);
		rOut.Y = (Mathf.Pow((1-t),3)*one.Y) +
			(3*t* Mathf.Pow(1-t,2)*two.Y) +
			(3*Mathf.Pow(t,2)*(1-t)*three.Y) +
			(Mathf.Pow(t,3)*four.Y);
		rOut.Z = (Mathf.Pow((1-t),3)*one.Z) +
			(3*t* Mathf.Pow(1-t,2)*two.Z) +
			(3*Mathf.Pow(t,2)*(1-t)*three.Z) +
			(Mathf.Pow(t,3)*four.Z);
	}
}
}
