using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arc : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GameObject Arc = Resources.Load("brick") as GameObject;

        float brickH = 0.25f;
        float brickL = 0.5f;
        float brickW = 0.25f;

        float radius = 0.5f;
        Vector3 center = transform.position;
        Vector3 pos;

        float ang = Mathf.Sin(brickH / radius);
             
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;

        

        
                GameObject brick = Instantiate(Arc) as GameObject;

                Instantiate(Arc, pos, Quaternion.identity);



            

            /*// Update is called once per frame
            void Update()
            {

            }*/
        
    }
}

