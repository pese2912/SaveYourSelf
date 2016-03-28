using UnityEngine;
using System.Collections;

public class ClickHorse : EventScript {

    public GameObject main;

    public override void ClickAction() //호수 클릭시
    {
       
        if(main.GetComponent<FEctl>().selectedClip) // 핀을뽑았을 경우에만  
            main.GetComponent<CheckFEState>().Leftclick = true; // 왼손 호수 클릭 true
    }
}
