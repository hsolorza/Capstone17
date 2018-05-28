using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierT : MonoBehaviour {

    // Number of times object in placed on Bezier Curve
    public int segments = 10;
    // Width of the Object
    public float objectWidth = 1;
    // User Input Variables, Points of Bezier Curve
    public float x1 = -5; // x1 of curve
    public float y1 = 4; // y1 of curve
    public float x2 = -1; // x2 of curve
    public float y2 = 10; // y2 of curve
    public float x3 = 1; // x3 of curve
    public float y3 = 0; // y3 of curve
    public float x4 = 5; // x4 of curve
    public float y4 = 6; // y4 of curve
    // List of Objects
    public List<GameObject> cube;
    // Some Variable
    private LineRenderer line;
    // User's GameObjects/objects
    public GameObject parent_object;
    // Public GameObject;
    public GameObject main_object;

    // Use this for initialization
    void Start () {

        // Setting up line components
        line = gameObject.GetComponent<LineRenderer>();
        line.positionCount = (segments + 1);
        line.useWorldSpace = false;

        // Calling function to place objects along Bezier Curve
        CreatePoints();

    }

    void CreatePoints() {

        // Create a new list for objects
        cube = new List<GameObject>(segments);
        // Length of the list created above
        int list_length = 0;
        // Creating a GameObject for the object being used
        GameObject store_object;
        // Physical variables to use to define each object along the Bezier Curve
        float x = 0f; // x of equation
        float y = 0f; // y of equation
        float z = 0f;
        // Initial t for the object
        float t = 0f;

        // Loop going through Bezier Curve based off number of segments calculated earlier
        for (int i = 0; i < (segments + 1); i++)
        {
            // Calculating t variable for Bezier curve equations
            t = i / (float)segments;

            // Calculating x and y of an object based off the four points and t of the Bezier Curve
            // x = (1-t)^3*x1 + 3(1-t)^2*t*x2 + 3(1-t)*t^2*x3 + t^3*x4, where 0 < t< 1
            // y = (1-t)^3*y1 + 3(1-t)^2*t*y2 + 3(1-t)*t^2*y3 + t^3*y4, where 0 < t < 1
            x = (Mathf.Pow((1 - t), 3) * x1) + (3 * Mathf.Pow((1 - t), 2) * t * x2) + (3 * (1 - t) * Mathf.Pow(t, 2) * x3) + (Mathf.Pow(t, 3) * x4);
            y = (Mathf.Pow((1 - t), 3) * y1) + (3 * Mathf.Pow((1 - t), 2) * t * y2) + (3 * (1 - t) * Mathf.Pow(t, 2) * y3) + (Mathf.Pow(t, 3) * y4);

            // Setting position calculated
            line.SetPosition(i, new Vector3(x, y, z));
            // Printing out x position of object
            Debug.Log("X-Position: " + line.GetPosition(i).x);
            Debug.Log("Y-Position: " + line.GetPosition(i).y);

            // Placing the user's object along the curve
            store_object = Instantiate(parent_object, new Vector3(x, y, z), Quaternion.identity) as GameObject;

            // Inserting object to list
            cube.Insert(i, store_object);
        }

        // Counts the number of GameObjects in the list
        list_length = cube.Count;

        // Makes all of the elements in the list above children of the user's created GameObject previously
        for (int i = 0; i < list_length; i++) {
            cube[i].transform.parent = main_object.transform;
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
