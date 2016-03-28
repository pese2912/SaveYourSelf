using UnityEngine;
using System.Collections;

public class ButtonGestureEvent : GrabHand_Gesture {

    public GameObject main;
	

    public override void DoAction()
    {

        if (main.GetComponent<FEctl>().selectedLine) //호수가 선택되었을 경우에만
        {
        
           main.GetComponent<CheckFEState>().Rightgesture = true; //오른손 제스처 true
     
       }
    }
}
