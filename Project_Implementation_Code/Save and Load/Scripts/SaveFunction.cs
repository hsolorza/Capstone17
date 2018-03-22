/***********************************************
 Created By: Rhea Mae Edwards
 Date: 3/21/2018
 Program Description:
 * Save implementation for iCreate project
 ***********************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEditor;

public class SaveFunction : MonoBehaviour {

    // Creates a GameObject called blockList
    // Which the GameObject is what this script in attached to in Unity
    public GameObject blockList;

    // Use this for initialization
    void Start()
    {

        string s = ""; 
        string path = "Assets/Resources/save_output.txt";

        string p1, p2, p3;
        string sc1, sc2, sc3;
        string r1, r2, r3;
        string type;

        // Looops through all of the GameObjects in the list of blocks
        // Finds and Stores each GameObject's position, scaling, rotation, and type
        // Ignores the saving of the parent game object, only considers the children being created
        foreach (Transform myChild in blockList.GetComponentsInChildren<Transform>())
        {
            // Prints string value name of GameObjects 
            //Debug.Log(myChild.name);
            if (myChild.name != blockList.name)
            {
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
        }

        // Prints string of GameObjects 
        //Debug.Log(s); 

        // Writes string in a stated file
        System.IO.File.WriteAllText(path, s);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
