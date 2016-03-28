using UnityEngine;
using System.Collections;

public class PlayerPosition : MonoBehaviour {

    Transform transform;
    Transform Player;
    public float height=0;
	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player").GetComponent<Transform>(); //플레이어 위치
        transform = GameObject.Find("PlayerTmp").GetComponent<Transform>(); 
	}
	
	// Update is called once per frame
	void Update () {
      
        transform.position = Player.position+new Vector3(0f,height,0f); //플레이어 위치를 따라감(카메라도 같이 이동)
     
	}
}
