using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperbolaT : MonoBehaviour {

    // Equation for an Hyperbola (Vertex Form)
    // 1 = (((x-h)^2)/a^2) - (((y-k)^2)/b^2)

    // Number of times object in placed on Hyperbola
    public int segments = 10;
    // Width of the Object
    public float objectWidth = 1;
    // User Input Variables
    public float xoffset = 0; // h of equation
    public float yoffset = 0; // v or k of equation
    public float zoffset = 0;
    // Asymptotes of the Hyperbola
    public float xradius = 1; // a of equation
    public float yradius = 2; // b of equation
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

        // Calling function to place objects along Hyperbola
        CreatePoints();

    }

    void CreatePoints() {

        // Create a new list for objects
        cube = new List<GameObject>(segments);
        // Creating a GameObject for the object being used
        GameObject store_object;
        // Physical variables to use to define each object along the Hyperbola
        float x = 0f; // x of equation
        float y = 0f; // y of equation
        float z = 0f;
        // Starting angle for the object
        float angle = 20f;

        // Loop going through Hyperbola based off number of segments calculated earlier
        for (int i = 0; i < (segments + 1); i++)
        {
            /*********************************************************************************/
            // Calculating Curve 1, Side 1 of Hyperbola
            /*********************************************************************************/

            // Calculating x and y of an object based off equation for Hyperbola
            // Solving for y in respects to x
            // y = sqrt(((((x-h)^2) / a^2) - 1) * b^2) + k
            x = x + objectWidth;
            y = Mathf.Sqrt((((Mathf.Pow((x - xoffset), 2)) / Mathf.Pow(xradius, 2)) - 1) / Mathf.Pow(yradius, 2)) + yoffset;

            // Setting position calculated
            line.SetPosition(i, new Vector3(x, y, z));

            // Placing the user's object along the curve
            store_object = Instantiate(parent_object, new Vector3(x, y, z), Quaternion.identity) as GameObject;

            // Inserting object to list
            cube.Insert(i, store_object);

            // Makes the element/GameObject above a child of the user's created GameObject previously
            cube[i].transform.parent = main_object.transform;

            // Calculating Curve 1, Side 2 of Hyperbola
            /*********************************************************************************/

            // Calculating lower half of this side of the Hyperbola
            y = y * (-1);

            // Setting position calculated
            line.SetPosition(i, new Vector3(x, y, z));

            // Placing the user's object along the curve
            store_object = Instantiate(parent_object, new Vector3(x, y, z), Quaternion.identity) as GameObject;

            // Inserting object to list
            cube.Insert(i, store_object);

            // Makes the element/GameObject above a child of the user's created GameObject previously
            cube[i].transform.parent = main_object.transform;

            // Converting y-value back to positive value
            y = y * (-1);

            /*********************************************************************************/
            // Calculating Curve 2, Side 1 of Hyperbola
            /*********************************************************************************/

            // Calculating x and y of an object based off equation for Hyperbola
            // Solving for y in respects to x
            // y = sqrt(((((x-h)^2) / a^2) - 1) * b^2) + k
            x = (-1) * x;
            y = Mathf.Sqrt((((Mathf.Pow((x - xoffset), 2)) / Mathf.Pow(xradius, 2)) - 1) / Mathf.Pow(yradius, 2)) + yoffset;

            // Setting position calculated
            line.SetPosition(i, new Vector3(x, y, z));

            // Placing the user's object along the curve
            store_object = Instantiate(parent_object, new Vector3(x, y, z), Quaternion.identity) as GameObject;

            // Inserting object to list
            cube.Insert(i, store_object);

            // Makes the element/GameObject above a child of the user's created GameObject previously
            cube[i].transform.parent = main_object.transform;

            // Calculating Curve 2, Side 2 of Hyperbola
            /*********************************************************************************/

            // Calculating lower half of this side of the Hyperbola
            y = y * (-1);

            // Setting position calculated
            line.SetPosition(i, new Vector3(x, y, z));

            // Placing the user's object along the curve
            store_object = Instantiate(parent_object, new Vector3(x, y, z), Quaternion.identity) as GameObject;

            // Inserting object to list
            cube.Insert(i, store_object);

            // Makes the element/GameObject above a child of the user's created GameObject previously
            cube[i].transform.parent = main_object.transform;

            // Converting y-value back to positive value
            y = y * (-1);

            /*********************************************************************************/

            // Converting x-value back to positive value
            x = (-1) * x;

            // Calculating next angle based off an additional segment calculated from earlier
            angle += (360f / segments);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
