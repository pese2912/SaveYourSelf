using UnityEngine;
using System.Collections;

public class PinEvent : EventScript {

    public GameObject main; //소화기
    public GameObject player; //플레이어
    PlayerCtrl state; //플레이어 상태
    GameObject Arrow; // 화살표
    public GameObject uiTextManager;

    public override void ClickAction() // 핀 클릭
    {
        state = GameObject.Find("Player").GetComponent<PlayerCtrl>();  //플레이어 현재 상태
        Arrow = GameObject.Find("핀"); // 소화기 핀 위 화살표

        if (main.GetComponent<FEctl>().readySelectClip && state.ps == PlayerCtrl.PlayerState.Learn_Instructions && Arrow.GetComponent<SelectableObject>()._IsArrowAppearing)
        //플레이어 상태는 Learn_Instructions , 소화기선택되고, 핀 위에 화살표가 있을경우
            
        {
            GameObject.Find("Ment2").GetComponent<UITextManager>().EraseText();
            main.GetComponent<FEctl>().selectedClip = true; // 핀 선택 true
            Arrow.GetComponent<SelectableObject>()._IsArrowAppearing=false; // 문 위 화살표 비활성화                 
            GameObject.Find("ClickFE").GetComponent<ClickFE>().UiManagerPinEvent("UI(3-2)", "FE"); // UI 생성 소화기 위 화살표 생성
            
        }
    }

   

}
