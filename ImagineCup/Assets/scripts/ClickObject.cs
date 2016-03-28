using UnityEngine;
using System.Collections;

public class ClickObject : EventScript {

    public GameObject main;

    public override void ClickAction() // 손잡이 클릭시
    {
      
        if (main.GetComponent<FEctl>().selectedLine)  // 호수를 선택했을 경우만
           main.GetComponent<CheckFEState>().Rightclick = true; //오른손 손잡이 클릭 true
    }
}
