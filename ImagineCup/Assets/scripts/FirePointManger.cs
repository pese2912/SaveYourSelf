using UnityEngine;
using System.Collections;
using System.Timers;

public class FirePointManger : MonoBehaviour {

    public int StartFirstFireTime;
    public int TimeVal;
    public GameObject[] FirePoint;
    private Vector3 m_vPos;
    private Vector3 InitPosition;
    private int index;

	// Use this for initialization
    void Start()
    {
        index = 0;
        for (int i = 0; i < FirePoint.GetLength(0); i++ )
        {
            FirePoint[i].SetActive(false);
        }

        InvokeRepeating("StartFire", StartFirstFireTime, TimeVal);
    }
	
	// Update is called once per frame
	void Update () {
        if (index == FirePoint.GetLength(0))
            CancelInvoke();
	}

    void StartFire()
    {
        FirePoint[index].SetActive(true);
        index++;
     
    }
}
