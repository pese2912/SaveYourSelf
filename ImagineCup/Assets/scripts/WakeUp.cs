using UnityEngine;
using System.Collections;

public class WakeUp : MonoBehaviour {

    public Transform camera; //카메라 위치
    public PlayerCtrl state; //플레이어  상태

    void Start()
    {
      
        camera = GameObject.FindWithTag("MainCamera").GetComponent<Transform>();
        state = GameObject.Find("Player").GetComponent<PlayerCtrl>();
         //각 컴포넌트 할당

        Wake_Up();
        //WakeUp 함수 실행
    }

    public void Wake_Up()
    {
        
        state.ps = PlayerCtrl.PlayerState.Wake_Up; // 플레이어 현재 상태는 Wake_Up

        state.PState = PlayerCtrl.PlayerState.Idle; // 코루틴을 계속 돌고 있기 때문에 임시로 액션 상태는 Idle 변화
     
        GameObject.Find("Blink").GetComponent<SceneFadeInOut>().enabled = true; //Blink 스크립트 활성화 (눈을 깜박인다)      
        StartCoroutine("Find_Fire");
        //불을 발견하는지 코루틴을 통해 확인
        
     }

    IEnumerator Find_Fire()
    {
        yield return new WaitForSeconds(3f);

        while(true)//반복 검사
        {          
            if (GameObject.Find("Blink").GetComponent<SceneFadeInOut>().flag == 2) // Blink 스크립트 flag가 2이라는 것은 UI가 그려졌다가 지워진 후라는 것
            {
                
               // print(camera.eulerAngles.y);
                if (camera.eulerAngles.y < 300 && camera.eulerAngles.y > 250)//카메라 화면이 일정 각도 내에 들어서면 (즉, 컴퓨터가 불타는 것을 보았을 경우 )
                {
                    yield return new WaitForSeconds(1f);//1초 후
                    state.PState = PlayerCtrl.PlayerState.Small_Fire_Find; // 플레이어 상태를 다음단계(2. 작은 불을 발견 했을 시)로 변화
                    break;// 중지

                }
            }
            yield return null;
        }
        
    }
    
}
