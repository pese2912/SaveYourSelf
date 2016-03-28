using UnityEngine;
using System.Collections;

public class ClickFaucet : EventScript {

   public PlayerCtrl state; //플레이어 현재 상태
   public GameObject Arrow; // 화살표
   public GameObject uiTextManager; // UI텍스트 매니저
   public GameObject water; // 물
   public GameObject towel; // 손수건
   public GameObject wetTowel; // 젖은 손수건
   public GameObject player; // 플레이어
   public GameObject HandSet;

    public override void ClickAction()
    {
        state = GameObject.Find("Player").GetComponent<PlayerCtrl>();  //플레이어 현재 상태
        Arrow = GameObject.Find("ToiletRoomFaucet"); // 수도꼭지 위 화살표
        player = GameObject.Find("Player");

        if (state.ps == PlayerCtrl.PlayerState.Wet_HandkerChief && Arrow.GetComponent<SelectableObject>()._IsArrowAppearing == true
            && player.transform.position == GameObject.Find("Position8").transform.position) // 플레이어 현재 상태가 Wet_HandkerChief 이고 수도꼭지 위 화살표가 활성화 일 때만
        {

       
            towel.GetComponent<TrackingHandMode>().enabled = false;
            if (GameObject.Find("Ment16").GetComponent<UITextManager>().transform.FindChild("CanvasGroup").gameObject.active)
            {
                GameObject.Find("Ment16").GetComponent<UITextManager>().EraseText();
            }
            
            GameObject.Find("Ment12").GetComponent<UITextManager>().EraseText();
            Arrow.GetComponent<SelectableObject>()._IsArrowAppearing = false; // 수도꼭지 위 화살표 없앰
            StartCoroutine("WetTowel"); // 수건을 적시기 위한 코루틴 함수
         
        }
    }
    IEnumerator WetTowel() //수건을 적신다
    {
        water.SetActive(true); // 물 틀고
        towel.transform.parent = null; 
        towel.transform.position = new Vector3(-6.98011f, 0.9213925f, 45.88066f);
        towel.transform.eulerAngles = new Vector3(292.5524f, 108.0288f, 2.13881f);
        //타월 위치 및 회전 값 재설정

        yield return new WaitForSeconds(3f); // 3초 후
        GameObject.Find("Ment13").GetComponent<UITextManager>().DrawText();
        towel.GetComponent<TowelScript>().state = TowelScript.State.wet;
        wetTowel.GetComponent<SelectableObject>()._IsArrowAppearing = true;
    }
	
}
