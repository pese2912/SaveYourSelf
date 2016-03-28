using UnityEngine;
using System.Collections;
using System;

public class TrackingWetMode : MonoBehaviour { // state == Wet

    public Transform target;
    public Vector3 position;
    public bool flag;

	// Use this for initialization
	void Start () {
        flag = true;

	}
	
	// Update is called once per frame
	void LateUpdate () {

        try
        {
            if (GameObject.Find("Left Hand").active)
            {
                transform.position = GameObject.Find("Pointer_LeftIndex").transform.position;
                transform.eulerAngles = new Vector3(0, 323.5685f, 0);
                    flag = false;                   
    
            }
            else
            {
                  flag = true;
          
            }
        }

        catch (NullReferenceException e) { }
	}

    void Update()
    {
        if (flag)
            GameObject.Find("Ment16").GetComponent<UITextManager>().DrawText();
        else
            GameObject.Find("Ment16").GetComponent<UITextManager>().EraseText();

   
        flag = true;
 
    }
}
