using UnityEngine;
using System.Collections;
using System;

public class TrackingHandMode : MonoBehaviour
{ // state == Hand

    public Transform target;
    public Vector3 position;
    public bool flag;

    // Use this for initialization

    void Start()
    {
        flag = true;

    }

    // Update is called once per frame
    void LateUpdate()
    {

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
        {
            if (GameObject.Find("Ment16").GetComponent<UITextManager>().transform.FindChild("CanvasGroup").gameObject.active)
            {
                GameObject.Find("Ment16").GetComponent<UITextManager>().EraseText();
            }
        }

        flag = true;

    }
}
