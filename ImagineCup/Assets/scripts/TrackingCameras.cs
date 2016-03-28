using UnityEngine;
using System.Collections;

public class TrackingCameras : MonoBehaviour {

    public GameObject _target = null;
    public float distanceFromCamera;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(_target.transform.position + (_target.transform.forward * distanceFromCamera), transform.position, 5f * Time.deltaTime);
        transform.rotation = _target.transform.rotation;
	}
}
