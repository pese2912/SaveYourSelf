using UnityEngine;
using System.Collections;

public class WetHandkerChief : MonoBehaviour {

    public PlayerCtrl state; //플레이어 현재 상태
    public GameObject uiTextManager; // UI텍스트 매니저
    public GameObject Arrow; // 오브젝트 위 화살표 표시
    public GameObject Direction;
    public GameObject Player;
	// Use this for initialization
	void Start () {

        Player = GameObject.Find("Player");
        state = GameObject.Find("Player").GetComponent<PlayerCtrl>(); //플레이어상태
        Arrow = GameObject.Find("TowelOnTheTable"); // 손수건 위 화살표
        Direction = GameObject.Find("Direction");
        //각 컴포넌트 할당

        Wet_HandkerChief();
        // Wet_HandkerChief 메소드 실행
	}

    public void Wet_HandkerChief()
    {
        state.ps = PlayerCtrl.PlayerState.Wet_HandkerChief; // 플레이어 현재 상태는 Wet_HandkerChief
        state.PState = PlayerCtrl.PlayerState.Idle; // 코루틴을 계속 돌고 있기 때문에 임시로 액션 상태는 Idle 변화
        StartCoroutine("UiText"); // UI 텍스트를 그려주기 위해 코루틴 실행
     
    }

    IEnumerator UiText()
    {
        yield return new WaitForSeconds(1f); // 3초 후
        uiTextManager = GameObject.Find("UI(9)"); // 9번째 문장을 찾아서
        uiTextManager.GetComponent<UITextManager>().DrawText(); // 그려준다
        yield return new WaitForSeconds(3f); // 3초 후
        uiTextManager.GetComponent<UITextManager>().EraseText(); // 지운다
        yield return new WaitForSeconds(1f); // 3초 후
        uiTextManager = GameObject.Find("UI(10)"); // 10번째 문장을 찾아서 
        uiTextManager.GetComponent<UITextManager>().DrawText(); // 그려준다
        yield return new WaitForSeconds(3f); // 3초 후
        uiTextManager.GetComponent<UITextManager>().EraseText(); // 지운다
        yield return new WaitForSeconds(1f); // 1초 후

        GameObject.Find("Ment0").GetComponent<UITextManager>().DrawText();
        Direction.transform.FindChild("Arrow4").gameObject.SetActive(true);
        Arrow.GetComponent<SelectableObject>()._IsArrowAppearing = true; // 손수건 위 화살표 활성화
        StartCoroutine("CheckMove");

    }

    IEnumerator CheckMove()
    {
        yield return null;
        GameObject pposition = GameObject.Find("Position6");

        while (true)
        {
            if (Player.transform.position == pposition.transform.position)
            {
                GameObject.Find("Ment8").GetComponent<UITextManager>().DrawText();
                GameObject.Find("Move6").SetActive(false);
                break;
            }

            yield return null;
        }
    }
	// Update is called once per frame
	void Update () {
	
	}
}
