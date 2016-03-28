using UnityEngine;
using System.Collections;

public class EscapeHouse : MonoBehaviour {

    public PlayerCtrl state; //플레이어 현재 상태
    public GameObject uiTextManager; // UI텍스트 매니저
    public GameObject Arrow;
    public GameObject Direction;
    public GameObject Player;
    public GameObject camera;

	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player");
        state = GameObject.Find("Player").GetComponent<PlayerCtrl>();
        Direction = GameObject.Find("Direction");
        camera = GameObject.Find("Main Camera");
        Escape_House();
        // 각 컴포넌트 할당
	}
	
    public void Escape_House()
    {
        state.ps = PlayerCtrl.PlayerState.Escape_House; // 플레이어 현재 상태는 Escape_House
        state.PState = PlayerCtrl.PlayerState.Idle; // 코루틴을 계속 돌고 있기 때문에 임시로 액션 상태는 Idle 변화

        GameObject.Find("Ment14").GetComponent<UITextManager>().DrawText();
        Arrow = GameObject.Find("ExitRoomDoor"); // 밖으로 나가는 문 위 화살표 생성

       Direction.transform.FindChild("Arrow7").gameObject.SetActive(true);

       Arrow.GetComponent<SelectableObject>()._IsArrowAppearing = true; // 해당 오브젝트 위 화살표 활성화
       StartCoroutine("CheckMove1"); // 이동 
       
    }
    

    IEnumerator CheckMove1()
    {
        yield return null;
        GameObject pposition = GameObject.Find("Position9");
        while (true)
        {
            if (Player.transform.position == pposition.transform.position)
            {
                Direction.transform.FindChild("Arrow8").gameObject.SetActive(true);
                GameObject.Find("Move9").SetActive(false);
                StartCoroutine("CheckMove2"); // 이동 
                break;
            }

            yield return null;
        }
    }

    IEnumerator CheckMove2()
    {
        yield return null;


        GameObject pposition = GameObject.Find("Position4");
        while (true)

        {
            if (Player.transform.position == pposition.transform.position)
            {
                GameObject.Find("Move10").SetActive(false);
                yield return new WaitForSeconds(1f);
                uiTextManager = GameObject.Find("UI(12)"); // 해당 ui문장을 
                uiTextManager.GetComponent<UITextManager>().DrawText(); // 그려준다
                yield return new WaitForSeconds(3f); //3초 후
                uiTextManager.GetComponent<UITextManager>().EraseText(); // 지운다
                yield return new WaitForSeconds(1f);
  

                Player.transform.FindChild("Move11").gameObject.SetActive(true);
                StartCoroutine("CheckMove3"); // 이동 
                break;
            }

            yield return null;
        }
    }
    IEnumerator CheckMove3()
    {
        yield return null;
        GameObject pposition = GameObject.Find("Position11");
        while (true)
        {
            if (Player.transform.position == pposition.transform.position)
            {
                GameObject.Find("Move11").SetActive(false);
                yield return new WaitForSeconds(1f);
                uiTextManager = GameObject.Find("UI(13)"); // 해당 ui문장을 
                uiTextManager.GetComponent<UITextManager>().DrawText(); // 그려준다
                yield return new WaitForSeconds(3f); //3초 후
                uiTextManager.GetComponent<UITextManager>().EraseText(); // 지운다
                yield return new WaitForSeconds(1f);

                GameObject.Find("Ment14").GetComponent<UITextManager>().EraseText();
                GameObject.Find("Ment15").GetComponent<UITextManager>().DrawText();
               Direction.transform.FindChild("Arrow9").gameObject.SetActive(true);
               StartCoroutine("CheckMove4"); // 이동 
                break;
            }

            yield return null;
        }
    }

    IEnumerator CheckMove4()
    {
        yield return null;
        GameObject pposition = GameObject.Find("Position10");

        while (true)
        {
            if (Player.transform.position == pposition.transform.position)
            {
                GameObject.Find("Move12").SetActive(false);
                break;
            }

            yield return null;
        }
    }
    public void Ending()
    {
        StartCoroutine("EndingStart");
    }

    IEnumerator EndingStart()
    {
        
        yield return new WaitForSeconds(7f); // 3초 후

        GameObject.Find("EndingMent").GetComponent<AudioSource>().volume = 0.1f;
        GameObject.Find("Mic").GetComponent<MicTest>().voiceplay = true;
        
 
        GameObject.Find("EndingCameraSight").SetActive(false);
        camera.transform.FindChild("Plane").gameObject.SetActive(true);

        uiTextManager = GameObject.Find("EndingMent1");
        uiTextManager.GetComponent<UITextManager>().DrawText(); // 그려준다
        yield return new WaitForSeconds(7f); // 3초 후
        uiTextManager.GetComponent<UITextManager>().EraseText(); // 지운다
        yield return new WaitForSeconds(1f); // 3초 후

        uiTextManager = GameObject.Find("EndingMent2"); // 2번째 문장을 찾아서 
        uiTextManager.GetComponent<UITextManager>().DrawText(); // 그려준다
        yield return new WaitForSeconds(7f); // 3초 후
        uiTextManager.GetComponent<UITextManager>().EraseText(); // 지운다
        yield return new WaitForSeconds(1f); // 1초 후

        uiTextManager = GameObject.Find("EndingMent3"); // 2번째 문장을 찾아서 
        uiTextManager.GetComponent<UITextManager>().DrawText(); // 그려준다
        yield return new WaitForSeconds(3f); // 3초 후
        uiTextManager.GetComponent<UITextManager>().EraseText(); // 지운다
        yield return new WaitForSeconds(1f); // 1초 후

        uiTextManager = GameObject.Find("EndingMent4"); // 2번째 문장을 찾아서 
        uiTextManager.GetComponent<UITextManager>().DrawText(); // 그려준다
        yield return new WaitForSeconds(3f); // 3초 후
        uiTextManager.GetComponent<UITextManager>().EraseText(); // 지운다
        yield return new WaitForSeconds(1f); // 1초 후

        uiTextManager = GameObject.Find("EndingMent5"); // 2번째 문장을 찾아서 
        uiTextManager.GetComponent<UITextManager>().DrawText(); // 그려준다
        yield return new WaitForSeconds(3f); // 3초 후
        uiTextManager.GetComponent<UITextManager>().EraseText(); // 지운다
        yield return new WaitForSeconds(3f); // 3초 후

       
        Application.LoadLevel("OpeningScene");

    }

	// Update is called once per frame
	void Update () {
	
	}
}
