using UnityEngine;
using System.Collections;

public class MoveObject : MonoBehaviour {

    public Transform endPosition;
    public Transform startPosition;
    public Transform _target;

    public float speed = 1.0f;
    private float startTime;
    private float journeyLength;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
        journeyLength = Vector3.Distance(startPosition.position, endPosition.position);
     
	}
	
	// Update is called once per frame
	void Update () {

        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        _target.position = Vector3.Lerp(startPosition.position, endPosition.position, fracJourney);
        //print(startPosition.position + "       " + endPosition.position);

     
	}
}
