﻿/***********************************************
 Created By: Rhea Mae Edwards
 Date: 3/21/2018
 Program Description:
 * Load implementation for iCreate project
 ***********************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEditor;

public class LoadFunction : MonoBehaviour {

    // Creates list of GameObjects to spawn back into a game scene
    public List<GameObject> spawn_list;

    //public GameObject loadedList;

    // Use this for initialization
    void Start()
    {
        string textIn = "";
        string path2 = "Assets/Resources/load_input.txt";

        string[] object_list;
        ArrayList character_list = new ArrayList();

        int count;
        int spawn_index = 0;
        GameObject tempObject;
        spawn_list = new List<GameObject>();

        float po1, po2, po3;
        float sca1, sca2, sca3;
        float ro1, ro2, ro3;

        // Reads the string in the stated file
        // Store string into textIn variable
        //textIn = System.IO.File.ReadAllText(path);
        textIn = System.IO.File.ReadAllText(path2);

        // Prints out contents as a string in the file the string was store into
        //Debug.Log(textIn); 

        // Tokenizes GameObjects described in the string from the file by newline (\n)
        // Adds objects in a string array, object_list
        object_list = textIn.Split('\n');
        //Debug.Log(object_list);

        foreach (string gameobj in object_list)
        {
            string obj;

            // Ignoring the first and last character on each line (the opening and closing parantheses (( and )))
            // Puts a GameObject in a variable called obj for useage
            obj = gameobj.Replace("(", "");
            obj = obj.Replace(")", "");
            //Debug.Log(obj);

            // Tokenize each component in each of the GameObjects by comma (,)
            // Takes a GameObject's componenets and stores them in a string array called item_list
            string[] item_list;
            item_list = obj.Split(',');
            //Debug.Log(item_list);

            // Inputs each component in an ongoing Arraylist called character_list
            foreach (string item in item_list)
            {
                character_list.Add(item);
                //Debug.Log(item);
            }
        }

        // Create/Spawn a GameObject(s) based of the componenets in the Arraylist (character_list)

        // (character_list[0], character_list[1], character_list[2], character_list[3], character_list[4], character_list[5], character_list[6], 
        //  character_list[7], character_list[8], character_list[9]) and so on/repeat in the same list
        // (float, float, float, float, float, float, float, float, float, string)
        // (p1, p2, p3, sc1, sc2, sc3, r1, r2, r3, type)

        // (object, object, object, object, object, object, object, object, object, object)

        // For Loop Algorithm:
        // For every set of 10 elements in character_list AKA every one object
        // - Check which type the object is, every 10 steps, first occurance: character_list[9] and so on..
        // - Covert strings/objects back into floats, except for the type, as the following occur:
        //    - Get the x, y, z position of object
        //    - Get the x, y, z scale of object
        //    - Get the x, y, z rotation of object
        //    - Spawn the object into the game scene

        count = character_list.Count;

        for (int i = 0; i < count - 1; i++)
        {
            // i += 9; at the end every time an object is spawned

            string tempType = Convert.ToString(character_list[i + 9]);

            if (tempType == "T")
            {
                po1 = Convert.ToSingle(character_list[i]);
                po2 = Convert.ToSingle(character_list[i + 1]);
                po3 = Convert.ToSingle(character_list[i + 2]);
                sca1 = Convert.ToSingle(character_list[i + 3]);
                sca2 = Convert.ToSingle(character_list[i + 4]);
                sca3 = Convert.ToSingle(character_list[i + 5]);
                ro1 = Convert.ToSingle(character_list[i + 6]);
                ro2 = Convert.ToSingle(character_list[i + 7]);
                ro3 = Convert.ToSingle(character_list[i + 8]);

                tempObject = GameObject.CreatePrimitive(PrimitiveType.Cube);

                tempObject.transform.position = new Vector3(po1, po2, po3);
                tempObject.transform.localScale = new Vector3(sca1, sca2, sca3);
                tempObject.transform.eulerAngles = new Vector3(ro1, ro2, ro3);

                spawn_list.Insert(spawn_index, tempObject);
                spawn_index += 1;

                i += 9;
            }
            /*
            else if (character_list[i + 9] == "[type]") {

                i += 9;
            }
            */
            else
            {
                Debug.Log("Unable to create a GameObject.");
                i += 9;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
