using UnityEngine;
using System.Collections;

public class ClickPhone : EventScript {

    public PlayerCtrl state; //플레이어 현재 상태
    public GameObject Arrow; // 화살표
    public GameObject phone; // 전화기
    public GameObject camera; // 카메라
    public GameObject uiTextManager; //Ui텍스트
    public GameObject player; //플레이어
    public GameObject Mic;

    public override void ClickAction() // 전화기 클릭시
    {
        state = GameObject.Find("Player").GetComponent<PlayerCtrl>();  //플레이어 현재 상태
        Arrow = GameObject.Find("phone"); // 전화기 위 화살표
        phone = GameObject.Find("phone"); // 전화기
        player = GameObject.Find("Player");
        
        if (state.ps == PlayerCtrl.PlayerState.Call_119 && Arrow.GetComponent<SelectableObject>()._IsArrowAppearing == true
            && player.transform.position == GameObject.Find("Position5").transform.position) // 플레이어 현재 상태가 Call_119 이고 전화기 위 화살표가 활성화 일 때만
        {


            Arrow.GetComponent<SelectableObject>()._IsArrowAppearing = false;
            // 전화기 위 화살표 비활성화
            
            GameObject.Find("Ment6").GetComponent<UITextManager>().EraseText();


            phone.transform.parent = camera.transform; // 전화기가 카메라 하위 오브젝트로 들어간다
            phone.transform.localPosition = new Vector3(0.061f, -0.8f, 1.086f);
            phone.transform.localEulerAngles = new Vector3(88.4165f, 179.0273f, 1.949072f);

  
            // 위치 및 회전값 설정
            
        
             
            GameObject.Find("Ment7").GetComponent<UITextManager>().DrawText();
            Mic.SetActive(true);

            uiTextManager = GameObject.Find("UI(8)"); // 해당 ui문장을 
            uiTextManager.GetComponent<UITextManager>().DrawText(); // 그려준다

            StartCoroutine("Record"); // UI 텍스트를 그려주기 위해 코루틴 실행
        }
    }

    IEnumerator Record()
    {
        
        yield return new WaitForSeconds(1f); //1초 뒤
            
        while(true)
        {
            if (Input.GetKey(KeyCode.KeypadEnter))
            {
                Mic.GetComponent<MicTest>().exit = true;
                
                StartCoroutine("Uitext");
                break;               
            }
            yield return null;
        }
   
    }

    IEnumerator Uitext()
    {

        yield return new WaitForSeconds(1f); //1초 뒤
        uiTextManager.GetComponent<UITextManager>().EraseText(); // 지워준다.
        GameObject.Find("Ment7").GetComponent<UITextManager>().EraseText();
        phone.SetActive(false);
        player.GetComponent<PlayerCtrl>().playerState = PlayerCtrl.PlayerState.Wet_HandkerChief;

         
    }

}

