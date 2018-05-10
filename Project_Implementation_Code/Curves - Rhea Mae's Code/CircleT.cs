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
    public float xradius;
    public float yradius;
    // List of Objects
    public List<GameObject> cube;
    // Some Variable
    private LineRenderer line;

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
        // Creating a GameObject for the object being used
        GameObject tempCube;
        // Physical variables to use to define each object along the circle
        float x;
        float y;
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
            tempCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            /*tempCube.AddComponent<Rigidbody>();*/

            // Placing object at calculated position
            tempCube.transform.position = new Vector3(line.GetPosition(i).x, line.GetPosition(i).y, line.GetPosition(i).z);

            // Calculating angle of the object of the circle
            float xAngle = Mathf.Acos((line.GetPosition(i).x - xoffset) / xradius) * (float)(180.0 / 3.1415) * (line.GetPosition(i).y - xoffset) / Mathf.Abs((line.GetPosition(i).y - xoffset));

            // Rotating object based off calculated angle from earlier
            tempCube.transform.localEulerAngles = new Vector3(0, 0, xAngle);

            // Placing cube..?
            cube.Insert(i, tempCube);

            // Calculating next angle based off an additional segment calculated from earlier
            angle += (360f / segments);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
