using UnityEngine;
using System.Collections;

public class ClickToiletRoomDoor : EventScript {

    PlayerCtrl state; //플레이어 현재 상태
    GameObject Arrow; // 화살표
    Transform Door; // 문
    GameObject uiTextManager; // UI텍스트 매니저
    public GameObject faucet; // 수도꼭지 위 화살표
    public GameObject Direction;
    public GameObject player;  // 플레이어

    public override void ClickAction()
    {
        state = GameObject.Find("Player").GetComponent<PlayerCtrl>();  //플레이어 현재 상태
        Arrow = GameObject.Find("ToiletRoomDoor"); // 화장실로 통하는 문 위 화살표
        Door = GameObject.Find("ToiletRoom").GetComponent<Transform>(); //화장실 문
        Direction = GameObject.Find("Direction");
        player = GameObject.Find("Player"); 

        if (state.ps == PlayerCtrl.PlayerState.Wet_HandkerChief && Arrow.GetComponent<SelectableObject>()._IsArrowAppearing == true
            && player.transform.position == GameObject.Find("Position7").transform.position) // 플레이어 현재 상태가 Wet_HandkerChief 이고 화장실로 통하는 문 위 화살표가 활성화 일 때만
        {
            GameObject.Find("Ment10").GetComponent<UITextManager>().EraseText();
            GameObject.Find("ToiletRoom").GetComponent<AudioSource>().enabled = true;
            StartCoroutine("OpenDoor"); //문 여는 코루틴
            Arrow.GetComponent<SelectableObject>()._IsArrowAppearing = false;// 화장실 문 위 화살표 없앰
            GameObject.Find("Ment12").GetComponent<UITextManager>().DrawText();
            Direction.transform.FindChild("Arrow6").gameObject.SetActive(true);
            faucet.GetComponent<SelectableObject>()._IsArrowAppearing = true; // 수도꼭지 위 화살표 생성
            StartCoroutine("CheckMove");
        }
    }
    IEnumerator CheckMove()
    {
        yield return null;
        GameObject pposition = GameObject.Find("Position8");

        while (true)
        {
            if (player.transform.position == pposition.transform.position)
            {
               
                GameObject.Find("Move8").SetActive(false);
                break;
            }

            yield return null;
        }
    }
    IEnumerator OpenDoor() //문을 연다
    {

        yield return new WaitForSeconds(0.1f); // 0.1초 후
        while (true)
        {
            Door.rotation = Quaternion.Slerp(Door.rotation, new Quaternion(0f, -1f, 0f, 3f), Time.deltaTime); //문 회전
            yield return null; 
        }
    }
}
