using UnityEngine;
using System.Collections;
using System;
public class TrackingPhone : MonoBehaviour {


    public Transform target;
    public Vector3 position;


    // Use this for initialization
    void Start()
    {
     

    }

    // Update is called once per frame
    void LateUpdate()
    {

        try
        {
            if (GameObject.Find("Left Hand").active)
            {
                transform.position = GameObject.Find("Pointer_LeftIndex").transform.position + new Vector3(0,-0.5f,-0.2f);
                transform.eulerAngles = new Vector3(70.51679f, 183.161f, 352.6641f);
             

            }
          
        }

        catch (NullReferenceException e) { }
    }

    
}
