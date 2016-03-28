using UnityEngine;
using System.Collections;

public class SmallFireFind : MonoBehaviour {

    public PlayerCtrl state; //플레이어 현재 상태
    public GameObject uiTextManager; // UI텍스트 매니저
    public GameObject Arrow; // 오브젝트 위 화살표 표시
    public GameObject Direction;
    public GameObject Player; //플레이어
    public GameObject ment; // 교육

	// Use this for initialization
	void Start () {

        state = GameObject.Find("Player").GetComponent<PlayerCtrl>();
        uiTextManager = GameObject.Find("UI(2)"); // 2번째 문장을 찾아서 
        Arrow = GameObject.Find("FE");
        Direction = GameObject.Find("Direction");
        Player = GameObject.Find("Player");
        // 각 컴포넌트 할당

        Small_Fire_Find();
        // Small_Fire_Find 함수 실행
	}
	
    public void Small_Fire_Find()
    {
        state.ps = PlayerCtrl.PlayerState.Small_Fire_Find; // 플레이어 현재 상태는 Small_Fire_Find
        state.PState = PlayerCtrl.PlayerState.Idle; // 코루틴을 계속 돌고 있기 때문에 임시로 액션 상태는 Idle 변화
        StartCoroutine("UiText"); // UI 텍스트를 그려주기 위해 코루틴 실행
      
    }

    IEnumerator UiText()
    {
        uiTextManager.GetComponent<UITextManager>().DrawText(); // 그려준다
        yield return new WaitForSeconds(3f); // 3초 후
        uiTextManager.GetComponent<UITextManager>().EraseText(); // 지운다
        yield return new WaitForSeconds(1f); // 1초 후

        GameObject.Find("Ment0").GetComponent<UITextManager>().DrawText();
        Arrow.GetComponent<SelectableObject>()._IsArrowAppearing = true; // 소화기 위 화살표 활성화
        Direction.transform.FindChild("Arrow1").gameObject.SetActive(true); // 소화기쪽으로 이동 화살표 생성
        StartCoroutine("CheckMove"); // 이동 
    }

    IEnumerator CheckMove() 
    {
        yield return null;
        GameObject pposition = GameObject.Find("Position2");
        while(true)
        {
            if (Player.transform.position == pposition.transform.position)
            {
                GameObject.Find("Move1").SetActive(false);
                GameObject.Find("Ment1").GetComponent<UITextManager>().DrawText();
                Player.transform.FindChild("Move2").gameObject.SetActive(true);
                GameObject.Find("Ment").GetComponent<AudioSource>().enabled = true;
                StartCoroutine("CheckMove2");
                break; 
            }

            yield return null;
        }
    }
    IEnumerator CheckMove2()
    {
        yield return null;
        GameObject pposition = GameObject.Find("Position3");
        while (true)
        {
            if (Player.transform.position == pposition.transform.position)
            {
                GameObject.Find("Move2").SetActive(false);
                break;
            }

            yield return null;
        }
    }
	// Update is called once per frame
	void Update () {
	
	}
}
