using UnityEngine;
using System.Collections;

public class TowelEvent : EventScript {

    public GameObject towel; // 손수건
    public PlayerCtrl state; //플레이어 현재 상태
    public GameObject Arrow; // 화살표
    public Camera camera; // 카메라
    public GameObject uiTextManager; //Ui텍스트
    public GameObject Door; //화장실 가는 문
    public GameObject player; // 플레이어
   

    public override void ClickAction()
    {

        state = GameObject.Find("Player").GetComponent<PlayerCtrl>();  //플레이어 현재 상태
        player = GameObject.Find("Player"); //플레이어
        Arrow = GameObject.Find("TowelOnTheTable"); // 손수건 위 화살표
        camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        uiTextManager = GameObject.Find("UI(11)"); //11번째 문장

        if (towel.GetComponent<TowelScript>().state == TowelScript.State.table && state.ps == PlayerCtrl.PlayerState.Wet_HandkerChief
            && Arrow.GetComponent<SelectableObject>()._IsArrowAppearing == true && player.transform.position == GameObject.Find("Position6").transform.position)
        // 플레이어 현재 상태가 Wet_HandkerChief 이고 손수건 위 화살표가 활성화 일 때만)
        {
            
            GameObject.Find("Ment8").GetComponent<UITextManager>().EraseText();
            towel.GetComponent<TrackingHandMode>().enabled = true;
            towel.GetComponent<TowelScript>().UiManager("UI(11)", "ToiletRoomDoor");
          

            towel.GetComponent<TowelScript>().state = TowelScript.State.hand; 
            //손수건을 hand state로 바꾼다           
        }
    }

  
   
  
   

  
}
