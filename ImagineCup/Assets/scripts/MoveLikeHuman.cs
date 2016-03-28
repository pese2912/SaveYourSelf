using UnityEngine;
using System.Collections;

public class MoveLikeHuman : MonoBehaviour {

    public Transform _target;
    public float speed = 1.0f;
    public float size;

    private float start;
    private float end;
    private float tempStart;
    private float tempEnd;
    public int flag;

	// Use this for initialization
	void Start () {
        
        start = _target.transform.position.y;
        end = _target.transform.position.y - size;
        tempStart = start;
        tempEnd = end;
	}
	
	// Update is called once per frame
	void LateUpdate () {

        if((transform.position.y-end)<=size*0.2f)
        {
            float temp;
            temp = start;
            start = end;
            end = temp;
            tempStart = start;
            tempEnd = end;
        }

        transform.position = Vector3.Lerp(new Vector3(transform.position.x, tempStart, transform.position.z), new Vector3(transform.position.x, tempEnd, transform.position.z), speed * Time.deltaTime);
        tempStart = transform.position.y;
       
       
	}

  
}
