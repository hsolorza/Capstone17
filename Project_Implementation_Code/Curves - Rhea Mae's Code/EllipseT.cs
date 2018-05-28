using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllipseT : MonoBehaviour {

    // Equation for an Ellipse
    // 1 = (((x-h)^2)/a^2) + (((y-v)^2)/b^2)

    // Number of times object in placed on Ellipse
    private int segments = 10;
    // Width of the Object
    public float objectWidth = 1;
    // User Input Variables
    public float xoffset = 0; // h of equation
    public float yoffset = 0; // v of equation
    public float zoffset = 0;
    // Radius of the Ellipse
    public float xradius = 4; // a of equation
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

        // segements = perimeter of Ellipse / objectWidth
        int segs = (int)(((2 * 3.1415) * Mathf.Sqrt(((xradius * xradius) + (yradius * yradius)) / 2)) / objectWidth);

        // Resizing the number of segements needed
        segments = (5*segs) / 4;

        // Setting up line components
        line = gameObject.GetComponent<LineRenderer>();
        line.positionCount = (segments + 1);
        line.useWorldSpace = false;

        // Calling function to place objects along Ellipse
        CreatePoints();

    }

    void CreatePoints() {

        // Create a new list for objects
        cube = new List<GameObject>(segments);
        // Length of the list created above
        int list_length = 0;
        // Creating a GameObject for the object being used
        GameObject store_object;
        // Physical variables to use to define each object along the Ellipse
        float x = 0f; // x of equation
        float y = 0f; // y of equation
        float z = 0f;
        // Initial angle for the object
        float angle = 20f;

        // Loop going through Ellipse based off number of segments calculated earlier
        for (int i = 0; i < (segments + 1); i++)
        {
            // Calculating x and y of an object based off angle and radii of the Ellipse
            // x = a*cos(angle)
            // y = b*sin(angle)
            // NOTE: Might have to be flipped like for the CircleT code, still unsure exactly why
            x = xradius * Mathf.Cos(Mathf.Deg2Rad * angle) + xoffset;
            y = yradius * Mathf.Sin(Mathf.Deg2Rad * angle) + yoffset;

            // Setting position calculated
            line.SetPosition(i, new Vector3(x, y, z));

            // Placing the user's object along the curve
            store_object = Instantiate(parent_object, new Vector3(x, y, z), Quaternion.identity) as GameObject;

            // Inserting object to list
            cube.Insert(i, store_object);

            // Calculating next angle based off an additional segment calculated from earlier
            angle += (360f / segments);
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
