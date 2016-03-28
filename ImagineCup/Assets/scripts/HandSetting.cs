using UnityEngine;
using System.Collections;

public class HandSetting : MonoBehaviour {

    public GameObject towel;

	// Update is called once per frame
    void Update()
    {
        try
        {
            if (GameObject.Find("Left Hand").active) // 왼손이 나타날 경우만
            {

                towel.transform.parent = GameObject.Find("Pointer_LeftIndex").transform;
                towel.transform.localPosition = new Vector3(0.07734124f, -0.6050965f, 0.04045838f);
                towel.transform.localEulerAngles = new Vector3(46.72658f, 97.64855f, 288.5646f);
                // 위치 및 회전 값 설정
            }
        }catch(UnityException e)
        {
            
        }
    }
	
}
