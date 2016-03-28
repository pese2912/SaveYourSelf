using UnityEngine;
using System.Collections;

public class ClickLivingRoomDoor : EventScript {

    public PlayerCtrl state ; //플레이어 현재 상태
    public GameObject Arrow ; // 화살표
    public Transform Door; // 문
    public GameObject uiTextManager; // UI텍스트 매니저
    public GameObject player;  // 플레이어
    public AudioSource Audio;
    public AudioSource Audio2;

    public override void ClickAction()
    {
        player = GameObject.Find("Player"); // 플레이어
        Audio = GameObject.Find("Home").GetComponent<AudioSource>();
        Audio2 = player.GetComponent<AudioSource>();
        state = GameObject.Find("Player").GetComponent<PlayerCtrl>();  //플레이어 현재 상태
        Arrow = GameObject.Find("LivingRoomDoor"); // 거실로 통하는 문 위 화살표
        Door = GameObject.Find("LivingRoom").GetComponent<Transform>(); // 거실 문
        uiTextManager = GameObject.Find("UI(6)"); // 6번째 문장을 찾아서 
     

        if (state.ps == PlayerCtrl.PlayerState.Large_Fire_Find && Arrow.GetComponent<SelectableObject>()._IsArrowAppearing == true
            && player.transform.position == GameObject.Find("Position4").transform.position) // 플레이어 현재 상태가 Large_Fire_Find 이고 거실로 통하는 문 위 화살표가 활성화 일 때만
        {
            GameObject.Find("Ment").GetComponent<AudioSource>().enabled = false;
            Audio.enabled = true;
            Audio2.enabled = true;

            Arrow.GetComponent<SelectableObject>()._IsArrowAppearing=false; // 문 위 화살표 비활성화
           
            GameObject.Find("LivingRoom").GetComponent<AudioSource>().enabled = true;
            GameObject.Find("Ment5").GetComponent<UITextManager>().EraseText();
            StartCoroutine("OpenDoor"); //문 여는 코루틴
            StartCoroutine("UiText"); // UI 텍스트를 그려주기 위해 코루틴 실행
            
        }
    }

    IEnumerator OpenDoor() //문을 연다
    {

        yield return new WaitForSeconds(0.1f); // 0.1초 후
        while (true)
        {
            Door.rotation = Quaternion.Slerp(Door.rotation, new Quaternion(0f, -1f, 0f, 3f), Time.deltaTime);   
            yield return null;
        }
    }

    IEnumerator UiText()
    {
        yield return new WaitForSeconds(3f); // 3초 후
        uiTextManager.GetComponent<UITextManager>().DrawText(); // 그려준다
        yield return new WaitForSeconds(3f); // 3초 후
        uiTextManager.GetComponent<UITextManager>().EraseText(); // 지운다
        yield return new WaitForSeconds(1f); // 1초 후
        uiTextManager = GameObject.Find("UI(7)"); // 7번째 문장을 찾아서 
        uiTextManager.GetComponent<UITextManager>().DrawText(); // 그려준다
        yield return new WaitForSeconds(3f); // 3초 후
        uiTextManager.GetComponent<UITextManager>().EraseText(); // 지운다
       
        state.PState = PlayerCtrl.PlayerState.Call_119;  //플레이어 현재 상태를 Call_119로 바꾼다
     

    }
	
}
