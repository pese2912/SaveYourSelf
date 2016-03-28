using UnityEngine;
using System.Collections;

public class ClickExitDoor : EventScript {

    public PlayerCtrl state; //플레이어 현재 상태
    public GameObject Arrow; // 화살표
    public Transform Door; // 문
    public GameObject EndingCam; // 엔딩 카메라
    public GameObject Audio;
    public GameObject End;
    public GameObject towel;
    public GameObject Player;
    public override void ClickAction()
    {
        
        state = GameObject.Find("Player").GetComponent<PlayerCtrl>();  //플레이어 현재 상태
        Arrow = GameObject.Find("ExitRoomDoor"); // 밖으로 통하는 문 위 화살표
        Door = GameObject.Find("ExitRoom").GetComponent<Transform>(); // 밖으로 문
        Player = GameObject.Find("Player");
        if (state.ps == PlayerCtrl.PlayerState.Escape_House && Arrow.GetComponent<SelectableObject>()._IsArrowAppearing == true) 
            // 플레이어 현재 상태가 Escape_House 이고 밖으로 통하는 문 위 화살표가 활성화 일 때만
        {
            GameObject.Find("Ment15").GetComponent<UITextManager>().EraseText();

            if (GameObject.Find("Ment16").GetComponent<UITextManager>().transform.FindChild("CanvasGroup").gameObject.active)
            {
                GameObject.Find("Ment16").GetComponent<UITextManager>().EraseText();
            }

            GameObject.Find("ExitRoom").GetComponent<AudioSource>().enabled = true;           

            Arrow.GetComponent<SelectableObject>()._IsArrowAppearing = false; // 문 위 화살표 비활성화
            Audio.GetComponent<AudioSource>().enabled = false;
            Player.GetComponent<AudioSource>().enabled = false;

            End.SetActive(true);
            towel.SetActive(false);
            EndingCam.SetActive(true);
           // GameObject.Find("Ment16").SetActive(false);
            state.GetComponent<EscapeHouse>().Ending();
            StartCoroutine("OpenDoor"); //문 여는 코루틴

        }
    }

    IEnumerator OpenDoor() //문을 연다
    {

        yield return new WaitForSeconds(0.1f); // 0.1초 후
        while (true)
        {
            Door.rotation = Quaternion.Slerp(Door.rotation, new Quaternion(0f, -4f, 0f, 3f), Time.deltaTime); //문 회전
            yield return null;
        }
    }
	
}


//38
