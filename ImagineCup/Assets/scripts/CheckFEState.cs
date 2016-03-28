using UnityEngine;
using System.Collections;

public class CheckFEState : MonoBehaviour {

   public  GameObject main; //소화기
   public bool Leftgesture =false; //왼손 제스처 인식
   public bool Rightgesture = false;//오른손 제스처 인식
   public bool Leftclick = false; ////왼손 호수 클릭 인식
   public bool Rightclick = false;//오른손 손잡이 클릭 인식
   GameObject Arrow1,Arrow2; // 해당 오브젝트 위 화살표


	// Use this for initialization
	void Start () {
        Arrow1 = GameObject.Find("호수"); //호수 위 
        Arrow2 = GameObject.Find("손잡이"); // 손잡이 위 화살표
        StartCoroutine("CheckFeState");
	}

    public IEnumerator CheckFeState()
    {
        yield return null;
        while(true)
        {
            if (main.GetComponent<FEctl>().selectedClip)//핀을 뽑은뒤에만
            {

                if (Arrow1.GetComponent<SelectableObject>()._IsArrowAppearing) // 호수 위 화살표 있어야 함
                {
                    if (Leftgesture && Leftclick) //호수를 클릭하고 제스처도 취했을 경우
                    {

                        main.GetComponent<FEctl>().selectedLineDown = false;
                        main.GetComponent<FEctl>().selectedLine = true;
                        //호수를 들어올린다
                        StartCoroutine("CheckButton");
                        break;
                    }
                }

            }
            yield return null;
        }
    }
    public IEnumerator CheckButton() 
    {
        yield return null;
        main.transform.FindChild("ClickFE").GetComponent<ClickFE>().UiManager2("UI(3-4)", "손잡이");
        while(true)
        {
            if (Arrow2.GetComponent<SelectableObject>()._IsArrowAppearing) //  손잡이 위 화살표 있을 경우
            {
                if (Rightgesture && Rightclick) //손잡이 클릭하고 제스처도 취했을 경우
                {
                    main.GetComponent<FEctl>().selectedButton = true;
                    main.GetComponent<FEctl>().selectedButtonDown = false;
                    // 물 발사 
                }

                else if (!Rightgesture || !Rightclick) // 손잡이 클릭과 제스처가 하나라도 어긋날 경우
                {
                    if (main.GetComponent<FEctl>().isSwitchON) // 물을 쏘고 있던 경우엔
                    {
                        main.GetComponent<FEctl>().selectedButton = false;
                        main.GetComponent<FEctl>().selectedButtonDown = true;
                        main.GetComponent<FEctl>().isSwitchON = false;
                        //발사 멈춘다
                    }


                }

                Rightclick = false;
                Rightgesture = false;
            }
            yield return null;
        }
    }
	
	// Update is called once per frame
	void Update () {

        //if (main.GetComponent<FEctl>().selectedClip)//핀을 뽑은뒤에만
        //{

        //    if (Arrow1.GetComponent<SelectableObject>()._IsArrowAppearing) // 호수 위 화살표 있어야 함
        //    {
        //        if (Leftgesture && Leftclick) //호수를 클릭하고 제스처도 취했을 경우
        //        {
              
        //            main.GetComponent<FEctl>().selectedLineDown = false;
        //            main.GetComponent<FEctl>().selectedLine = true;
        //            //호수를 들어올린다

        //            if (Arrow2.GetComponent<SelectableObject>()._IsArrowAppearing) //  손잡이 위 화살표 있을 경우
        //            {
        //                if (Rightgesture && Rightclick) //손잡이 클릭하고 제스처도 취했을 경우
        //                {
        //                    main.GetComponent<FEctl>().selectedButton = true;
        //                    main.GetComponent<FEctl>().selectedButtonDown = false;                   
        //                    // 물 발사 
        //                }

        //                else if (!Rightgesture || !Rightclick) // 손잡이 클릭과 제스처가 하나라도 어긋날 경우
        //                {
        //                    if (main.GetComponent<FEctl>().isSwitchON) // 물을 쏘고 있던 경우엔
        //                    {
        //                        main.GetComponent<FEctl>().selectedButton = false;
        //                        main.GetComponent<FEctl>().selectedButtonDown = true;
        //                        main.GetComponent<FEctl>().isSwitchON = false;          
        //                        //발사 멈춘다
        //                    }
                   
                                                   
        //                }
                        
        //                Rightclick = false;
        //                Rightgesture = false;
        //            }
        //        }

        //        else if (!Leftgesture || !Leftclick) // 호수  클릭과 제스처가 하나라도 어긋날 경우
        //        {

        //            if (main.GetComponent<FEctl>().isSwitchON) // 물을 쏘고 있던 경우엔
        //            {
        //                main.GetComponent<FEctl>().selectedButton = false;
        //                main.GetComponent<FEctl>().selectedButtonDown = true;
        //                main.GetComponent<FEctl>().isSwitchON = false;
        //                //발사 멈춘다
        //            }
        //            else 
        //            {
        //                main.GetComponent<FEctl>().selectedButtonDown = false;
                         
                        
        //            }
        //                main.GetComponent<FEctl>().selectedLineDown = true;
        //                main.GetComponent<FEctl>().selectedLine = false;
        //                //호수 내린다

               
        //        }
        //        Leftclick = false;
        //        Leftgesture = false;

        //    }

        //}    


        
	}
}
