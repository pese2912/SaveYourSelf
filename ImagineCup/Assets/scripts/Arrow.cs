using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour
{
    Transform transform;
    int tmp;
	// Use this for initialization
	void Start () {
        tmp = 1;
        transform = GameObject.Find("Arrows Green").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = new Vector3(transform.position.x, transform.position.y - (0.05f * tmp), transform.position.z);

        StartCoroutine("wa");
	}
    IEnumerator wa()
    {
        yield return new WaitForSeconds(0.5f);
        tmp*=-1;
        yield return new WaitForSeconds(0.5f);
    }
}
