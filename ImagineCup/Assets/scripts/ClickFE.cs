using UnityEngine;
using System.Collections;

public class ClickFE : EventScript {

    public GameObject target; // 소화기
    public GameObject fire; //불 
    public GameObject Camera; // 메인 카메라
    public GameObject player; // 플레이어
    public GameObject uiTextManager; // UI텍스트 매니저
    public GameObject Arrow; //화살표
    public PlayerCtrl state; // 플레이어 현재상태
    public GameObject Direction; // 이동 화살표

	public override void ClickAction ()
	{    
        state = GameObject.Find("Player").GetComponent<PlayerCtrl>(); // 플레이어 현재 상태
        Direction = GameObject.Find("Direction");
        target = GameObject.Find("FE"); // 소화기 위 화살표
       

       if (state.ps == PlayerCtrl.PlayerState.Small_Fire_Find && target.GetComponent<SelectableObject>()._IsArrowAppearing == true 
           && player.transform.position == GameObject.Find("Position3").transform.position) // 플레이어 현재 상태가 Small_Fire_Find이고  소화기 위 화살표가 활성화 일 때만
       {
           GameObject.Find("Ment1").GetComponent<UITextManager>().EraseText();
            state.PState = PlayerCtrl.PlayerState.Learn_Instructions; // 플레이어 현재 상태를 Learn_Instructions로 바꿈
        

            target.GetComponent<FEctl>().isObjectSelected = true;
            target.GetComponent<FEctl>().isOperateState = true;
            //소화기 클릭
            target.GetComponent<SelectableObject>()._IsArrowAppearing = false; // 소화기 위 화살표 비활성화          
        }


         if (state.ps == PlayerCtrl.PlayerState.Learn_Instructions && target.GetComponent<SelectableObject>()._IsArrowAppearing == true) // 플레이어 현재 상태가 Learn_Instructions이고  소화기 위 화살표가 활성화 일 때만
        {
            GameObject.Find("Ment1").GetComponent<UITextManager>().EraseText();
            GameObject.Find("Ment2-1").GetComponent<UITextManager>().DrawText();
            target.GetComponent<SelectableObject>()._IsArrowAppearing = false; // 소화기 위 화살표 비활성화
            target.transform.parent = Camera.transform; //소화기가 카메라 하위 오브젝트로 들어간다
            target.transform.localPosition = new Vector3(0.36f, -3.12f, 2.72f);
            target.transform.localScale = new Vector3(7f, 7f, 7f);
            target.transform.localEulerAngles = new Vector3(359.9927f, 65.63907f, 359.9857f);
         // 위치 및 회전 설정

            player.transform.FindChild("Move3").gameObject.SetActive(true);
            StartCoroutine("CheckMove");
            StartCoroutine("Check_Fire_Find");
            // 불 가까이 갔는지 검사하는 코루틴
            
        }
	}
    IEnumerator CheckMove()
    {
        yield return null;
        GameObject pposition = GameObject.Find("Position2");
        while (true)
        {
            if (player.transform.position == pposition.transform.position)
            {
                GameObject.Find("Move3").SetActive(false);
                break;
            }

            yield return null;
        }
    }
    IEnumerator Check_Fire_Find() // 블에 가까이 갔는지
    {
        yield return new WaitForSeconds(1f);

        while (true)//반복 검사
        {
            Vector3 viewPos = Camera.GetComponent<Camera>().WorldToViewportPoint(fire.transform.position);
            // 카메라 뷰포트로 변환
            if (viewPos.x > 0.3 && viewPos.x < 0.7 && viewPos.y > 0.3 && viewPos.y < 0.7 && viewPos.z >0 && viewPos.z <15)
            {
                GameObject.Find("Ment2-1").GetComponent<UITextManager>().EraseText();
                //카메라 안에 불이 들어오고 어느정도 가까이 갔을 경우
                StartCoroutine("UIText1");
                break;
            }
            yield return null;
        }

    }
    public IEnumerator UIText1()
    {

        yield return new WaitForSeconds(1f); //10초 뒤
        uiTextManager = GameObject.Find("UI(3-2.5)"); // 해당 ui문장을 
        uiTextManager.GetComponent<UITextManager>().DrawText(); // 그려준다
        yield return new WaitForSeconds(3f); //3초 후
        uiTextManager.GetComponent<UITextManager>().EraseText(); // 지운다
        yield return new WaitForSeconds(1f);

       UiManager("UI(3-3)", "호수");
       
        // UI그려주고 호수위에 화살표 생성
      // UiManager2("UI(3-4)", "손잡이");
       
        // UI그려주고 손잡이 위에 화살표 생성
    }

    public void UiManager(string ui, string arrow) // UI 그려주고 화살표 생성
    {
        StartCoroutine(UiText(ui, arrow));
    }

    public IEnumerator UiText(string ui, string arrow)// UI 그려주고 화살표 생성
    {
        yield return new WaitForSeconds(1f);
        uiTextManager = GameObject.Find(ui); // 해당 ui문장을 
        uiTextManager.GetComponent<UITextManager>().DrawText(); // 그려준다
        yield return new WaitForSeconds(3f); //3초 후
        uiTextManager.GetComponent<UITextManager>().EraseText(); // 지운다
        yield return new WaitForSeconds(1f);
        Arrow = GameObject.Find(arrow);
        GameObject.Find("Ment3").GetComponent<UITextManager>().DrawText();
        Arrow.GetComponent<SelectableObject>()._IsArrowAppearing = true; // 해당 오브젝트 위 화살표 활성화
        
    }

    public void UiManager2(string ui, string arrow) // UI 그려주고 화살표 생성
    {
        StartCoroutine(UiText2(ui, arrow));
    }

    public IEnumerator UiText2(string ui, string arrow)
    {
        yield return new WaitForSeconds(1f); //10초 뒤
        GameObject.Find("Ment3").GetComponent<UITextManager>().EraseText();
        uiTextManager = GameObject.Find(ui); // 해당 ui문장을 
        uiTextManager.GetComponent<UITextManager>().DrawText(); // 그려준다
        yield return new WaitForSeconds(3f); //3초 후
        uiTextManager.GetComponent<UITextManager>().EraseText(); // 지운다
        yield return new WaitForSeconds(1f);
        Arrow = GameObject.Find(arrow); 
        Arrow.GetComponent<SelectableObject>()._IsArrowAppearing = true; // 해당 오브젝트 위 화살표 활성화
        GameObject.Find("Ment4").GetComponent<UITextManager>().DrawText();
        player.GetComponent<LearnInstructions>().TurnOffFire();
        //불을 끄는지 검사하는 코루틴 실행

    }

    public void UiManagerPinEvent(string ui, string arrow) // UI 그려주고 화살표 생성
    {
        StartCoroutine(UiTextPinEvent(ui, arrow));

    }

    public IEnumerator UiTextPinEvent(string ui, string arrow)// UI 그려주고 화살표 생성
    {

        yield return new WaitForSeconds(1f);
        uiTextManager = GameObject.Find("UI(3-2)"); // 해당 ui문장을 
        uiTextManager.GetComponent<UITextManager>().DrawText(); // 그려준다
        yield return new WaitForSeconds(3f); //3초 후 
        uiTextManager.GetComponent<UITextManager>().EraseText(); // 지운다
        yield return new WaitForSeconds(1f);
        Arrow = GameObject.Find(arrow);
        Arrow.GetComponent<SelectableObject>()._IsArrowAppearing = true; // 해당 오브젝트 위 화살표 활성화
        GameObject.Find("Ment1").GetComponent<UITextManager>().DrawText();
    }

}