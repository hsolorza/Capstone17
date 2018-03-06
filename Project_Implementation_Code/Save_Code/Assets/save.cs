/***********************************************
 Writing "hello" to another file in Unity in C#
 ***********************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class save : MonoBehaviour {

	// Use this for initialization
	void Start () {

        string s = "hello";
        string path = "Assets/Resources/test.txt";

        // Prints "hello"
        Debug.Log(s);

        // Writes string in a stated file
        System.IO.File.WriteAllText(path, s);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}



/**************** End Goal ************************
Data Structure:
Obj{
	Coordinates[3];
	Scale[3];
	Rotation[3];
	Type[1];
};

String:
(x, y, z, t, s1, s2, s3, r1, r2, r3)
(cord1, cord2, cord3, type, scale1, scale2, scale3, rot1, rot2, rot3)

Size = s1, s2, s3, r1, r2, r3

- Takes type above
- Writes file as a string

- Values (int) to String
- String and save into a file
*************************************************/
