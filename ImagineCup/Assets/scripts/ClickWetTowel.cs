using UnityEngine;
using System.Collections;
using System;
public class ClickWetTowel : EventScript {

    public PlayerCtrl state; //플레이어 현재 상태
    public GameObject Arrow; // 화살표
    public GameObject uiTextManager; // UI텍스트 매니저
    public GameObject water; // 물
    public GameObject wetTowel; // 젖은 손수건
    public GameObject camera; // 메인 카메라

    public override void ClickAction()
    {
        state = GameObject.Find("Player").GetComponent<PlayerCtrl>();  //플레이어 현재 상태
    
        if (state.ps == PlayerCtrl.PlayerState.Wet_HandkerChief && Arrow.GetComponent<SelectableObject>()._IsArrowAppearing == true)
        // 플레이어 현재 상태가 Wet_HandkerChief 이고 젖은 손수건 위 화살표가 활성화 일 때만
        {

            Arrow.GetComponent<SelectableObject>()._IsArrowAppearing = false; // 젖은 수건 위 화살표 ㅈㅔ거
            water.SetActive(false); // 물 끔
            wetTowel.GetComponent<TrackingHandMode>().enabled = true;
            GameObject.Find("Ment13").GetComponent<UITextManager>().EraseText();
            state.PState = PlayerCtrl.PlayerState.Escape_House;
          

        }
    }


    //public IEnumerator HandSet() // 왼손에 타월 붙이기
    //{

    //    yield return null;

    //    while (true)
    //    {
    //        try
    //        {
    //            if (GameObject.Find("Left Hand").active) // 왼손이 나타날 경우만
    //            {
    //                wetTowel.transform.parent = GameObject.Find("Pointer_LeftIndex").transform;
    //                wetTowel.transform.localPosition = new Vector3(0.07734124f, -0.6050965f, 0.04045838f);
    //                wetTowel.transform.localEulerAngles = new Vector3(46.72658f, 97.64855f, 288.5646f);
    //                // 위치 및 회전 값 설정
    //            }
    //        }
    //        catch (NullReferenceException e) { } 
    //        yield return null;
           
    //    }
    //}
 

}


//arrow2 -22.54  2.92  13.57    4.460185  149.0505  267.4742
//arrow4 -5.74  2.9   17.48       355.9847    93.85341    265.3667