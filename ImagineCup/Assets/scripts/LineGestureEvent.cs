using UnityEngine;
using System.Collections;

public class LineGestureEvent : GrabHand_Gesture {

    public GameObject main;

    public override void DoAction() //왼손 주먹 쥐었을 경우
    {
       
        if (main.GetComponent<FEctl>().selectedClip) // 핀을 뽑은 경우
        {
           
            main.GetComponent<CheckFEState>().Leftgesture = true; //왼손 제스처 true
      
        }
        
    }
}
