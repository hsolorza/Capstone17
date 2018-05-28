using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolaT : MonoBehaviour {

    // Equation for an Parabola (Vertex Form)
    // y = a(x-h)^2 + k

    // Number of times object in placed on Parabola
    public int segments = 10;
    // Width of the Object
    public float objectWidth = 1;
    public float objectHeight = 1;
    // User Input Variables
    public float xoffset = 0; // h or x0 of equation
    public float yoffset = 0; // v or y0 of equation
    public float zoffset = 0;
    // x-coefficient of the Parabola
    public float a = 1; // a or p of equation
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

        // Having object spawn in front of user
        xoffset = Camera.main.transform.position.x;
        yoffset = Camera.main.transform.position.y;
        zoffset = Camera.main.transform.position.z + 6;

        // Setting up line components
        line = gameObject.GetComponent<LineRenderer>();
        line.positionCount = (segments + 1);
        line.useWorldSpace = false;

        // Calling function to place objects along Parabola
        CreatePoints();

    }

    void CreatePoints() {

        // Create a new list for objects
        cube = new List<GameObject>(segments);
        // Creating a GameObject for the object being used
        GameObject store_object;
        // Physical variables to use to define each object along the Parabola
        float x = 0f; // x of equation
        float y = 0f; // y of equation
        float z = 0f;
        // Starting angle for the object
        float angle = 20f;

        // Loop going through Parabola based off number of segments calculated earlier
        for (int i = 0; i < (segments + 1); i++)
        {
            // Calculating x and y of an object based off equation for Parabola
            // y = a(x-h)^2 + k
            // Inverse: x = sqrt((y-k) / a) + h
            y = y + objectHeight;
            x = (Mathf.Sqrt(y - yoffset) / a) + xoffset;

            // Setting position calculated
            line.SetPosition(i, new Vector3(x, y, z));

            // Placing the user's object along the curve
            store_object = Instantiate(parent_object, new Vector3(x, y, z), Quaternion.identity) as GameObject;

            // Inserting object to list
            cube.Insert(i, store_object);

            // Makes the element/GameObject above a child of the user's created GameObject previously
            cube[i].transform.parent = main_object.transform;

            // Graphing the other side of the Parabola
            /*********************************************************************************/

            // Calculating left-side of the Parabola
            x = (-1) * (Mathf.Sqrt(y - yoffset) / a) + xoffset;

            // Setting position calculated
            line.SetPosition(i, new Vector3(x, y, z));

            // Placing the user's object along the curve
            store_object = Instantiate(parent_object, new Vector3(x, y, z), Quaternion.identity) as GameObject;

            // Inserting object to list
            cube.Insert(i, store_object);

            // Makes the element/GameObject above a child of the user's created GameObject previously
            cube[i].transform.parent = main_object.transform;

            /*********************************************************************************/

            // Calculating next angle based off an additional segment calculated from earlier
            angle += (360f / segments);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
