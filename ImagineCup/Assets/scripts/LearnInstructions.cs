using UnityEngine;
using System.Collections;

public class LearnInstructions : MonoBehaviour {

    public PlayerCtrl state; //플레이어 현재 상태
    public GameObject uiTextManager; // UI텍스트 매니저
    public GameObject Arrow; // 오브젝트 위 화살표 표시
    public GameObject Arrow2; // 오브젝트 위 화살표 표시
    public GameObject FE; // 소화기
    public Camera camera; // 메인카메라
    public GameObject Fire; // 불
    public  int cnt; // 카운트

	// Use this for initialization
	void Start () {
        cnt = 0;
        state = GameObject.Find("Player").GetComponent<PlayerCtrl>();
        FE = GameObject.Find("FE");
        camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        Fire = GameObject.Find("PRE_ELE_CPU_screen_02"); // 불타고있는 컴퓨터
        // 각 컴포넌트 할당

        Learn_Instructions();
        // Learn_Instructions 함수 실행
	}

    public void Learn_Instructions() //소화기 교육
    {
        state.ps = PlayerCtrl.PlayerState.Learn_Instructions; // 플레이어 현재 상태는 Learn_Instructions
        state.PState = PlayerCtrl.PlayerState.Idle; // 코루틴을 계속 돌고 있기 때문에 임시로 액션 상태는 Idle 변화
        StartCoroutine("UIText1");
        
    }

    public IEnumerator UIText1()
    {
        yield return new WaitForSeconds(1f);
        uiTextManager = GameObject.Find("UI(3-0)"); // 해당 ui문장을 
        uiTextManager.GetComponent<UITextManager>().DrawText(); // 그려준다
        yield return new WaitForSeconds(3f); //3초 후
        uiTextManager.GetComponent<UITextManager>().EraseText(); // 지운다
        yield return new WaitForSeconds(1f);
        StartCoroutine("UIText2");
       
    }
     public IEnumerator UIText2()
    {
        yield return new WaitForSeconds(1f);
        uiTextManager = GameObject.Find("UI(3-1)"); // 해당 ui문장을 
        uiTextManager.GetComponent<UITextManager>().DrawText(); // 그려준다
        yield return new WaitForSeconds(3f); //3초 후
        uiTextManager.GetComponent<UITextManager>().EraseText(); // 지운다
        yield return new WaitForSeconds(1f);
        UiManager("UI(3-1.5)", "핀"); 
       
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
        GameObject.Find("Ment2").GetComponent<UITextManager>().DrawText();
        Arrow = GameObject.Find(arrow); 
        Arrow.GetComponent<SelectableObject>()._IsArrowAppearing = true; // 해당 오브젝트 위 화살표 활성화
    }

    public void TurnOffFire() 
    {
        StartCoroutine("Turn_Off_Fire"); // 불 끄기
    }

    public IEnumerator Turn_Off_Fire()
    {
        yield return new WaitForSeconds(0.2f);
        Arrow = GameObject.Find("호수"); // 호수 위 화살표
        Arrow2 = GameObject.Find("손잡이"); // 손잡이 위 화살표
        
        while(true)
        {
            Vector3 viewPos = camera.WorldToViewportPoint(Fire.transform.position); // 카메라 뷰포트로 변환
                  
            if (FE.GetComponent<FEctl>().festate == FEctl.FEstate.last && viewPos.x > 0.3 && viewPos.x < 0.7 && viewPos.y > 0.3 && viewPos.y < 0.7) 
            {
                //카메라 화면 안에 불이 들오고 festate 상태가 물을 쏠 경우
                cnt++; // 카운트 증가
                if(cnt ==100) 
                {
                    
                    GameObject.Find("Fire (0)").SetActive(false);
                }

                else if (cnt == 200)
                {
                    GameObject.Find("Fire (1)").SetActive(false);
                }

                else if (cnt == 300)
                {
                    GameObject.Find("Fire (2)").SetActive(false);
                }

                else if (cnt == 400)
                {
                    GameObject.Find("Fire (3)").SetActive(false);
                }

                // 증가하면서 불을 차례로 끈다
                else if(cnt==500)
                {
                    
                    GameObject.Find("Smokes").SetActive(false);
                    //마지막 불 끄고
                    FE.SetActive(false);
                    GameObject.Find("Ment4").GetComponent<UITextManager>().EraseText();
                    Arrow.GetComponent<SelectableObject>()._IsArrowAppearing = false;
                    Arrow2.GetComponent<SelectableObject>()._IsArrowAppearing = false;
                    // 소화기랑 화살표 없앤다
                    state.PState = PlayerCtrl.PlayerState.Large_Fire_Find;
                    // 플레이어 상태는 Large_Fire_Find로 변경
                    break;
                }
            }
            yield return null;
       
        }

    }

	
}
