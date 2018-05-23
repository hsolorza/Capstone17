using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleT : MonoBehaviour {

    // Number of times object in placed on Circle
    private int segments = 10;
    // Width of the Object
    public float objectWidth = 1;
    // User Input Variables
    public float xoffset = 0;
    public float yoffset = 0;
    public float zoffset = 0;
    // Radius of the Circle
    public float xradius = 4;
    public float yradius = 4;
    // List of Objects
    public List<GameObject> cube;
    // Some Variable
    private LineRenderer line;
    // User's GameObjects/objects
    public GameObject parent_object;
    //public GameObject;
    public GameObject main_object;

    // Use this for initialization
    void Start () {

        // Having object spawn in front of user
        xoffset = Camera.main.transform.position.x;
        yoffset = Camera.main.transform.position.y;
        zoffset = Camera.main.transform.position.z + 6;

        // Calculating number of spaces an object will be placed at on circle
        segments = (int)(360 / (Mathf.Asin(objectWidth / (xradius)) * (180.0 / 3.1415)));
        Debug.Log("Segments: " + segments);

        line = gameObject.GetComponent<LineRenderer>();
        line.positionCount = (segments + 1);
        line.useWorldSpace = false;

        // Calling function to place objects along circle
        CreatePoints();

    }

    void CreatePoints() {

        // Create a new list for objects
        cube = new List<GameObject>(segments);
        // Length of the list created above
        int list_length = 0;
        // Creating a GameObject for the object being used
        GameObject store_object;
        //GameObject tempCube
        // Physical variables to use to define each object along the circle
        float x = 0f;
        float y = 0f;
        float z = 0f;
        // Initial angle for the object
        float angle = 20f;

        // Loop going through circle based off number of segments calculated earlier
        for (int i = 0; i < (segments + 1); i++)
        {
            // Calculating x and y of an object based off angle and radius of the circle
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * xradius + xoffset;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * yradius + yoffset;

            // Setting position calculated
            line.SetPosition(i, new Vector3(x, y, z));
            // Printing out x position of object
            Debug.Log(line.GetPosition(i).x);

            // Creating a cube as the GameObject being used
            //tempCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            /*tempCube.AddComponent<Rigidbody>();*/

            // Placing object at calculated position
            //tempCube.transform.position = new Vector3(line.GetPosition(i).x, line.GetPosition(i).y, line.GetPosition(i).z);
            //prefab.transform.position = new Vector3(line.GetPosition(i).x, line.GetPosition(i).y, line.GetPosition(i).z);

            // Calculating angle of the object of the circle
            //float xAngle = Mathf.Acos((line.GetPosition(i).x - xoffset) / xradius) * (float)(180.0 / 3.1415) * (line.GetPosition(i).y - xoffset) / Mathf.Abs((line.GetPosition(i).y - xoffset));

            // Rotating object based off calculated angle from earlier
            //tempCube.transform.localEulerAngles = new Vector3(0, 0, xAngle);

            // Placing the user's object along the curve
            //Instantiate(parent_object.transform, new Vector3(x, y, z), Quaternion.identity);
            store_object = Instantiate(parent_object, new Vector3(x, y, z), Quaternion.identity) as GameObject;

            // Inserting object to list
            cube.Insert(i, store_object);
            //cube.Insert(i, tempCube);

            // Calculating next angle based off an additional segment calculated from earlier
            angle += (360f / segments);
        }

        // Counts the number of GameObjects in the list
        list_length = cube.Count;

        // Makes all of the elements in the list above children of the user's created GameObject previously
        for (int i = 0; i < list_length; i++) {

            //cube[i].transform.SetParent(parent_object, false);
            cube[i].transform.parent = main_object.transform;

        }

    }

    // Update is called once per frame
    void Update () {
		
	}
}
