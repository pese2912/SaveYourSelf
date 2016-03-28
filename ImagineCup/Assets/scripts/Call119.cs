using UnityEngine;
using System.Collections;

public class Call119 : MonoBehaviour {

    public PlayerCtrl state; //플레이어 현재 상태
    public GameObject Arrow; // 오브젝트 위 화살표 표시
    public GameObject Direction;
    public GameObject Player;
    public bool enter;
	// Use this for initialization
	void Start () {

        enter = false;
        Player = GameObject.Find("Player");
        state = GameObject.Find("Player").GetComponent<PlayerCtrl>();
        Direction = GameObject.Find("Direction");
        Arrow = GameObject.Find("phone");
        // 각 컴포넌트 할당

        Call_119();
        //Call_119 메소드 실행
	}

    void Call_119()
    {
      
        state.ps = PlayerCtrl.PlayerState.Call_119; // 플레이어 현재 상태는 Call_119
        state.PState = PlayerCtrl.PlayerState.Idle; // 코루틴을 계속 돌고 있기 때문에 임시로 액션 상태는 Idle 변화
        GameObject.Find("Ment0").GetComponent<UITextManager>().DrawText();
        Direction.transform.FindChild("Arrow3").gameObject.SetActive(true);
        Arrow.GetComponent<SelectableObject>()._IsArrowAppearing = true; // 전화기 위 화살표 활성화
        StartCoroutine("CheckMove");
       
    }

    IEnumerator CheckMove()
    {
        yield return null;
        GameObject pposition = GameObject.Find("Position5");
        
        while (true)
        {
            if (Player.transform.position == pposition.transform.position)
            {
                GameObject.Find("Ment6").GetComponent<UITextManager>().DrawText();
                GameObject.Find("Move5").SetActive(false);
                break;
            }

            yield return null;
        }
    }

	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.KeypadEnter))
        {
            enter = true;
        }
	}
}
//