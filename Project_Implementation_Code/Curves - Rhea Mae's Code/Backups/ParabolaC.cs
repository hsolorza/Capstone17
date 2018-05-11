using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolaC : MonoBehaviour {

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
    public List<GameObject> sphere;
    public List<GameObject> capsule;
    public List<GameObject> cylinder;
    // Some Variable
    private LineRenderer line;
    // User's GameObjects/objects
    public GameObject parent_object;

    // Use this for initialization
    void Start () {
        /** ONLY UNCOMMENT WHEN TESTING
        // Having object spawn in front of user
        xoffset = Camera.main.transform.position.x;
        yoffset = Camera.main.transform.position.y;
        zoffset = Camera.main.transform.position.z + 6;

        // Calculating number of spaces an object will be placed at on Parabola
        // segments = (360) / (asin(objectWidth/radius)) * 180/3.1415 
        //segments = (int)(360 / (Mathf.Asin(objectWidth / (a)) * 180.0 / 3.1415));
        line = gameObject.GetComponent<LineRenderer>();
        line.positionCount = (segments + 1);
        line.useWorldSpace = false;

        // Calling function to place objects along Parabola
        CreatePoints(); // Main object used is a cube

        //CreatePoints_Sphere(); // Main object used is a sphere
        //CreatePoints_Capsule(); // Main object used is a capsule
        //CreatePoints_Cylinder(); // Main object used is a cylinder
        **/
    }

    //void CreatePoints() {
    public void CreatePoints() {

        // Create a new list for objects
        cube = new List<GameObject>(segments);
        // Creating a GameObject for the object being used
        GameObject tempCube;
        // Physical variables to use to define each object along the Parabola
        float x = 0f; // x of equation
        float y = 0f; // y of equation
        float z = 0f;
        // Starting angle for the object
        float angle = 20f;

        //x = xoffset;

        // Loop going through Parabola based off number of segments calculated earlier
        for (int i = 0; i < (segments + 1); i++)
        {
            // Calculating x and y of an object based off angle and radius of the Parabola
            // x = a*sin(angle) + xoffset
            // y = a*cos(angle) + yoffset
            // NOTE: Might have to be flipped like for the CircleT code, still unsure exactly why
            //x = a * Mathf.Sin(Mathf.Deg2Rad * angle) * + xoffset;
            //y = a * Mathf.Cos(Mathf.Deg2Rad * angle) + yoffset;

            // OR
            // y = a(x-h)^2 + k
            //x = x + (objectWidth / 2);
            //y = a * (x - xoffset) * (x - xoffset) + yoffset;

            // 2nd Method
            // Inverse: x = sqrt((y-k) / a) + h
            y = y + objectHeight;
            x = (Mathf.Sqrt(y - yoffset) / a) + xoffset;

            // Setting position calculated
            line.SetPosition(i, new Vector3(x, y, z));
            // Printing out x position of object
            Debug.Log(line.GetPosition(i).x);

            // Creating a cube as the GameObject being used
            tempCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            /*tempCube.AddComponent<Rigidbody>();*/

            // Placing object at calculated position
            tempCube.transform.position = new Vector3(line.GetPosition(i).x, line.GetPosition(i).y, line.GetPosition(i).z);

            // Calculating angle of the object of the Parabola
            // angle = acos((x-xoffset)/(m))
            // m = -(x-xoffset) / (y-yoffset)
            float xAngle = Mathf.Acos((line.GetPosition(i).x - xoffset) / (-((line.GetPosition(i).x - xoffset) / (line.GetPosition(i).y - yoffset)))) * (float)(180.0 / 3.1415);
            //float xAngle = Mathf.Tan((line.GetPosition(i).y - yoffset) / (line.GetPosition(i).x - xoffset)) * (float)(180.0 / 3.1415) * (line.GetPosition(i).y - xoffset) / Mathf.Abs((line.GetPosition(i).y - xoffset));
            Debug.Log("Angle:" + xAngle);

            // Rotating object based off calculated angle from earlier
            //tempCube.transform.localEulerAngles = new Vector3(0, 0, xAngle);

            // Placing cube
            cube.Insert(i, tempCube);

            // Makes the element/GameObject above a child of the user's created GameObject previously
            cube[i].transform.parent = parent_object.transform;

            // Graphing the other side of the parabola
            /*********************************************************************************/

            //x = x * (-1);

            // y = a(x-h)^2 + k
            //y = a * (x - xoffset) * (x - xoffset) + yoffset;

            x = (-1) * (Mathf.Sqrt(y - yoffset) / a) + xoffset;

            // Setting position calculated
            line.SetPosition(i, new Vector3(x, y, z));
            // Printing out x position of object
            Debug.Log(line.GetPosition(i).x);

            // Creating a cube as the GameObject being used
            tempCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //tempCube.AddComponent<Rigidbody>();//

            // Placing object at calculated position
            tempCube.transform.position = new Vector3(line.GetPosition(i).x, line.GetPosition(i).y, line.GetPosition(i).z);

            // Calculating angle of the object of the Parabola
            // angle = acos((x-xoffset)/(m))
            // m = -(x-xoffset) / (y-yoffset)
            xAngle = Mathf.Acos((line.GetPosition(i).x - xoffset) / (-((line.GetPosition(i).x - xoffset) / (line.GetPosition(i).y - yoffset)))) * (float)(180.0 / 3.1415);
            //float xAngle = Mathf.Tan((line.GetPosition(i).y - yoffset) / (line.GetPosition(i).x - xoffset)) * (float)(180.0 / 3.1415) * (line.GetPosition(i).y - xoffset) / Mathf.Abs((line.GetPosition(i).y - xoffset));
            Debug.Log("Angle:" + xAngle);

            // Rotating object based off calculated angle from earlier
            //tempCube.transform.localEulerAngles = new Vector3(0, 0, xAngle);

            // Placing cube
            cube.Insert(i, tempCube);

            // Makes the element/GameObject above a child of the user's created GameObject previously
            cube[i].transform.parent = parent_object.transform;

            //x = x * (-1);

            /*********************************************************************************/

            // Calculating next angle based off an additional segment calculated from earlier
            angle += (360f / segments);
        }

    }

    //void CreatePoints_Sphere() {
    public void CreatePoints_Sphere() {

        // Create a new list for objects
        sphere = new List<GameObject>(segments);
        // Creating a GameObject for the object being used
        GameObject tempSphere;
        // Physical variables to use to define each object along the Parabola
        float x = 0f; // x of equation
        float y = 0f; // y of equation
        float z = 0f;
        // Starting angle for the object
        float angle = 20f;

        //x = xoffset;

        // Loop going through Parabola based off number of segments calculated earlier
        for (int i = 0; i < (segments + 1); i++)
        {
            // Calculating x and y of an object based off angle and radius of the Parabola
            // x = a*sin(angle) + xoffset
            // y = a*cos(angle) + yoffset
            // NOTE: Might have to be flipped like for the CircleT code, still unsure exactly why
            //x = a * Mathf.Sin(Mathf.Deg2Rad * angle) * + xoffset;
            //y = a * Mathf.Cos(Mathf.Deg2Rad * angle) + yoffset;

            // OR
            // y = a(x-h)^2 + k
            //x = x + (objectWidth / 2);
            //y = a * (x - xoffset) * (x - xoffset) + yoffset;

            // 2nd Method
            // Inverse: x = sqrt((y-k) / a) + h
            y = y + objectHeight;
            x = (Mathf.Sqrt(y - yoffset) / a) + xoffset;

            // Setting position calculated
            line.SetPosition(i, new Vector3(x, y, z));
            // Printing out x position of object
            Debug.Log(line.GetPosition(i).x);

            // Creating a sphere as the GameObject being used
            tempSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            /*tempSphere.AddComponent<Rigidbody>();*/

            // Placing object at calculated position
            tempSphere.transform.position = new Vector3(line.GetPosition(i).x, line.GetPosition(i).y, line.GetPosition(i).z);

            // Calculating angle of the object of the Parabola
            // angle = acos((x-xoffset)/(m))
            // m = -(x-xoffset) / (y-yoffset)
            float xAngle = Mathf.Acos((line.GetPosition(i).x - xoffset) / (-((line.GetPosition(i).x - xoffset) / (line.GetPosition(i).y - yoffset)))) * (float)(180.0 / 3.1415);
            //float xAngle = Mathf.Tan((line.GetPosition(i).y - yoffset) / (line.GetPosition(i).x - xoffset)) * (float)(180.0 / 3.1415) * (line.GetPosition(i).y - xoffset) / Mathf.Abs((line.GetPosition(i).y - xoffset));
            Debug.Log("Angle:" + xAngle);

            // Rotating object based off calculated angle from earlier
            //tempSphere.transform.localEulerAngles = new Vector3(0, 0, xAngle);

            // Placing sphere
            sphere.Insert(i, tempSphere);

            // Makes the element/GameObject above a child of the user's created GameObject previously
            sphere[i].transform.parent = parent_object.transform;

            // Graphing the other side of the parabola
            /*********************************************************************************/

            //x = x * (-1);

            // y = a(x-h)^2 + k
            //y = a * (x - xoffset) * (x - xoffset) + yoffset;

            x = (-1) * (Mathf.Sqrt(y - yoffset) / a) + xoffset;

            // Setting position calculated
            line.SetPosition(i, new Vector3(x, y, z));
            // Printing out x position of object
            Debug.Log(line.GetPosition(i).x);

            // Creating a sphere as the GameObject being used
            tempSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            //tempCube.AddComponent<Rigidbody>();//

            // Placing object at calculated position
            tempSphere.transform.position = new Vector3(line.GetPosition(i).x, line.GetPosition(i).y, line.GetPosition(i).z);

            // Calculating angle of the object of the Parabola
            // angle = acos((x-xoffset)/(m))
            // m = -(x-xoffset) / (y-yoffset)
            xAngle = Mathf.Acos((line.GetPosition(i).x - xoffset) / (-((line.GetPosition(i).x - xoffset) / (line.GetPosition(i).y - yoffset)))) * (float)(180.0 / 3.1415);
            //float xAngle = Mathf.Tan((line.GetPosition(i).y - yoffset) / (line.GetPosition(i).x - xoffset)) * (float)(180.0 / 3.1415) * (line.GetPosition(i).y - xoffset) / Mathf.Abs((line.GetPosition(i).y - xoffset));
            Debug.Log("Angle:" + xAngle);

            // Rotating object based off calculated angle from earlier
            //tempSphere.transform.localEulerAngles = new Vector3(0, 0, xAngle);

            // Placing sphere
            sphere.Insert(i, tempSphere);

            // Makes the element/GameObject above a child of the user's created GameObject previously
            sphere[i].transform.parent = parent_object.transform;

            //x = x * (-1);

            /*********************************************************************************/

            // Calculating next angle based off an additional segment calculated from earlier
            angle += (360f / segments);
        }

    }

    //void CreatePoints_Capsule() {
    public void CreatePoints_Capsule() {

        // Create a new list for objects
        capsule = new List<GameObject>(segments);
        // Creating a GameObject for the object being used
        GameObject tempCapsule;
        // Physical variables to use to define each object along the Parabola
        float x = 0f; // x of equation
        float y = 0f; // y of equation
        float z = 0f;
        // Starting angle for the object
        float angle = 20f;

        //x = xoffset;

        // Loop going through Parabola based off number of segments calculated earlier
        for (int i = 0; i < (segments + 1); i++)
        {
            // Calculating x and y of an object based off angle and radius of the Parabola
            // x = a*sin(angle) + xoffset
            // y = a*cos(angle) + yoffset
            // NOTE: Might have to be flipped like for the CircleT code, still unsure exactly why
            //x = a * Mathf.Sin(Mathf.Deg2Rad * angle) * + xoffset;
            //y = a * Mathf.Cos(Mathf.Deg2Rad * angle) + yoffset;

            // OR
            // y = a(x-h)^2 + k
            //x = x + (objectWidth / 2);
            //y = a * (x - xoffset) * (x - xoffset) + yoffset;

            // 2nd Method
            // Inverse: x = sqrt((y-k) / a) + h
            y = y + objectHeight;
            x = (Mathf.Sqrt(y - yoffset) / a) + xoffset;

            // Setting position calculated
            line.SetPosition(i, new Vector3(x, y, z));
            // Printing out x position of object
            Debug.Log(line.GetPosition(i).x);

            // Creating a capsule as the GameObject being used
            tempCapsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            /*tempCapsule.AddComponent<Rigidbody>();*/

            // Placing object at calculated position
            tempCapsule.transform.position = new Vector3(line.GetPosition(i).x, line.GetPosition(i).y, line.GetPosition(i).z);

            // Calculating angle of the object of the Parabola
            // angle = acos((x-xoffset)/(m))
            // m = -(x-xoffset) / (y-yoffset)
            float xAngle = Mathf.Acos((line.GetPosition(i).x - xoffset) / (-((line.GetPosition(i).x - xoffset) / (line.GetPosition(i).y - yoffset)))) * (float)(180.0 / 3.1415);
            //float xAngle = Mathf.Tan((line.GetPosition(i).y - yoffset) / (line.GetPosition(i).x - xoffset)) * (float)(180.0 / 3.1415) * (line.GetPosition(i).y - xoffset) / Mathf.Abs((line.GetPosition(i).y - xoffset));
            Debug.Log("Angle:" + xAngle);

            // Rotating object based off calculated angle from earlier
            //tempCapsule.transform.localEulerAngles = new Vector3(0, 0, xAngle);

            // Placing capsule
            capsule.Insert(i, tempCapsule);

            // Makes the element/GameObject above a child of the user's created GameObject previously
            capsule[i].transform.parent = parent_object.transform;

            // Graphing the other side of the parabola
            /*********************************************************************************/

            //x = x * (-1);

            // y = a(x-h)^2 + k
            //y = a * (x - xoffset) * (x - xoffset) + yoffset;

            x = (-1) * (Mathf.Sqrt(y - yoffset) / a) + xoffset;

            // Setting position calculated
            line.SetPosition(i, new Vector3(x, y, z));
            // Printing out x position of object
            Debug.Log(line.GetPosition(i).x);

            // Creating a cube as the GameObject being used
            tempCapsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            //tempCapsule.AddComponent<Rigidbody>();//

            // Placing object at calculated position
            tempCapsule.transform.position = new Vector3(line.GetPosition(i).x, line.GetPosition(i).y, line.GetPosition(i).z);

            // Calculating angle of the object of the Parabola
            // angle = acos((x-xoffset)/(m))
            // m = -(x-xoffset) / (y-yoffset)
            xAngle = Mathf.Acos((line.GetPosition(i).x - xoffset) / (-((line.GetPosition(i).x - xoffset) / (line.GetPosition(i).y - yoffset)))) * (float)(180.0 / 3.1415);
            //float xAngle = Mathf.Tan((line.GetPosition(i).y - yoffset) / (line.GetPosition(i).x - xoffset)) * (float)(180.0 / 3.1415) * (line.GetPosition(i).y - xoffset) / Mathf.Abs((line.GetPosition(i).y - xoffset));
            Debug.Log("Angle:" + xAngle);

            // Rotating object based off calculated angle from earlier
            //tempCapsule.transform.localEulerAngles = new Vector3(0, 0, xAngle);

            // Placing capsule
            capsule.Insert(i, tempCapsule);

            // Makes the element/GameObject above a child of the user's created GameObject previously
            capsule[i].transform.parent = parent_object.transform;

            //x = x * (-1);

            /*********************************************************************************/

            // Calculating next angle based off an additional segment calculated from earlier
            angle += (360f / segments);
        }

    }

    //void CreatePoints_Cylinder() {
    public void CreatePoints_Cylinder() {

        // Create a new list for objects
        cylinder = new List<GameObject>(segments);
        // Creating a GameObject for the object being used
        GameObject tempCylinder;
        // Physical variables to use to define each object along the Parabola
        float x = 0f; // x of equation
        float y = 0f; // y of equation
        float z = 0f;
        // Starting angle for the object
        float angle = 20f;

        //x = xoffset;

        // Loop going through Parabola based off number of segments calculated earlier
        for (int i = 0; i < (segments + 1); i++)
        {
            // Calculating x and y of an object based off angle and radius of the Parabola
            // x = a*sin(angle) + xoffset
            // y = a*cos(angle) + yoffset
            // NOTE: Might have to be flipped like for the CircleT code, still unsure exactly why
            //x = a * Mathf.Sin(Mathf.Deg2Rad * angle) * + xoffset;
            //y = a * Mathf.Cos(Mathf.Deg2Rad * angle) + yoffset;

            // OR
            // y = a(x-h)^2 + k
            //x = x + (objectWidth / 2);
            //y = a * (x - xoffset) * (x - xoffset) + yoffset;

            // 2nd Method
            // Inverse: x = sqrt((y-k) / a) + h
            y = y + objectHeight;
            x = (Mathf.Sqrt(y - yoffset) / a) + xoffset;

            // Setting position calculated
            line.SetPosition(i, new Vector3(x, y, z));
            // Printing out x position of object
            Debug.Log(line.GetPosition(i).x);

            // Creating a cylinder as the GameObject being used
            tempCylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            /*tempCylinder.AddComponent<Rigidbody>();*/

            // Placing object at calculated position
            tempCylinder.transform.position = new Vector3(line.GetPosition(i).x, line.GetPosition(i).y, line.GetPosition(i).z);

            // Calculating angle of the object of the Parabola
            // angle = acos((x-xoffset)/(m))
            // m = -(x-xoffset) / (y-yoffset)
            float xAngle = Mathf.Acos((line.GetPosition(i).x - xoffset) / (-((line.GetPosition(i).x - xoffset) / (line.GetPosition(i).y - yoffset)))) * (float)(180.0 / 3.1415);
            //float xAngle = Mathf.Tan((line.GetPosition(i).y - yoffset) / (line.GetPosition(i).x - xoffset)) * (float)(180.0 / 3.1415) * (line.GetPosition(i).y - xoffset) / Mathf.Abs((line.GetPosition(i).y - xoffset));
            Debug.Log("Angle:" + xAngle);

            // Rotating object based off calculated angle from earlier
            //tempCylinder.transform.localEulerAngles = new Vector3(0, 0, xAngle);

            // Placing cylinder
            cylinder.Insert(i, tempCylinder);

            // Makes the element/GameObject above a child of the user's created GameObject previously
            cylinder[i].transform.parent = parent_object.transform;

            // Graphing the other side of the parabola
            /*********************************************************************************/

            //x = x * (-1);

            // y = a(x-h)^2 + k
            //y = a * (x - xoffset) * (x - xoffset) + yoffset;

            x = (-1) * (Mathf.Sqrt(y - yoffset) / a) + xoffset;

            // Setting position calculated
            line.SetPosition(i, new Vector3(x, y, z));
            // Printing out x position of object
            Debug.Log(line.GetPosition(i).x);

            // Creating a cylinder as the GameObject being used
            tempCylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            //tempCylinder.AddComponent<Rigidbody>();//

            // Placing object at calculated position
            tempCylinder.transform.position = new Vector3(line.GetPosition(i).x, line.GetPosition(i).y, line.GetPosition(i).z);

            // Calculating angle of the object of the Parabola
            // angle = acos((x-xoffset)/(m))
            // m = -(x-xoffset) / (y-yoffset)
            xAngle = Mathf.Acos((line.GetPosition(i).x - xoffset) / (-((line.GetPosition(i).x - xoffset) / (line.GetPosition(i).y - yoffset)))) * (float)(180.0 / 3.1415);
            //float xAngle = Mathf.Tan((line.GetPosition(i).y - yoffset) / (line.GetPosition(i).x - xoffset)) * (float)(180.0 / 3.1415) * (line.GetPosition(i).y - xoffset) / Mathf.Abs((line.GetPosition(i).y - xoffset));
            Debug.Log("Angle:" + xAngle);

            // Rotating object based off calculated angle from earlier
            //tempCylinder.transform.localEulerAngles = new Vector3(0, 0, xAngle);

            // Placing cylinder
            cylinder.Insert(i, tempCylinder);

            // Makes the element/GameObject above a child of the user's created GameObject previously
            cylinder[i].transform.parent = parent_object.transform;

            //x = x * (-1);

            /*********************************************************************************/

            // Calculating next angle based off an additional segment calculated from earlier
            angle += (360f / segments);
        }

    }

    // Update is called once per frame
    void Update () {

		
	}
}
