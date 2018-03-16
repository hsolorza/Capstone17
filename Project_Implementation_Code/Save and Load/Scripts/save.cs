﻿/***********************************************
 Created By: Rhea Mae Edwards
 Date: 3/16/2018
 Program Description:

 ***********************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEditor;
using System.IO;

public class save : MonoBehaviour {

    // Creates a GameObject called blockList
    // Which the GameObject is what this script in attached to in Unity
    public GameObject blockList;

    // Use this for initialization
    void Start() {

        string s = ""; // \n
        string textIn = "";
        string path = "Assets/Resources/test.txt";

        string p1, p2, p3;
        string sc1, sc2, sc3;
        string r1, r2, r3;
        string type;

        // Looops through all of the GameObjects in the list of blocks
        // Finds and Stores each GameObject's position, scaling, rotation, and type
        foreach (Transform myChild in blockList.GetComponentsInChildren<Transform>()) {
            s = string.Concat(s, "(");
            p1 = (myChild.position.x).ToString();
            p2 = (myChild.position.y).ToString();
            p3 = (myChild.position.z).ToString();
            s = string.Concat(s, p1, ",", p2, ",", p3, ",");
            sc1 = (myChild.localScale.x).ToString();
            sc2 = (myChild.localScale.y).ToString();
            sc3 = (myChild.localScale.z).ToString();
            s = string.Concat(s, sc1, ",", sc2, ",", sc3, ",");
            r1 = (myChild.eulerAngles.x).ToString();
            r2 = (myChild.eulerAngles.y).ToString();
            r3 = (myChild.eulerAngles.z).ToString();
            s = string.Concat(s, r1, ",", r2, ",", r3, ",");
            type = "T";
            s = string.Concat(s, type, ")\n");
        }

        // Prints string of GameObjects
        Debug.Log(s);

        // Writes string in a stated file
        System.IO.File.WriteAllText(path, s);

        // Prints out contents as a string in the file the string was store into
        textIn = System.IO.File.ReadAllText(path);
        Debug.Log(textIn);
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

*************************************************
        b.x_coord;
        b.y_coord;
        b.z_coord;

        b.Type type;

        b.x_scale;
        b.y_scale;
        b.z_scale;

        b.x_rotation;
        b.y_rotation;
        b.z_rotation;

        Console.WriteLine(b.x_coord.ToString());
*************************************************/

/*
    BlockInit b = block;

    string x_c, y_c, z_c, x_s, y_s, z_s, x_r, y_r, z_r, type;

    x_c = b.x_coord.ToString();
    y_c = b.y_coord.ToString();
    z_c = b.z_coord.ToString();

    x_s = b.x_scale.ToString();
    y_s = b.y_scale.ToString();
    z_s = b.z_scale.ToString();

    x_r = b.x_rotation.ToString();
    y_r = b.y_rotation.ToString();
    z_r = b.z_rotation.ToString();

    type = b.type.ToString();

    string data = x_c + y_c + z_c + x_s + y_s + z_s + x_r + y_r + z_r + type;

    Debug.Log(data);
    */
