using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    public static float moveSpeed = 2.0f;
    public static float moveRot = 0.5f;

    static private Transform tr = null;
    public float v,rot;
    public PlayerCtrl state; //플레이어 현재 상태
    public Transform camera;
    BoxCollider playerCollider; //플레이어 콜라이더

	// Use this for initialization
	void Start () {

        state = GameObject.Find("Player").GetComponent<PlayerCtrl>();
        tr = this.gameObject.GetComponent<Transform>(); //위치 컴포넌트
        camera = GameObject.FindWithTag("MainCamera").GetComponent<Transform>();
        playerCollider = GameObject.FindWithTag("Player").GetComponent<BoxCollider>();
	}
	 
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.Escape))
        {

            Application.LoadLevel("scenario");

        }

        

     
       
     //   tr.eulerAngles = new Vector3(0, camera.eulerAngles.y, 0); //카메라 회전에 따라  플레이어도 같이 회전

        if(tr.position.x <=2.7f || tr.position.x >=14f || tr.position.z >=-2.0f) //침대밖으로 나가면 일어나서 커짐
        { 
            playerCollider.size = new Vector3(3f,8f,3f);
            GameObject.Find("PlayerTmp").GetComponent<PlayerPosition>().height=2.5f;
            moveSpeed=4f;
        }
     
	}

}
//x 2.7 이하 || 14 이상  z-2.0 이상   